using QuizApp.Model.Data;
using QuizApp.Model.Data.Entity;
using QuizApp.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuizApp.Model.Handler
{
    public class QuizHandler : IQuizHandler
    {
        Quiz _quiz;
        QuizTimer _timer;
        IQuestion _question;
        int _questionId;

        public string Title => _quiz.Title;
        public string Description => _quiz.Description;
        public string Author => _quiz.Author;
        public IQuestion Question => _quiz.Questions[_questionId];
        public int QuestionId => _questionId;
        public int MaxQuestions => _quiz.Questions.Length;
        public int TimerLimit => _quiz.Config.TimerLimit;

        public event EventHandler<QuizTimerEventArgs> QuizStarted;
        public event EventHandler<QuizTimerEventArgs> QuizFinished;
        public event EventHandler<QuizTimerEventArgs> QuizTimerElapsed;

        public QuizHandler(Quiz quiz)
        {
            _quiz = quiz;
            _timer = new QuizTimer(TimerLimit);

            _timer.ElapseStarted += delegate (object s, QuizTimerEventArgs e) { QuizStarted?.Invoke(this, e); };
            _timer.ElapseFinished += delegate (object s, QuizTimerEventArgs e) { QuizFinished?.Invoke(this, e); };
            _timer.Elapsed += delegate (object s, QuizTimerEventArgs e) { QuizTimerElapsed?.Invoke(this, e); };
        }

        public Result GetResult()
        {
            CalculatorCorrectAnswer.Calculate(_quiz,
                out int maxQuestions, 
                out double maxQuestionsScore, 
                out int correctQuestions, 
                out double correctQuestionsScore);

            double minThreshold = -1;
            Grade grade = null;
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
            result.QuizTimePass = _timer.Passed;

            return result;
        }
        public IQuestion GetQuestion(int id)
        {
            _questionId = id;
            _question = _quiz.Questions[id];
            return _question;
        }

        public IQuestion GetFirstQuestion()
        {
            return GetQuestion(0);
        }

        public IQuestion GetLastQuestion()
        {
            int last_id = MaxQuestions - 1;
            return GetQuestion(last_id);
        }

        public IQuestion GetNextQuestion()
        {
            int id = _questionId;
            int last_id = MaxQuestions - 1;
            if (id < last_id) ++id;
            return GetQuestion(id);
        }

        public IQuestion GetPrevQuestion()
        {
            int id = _questionId;
            if (id > 0) --id;
            return GetQuestion(id);
        }

        public void SetAnswer(string answer, bool state = true)
        {
            if (_question is IQuestionAnswer)
            {
                Guid guid_answer = Guid.Parse(answer);
                foreach (Answer a in (_question as IQuestionAnswer).Answers)
                    if (a.Guid == guid_answer)
                        a.Checked = state;
            }
            else if (_question is IQuestionText)
            {
                (_question as IQuestionText).SelectText = answer;
            }
        }

        public void StartQuiz()
        {
            _timer.Start();
        }

        public void StopQuiz()
        {
            _timer.Stop();
        }
    }
}
