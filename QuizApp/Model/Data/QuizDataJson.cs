using Newtonsoft.Json;
using QuizApp.Model.Data.Entity;
using QuizApp.Model.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuizApp.Model.Data
{
    public class QuizDataJson : IQuizData
    {
        Quiz _quiz;
        QuizTimer _timer;

        public event EventHandler<QuizTimerEventArgs> QuizTimerStarted;
        public event EventHandler QuizTimerFinished;
        public event EventHandler<QuizTimerEventArgs> QuizTimerElapsed;

        public Quiz Quiz => _quiz;

        public QuizDataJson(string fileName)
        {

#if DEBUG
            Debug.CreateQuizJSON(fileName);
#endif
            string fileContent = File.ReadAllText(fileName);

            Quiz temp_quiz = JsonConvert.DeserializeObject<Quiz>(fileContent);

            List<Question> temp_questions = new List<Question>();
            foreach (Question tempQuestion in temp_quiz.Questions)
            {
                if (tempQuestion.IsValidated())
                {
                    temp_questions.Add(tempQuestion);
                }
            }

            if (temp_questions.Count <= 0) throw new QuizInvalidException("Отсутствуют корректные вопросы");

            Quiz quiz = (Quiz)temp_quiz.Clone();
            quiz.Questions = QuizUtils.ShuffleAndCutQuestions(temp_questions.ToArray(), quiz.Setting.LimitQuestions);
            foreach (var question in quiz.Questions)
            {
                question.Answers = QuizUtils.ShuffleAnswers(question.Answers);
            }

#if DEBUG
            Console.WriteLine("Всего вопросов: " + temp_quiz.Questions.Length);
            Console.WriteLine("Корректных вопросов: " + temp_questions.Count);
            Console.WriteLine("Отобрано вопросов: " + quiz.Questions.Length);
#endif

            _timer = new QuizTimer(quiz.Setting.LimitTimer);

            _timer.ElapseStarted += delegate (object s, QuizTimerEventArgs e) { QuizTimerStarted?.Invoke(this, e); };
            _timer.ElapseFinished += delegate (object s, EventArgs e) { QuizTimerFinished?.Invoke(this, e); };
            _timer.Elapsed += delegate (object s, QuizTimerEventArgs e) { QuizTimerElapsed?.Invoke(this, e); };

            _quiz = quiz;
        }

        public Result GetResult()
        {
            int rightCount = 0;
            int maxQuestionsCount = 0;

            double scoreCount = 0;
            double maxScoreCount = 0;
            foreach (Question question in _quiz.Questions)
            {
                Answer answer = question.Answers.First((a) => a.Guid == question.RightAnswer);
                if (answer != null)
                {
                    if (answer.Checked)
                    {
                        rightCount++;
                        scoreCount += question.Multiplier;
                    }
                }
                maxScoreCount += question.Multiplier;
                maxQuestionsCount++;
            }

            double minThreshold = -1;
            Grade grade = new Grade();
            foreach (Grade s in _quiz.Grades)
            {
                if (scoreCount >= s.Threshold &&
                    s.Threshold > minThreshold)
                {
                    minThreshold = s.Threshold;
                    grade = s;
                }
            }

            Result result = new Result();
            result.Guid = Guid.NewGuid();
            result.Grade = grade.Title;
            result.GradeDescription = grade.Description;
            result.Score = scoreCount;
            result.MaxScore = maxScoreCount;
            result.RightQuestion = rightCount;
            result.MaxQuestions = maxQuestionsCount;
            result.Message = "Тестирование завершено";
            result.QuizStarted = _timer.Started;
            result.QuizFinished = _timer.Finished;
            result.QuizTimePass = (result.QuizFinished - result.QuizStarted).Seconds;


            return result;
        }

        public void StartQuiz()
        {
            _timer.Start();
        }

        public void StopQuiz()
        {
            _timer.Stop();
        }

        public void DoReply(Guid guid_question, params string[] answers)
        {
            Guid answer = Guid.Parse(answers[0]);
            Question question = _quiz.Questions.First(q => q.Guid == guid_question);
            foreach (Answer a in question.Answers)
            {
                if (a.Guid == answer)
                {
                    a.Checked = true;
                }
                else
                {
                    a.Checked = false;
                }
            }
        }
    }
}
