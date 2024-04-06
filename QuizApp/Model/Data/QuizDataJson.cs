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
            Debug.CreateQuizJSON(fileName,10,5);
#endif
            string fileContent = File.ReadAllText(fileName);

            Quiz temp_quiz = JsonConvert.DeserializeObject<Quiz>(fileContent, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                SerializationBinder = new QuizSerializationBinder(new List<Type>()
                {
                    typeof(QuestionOne),
                    typeof(QuestionMany),
                    typeof(QuestionText),
                })
            });
            List<IQuestion> temp_questions = new List<IQuestion>();
            foreach (IQuestion tempQuestion in temp_quiz.Questions)
            {
                if (tempQuestion.IsValidated())
                {
                    temp_questions.Add(tempQuestion);
                }
            }


            if (temp_questions.Count <= 0) throw new QuizInvalidException("Отсутствуют корректные вопросы");


            Quiz quiz = (Quiz)temp_quiz.Clone();
            quiz.Questions = QuizUtils.ShuffleAndCutQuestions(temp_questions.ToArray(), quiz.Config.QuestionsLimit);
            foreach (var question in quiz.Questions)
            {
                if (question is IQuestionAnswer)
                {
                    IQuestionAnswer questionAnswer = (question as IQuestionAnswer);
                    questionAnswer.Answers = QuizUtils.ShuffleAnswers(questionAnswer.Answers);
                }
            }

#if DEBUG
            Console.WriteLine("Всего вопросов: " + temp_quiz.Questions.Length);
            Console.WriteLine("Корректных вопросов: " + temp_questions.Count);
            Console.WriteLine("Отобрано вопросов: " + quiz.Questions.Length);
#endif

            _timer = new QuizTimer(quiz.Config.TimerLimit);

            _timer.ElapseStarted += delegate (object s, QuizTimerEventArgs e) { QuizTimerStarted?.Invoke(this, e); };
            _timer.ElapseFinished += delegate (object s, EventArgs e) { QuizTimerFinished?.Invoke(this, e); };
            _timer.Elapsed += delegate (object s, QuizTimerEventArgs e) { QuizTimerElapsed?.Invoke(this, e); };

            _quiz = quiz;
        }


        public Result GetResult()
        {
            calcCorrectAnswers(out int maxQuestions, out double maxQuestionsScore, out int correctQuestions, out double correctQuestionsScore);

            double minThreshold = -1;
            Grade grade = new Grade();
            foreach (Grade s in _quiz.Grades)
            {
                if (correctQuestionsScore >= s.Threshold &&
                    s.Threshold > minThreshold)
                {
                    minThreshold = s.Threshold;
                    grade = s;
                }
            }

            Result result = new Result();
            result.Grade = grade.Name;
            result.GradeDescription = grade.Description;
            result.MaxScore = maxQuestionsScore;
            result.Score = correctQuestionsScore;
            result.MaxQuestions = maxQuestions;
            result.RightQuestion = correctQuestions;
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

        public void SendAnswer(Guid guid_question, string answer, bool stage = true)
        {
            IQuestion question = _quiz.Questions.First(q => q.Guid == guid_question);

            if (question is IQuestionAnswer)
            {
                Guid guid_answer = Guid.Parse(answer);
                foreach (Answer a in (question as IQuestionAnswer).Answers)
                    if (a.Guid == guid_answer)
                        a.Checked = stage;
            }
            else if (question is IQuestionText)
            {
                (question as IQuestionText).SelectText = answer;
            }
        }

        /// <summary>
        /// Рассчитать правильные варианты ответов
        /// </summary>
        /// <param name="maxQuestions">Максимальное колличество вопросов</param>
        /// <param name="maxQuestionsScore">Максимальное колличество баллов</param>
        /// <param name="correctQuestions">Колличество правильных ответов</param>
        /// <param name="correctQuestionsScore">Колличество набранных баллов с правильных ответов</param>
        private void calcCorrectAnswers(out int maxQuestions, out double maxQuestionsScore, out int correctQuestions, out double correctQuestionsScore)
        {
            maxQuestions = 0;
            maxQuestionsScore = 0;
            correctQuestions = 0;
            correctQuestionsScore = 0;

            foreach (IQuestion question in _quiz.Questions)
            {
                if (question is IQuestionAnswerOne)
                {
                    calcCorrectAnswerOne(question as IQuestionAnswerOne, ref correctQuestions, ref correctQuestionsScore);
                }
                else if (question is IQuestionAnswerMany)
                {
                    calcCorrectAnswerMany(question as IQuestionAnswerMany, ref correctQuestions, ref correctQuestionsScore);
                }
                else if (question is IQuestionText)
                {
                    calcCorrectAnswerText(question as IQuestionText, ref correctQuestions, ref correctQuestionsScore);
                }

                maxQuestions++;
                maxQuestionsScore += question.Multiplier;
            }
        }

        private void calcCorrectAnswerOne(IQuestionAnswerOne question, ref int correctQuestions, ref double correctQuestionsScore)
        {
            Answer answer = question.Answers.First((a) => a.Guid == question.CorrectAnswer);
            if ((bool)(answer?.Checked))
            {
                correctQuestions++;
                correctQuestionsScore += question.Multiplier;
            }
        }

        private void calcCorrectAnswerMany(IQuestionAnswerMany question, ref int correctQuestions, ref double correctQuestionsScore)
        {
            double maxAnswers = question.CorrectAnswers.Length;
            double correctAnswers = 0;

            foreach (Answer answer in question.Answers)
            {
                bool hasCorrectAnswer = question.CorrectAnswers.Contains(answer.Guid);
                if (hasCorrectAnswer && answer.Checked)
                    correctAnswers += 1;
                else if (!hasCorrectAnswer && answer.Checked)
                    correctAnswers -= 1;
            }

            if (correctAnswers < 0)
                correctAnswers = 0;

            if (correctAnswers == question.CorrectAnswers.Length)
            {
                correctQuestions++;
                correctQuestionsScore += question.Multiplier;
            }
        }

        private void calcCorrectAnswerText(IQuestionText question, ref int correctQuestions, ref double correctQuestionsScore)
        {
            string selectText = question.SelectText;
            string correctText = question.CorrectText;

            selectText = selectText == null ? "" : selectText;
            correctText = correctText == null ? "" : correctText;

            selectText = selectText.ToLower();
            correctText = correctText.ToLower();

            selectText = selectText.Trim(' ');
            correctText = correctText.Trim(' ');

            if (selectText == correctText)
            {
                correctQuestions++;
                correctQuestionsScore += question.Multiplier;
            }
        }
    }
}
