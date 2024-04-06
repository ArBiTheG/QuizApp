using QuizApp.Model.Data;
using QuizApp.Model.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    public class QuizModel: IQuizModel
    {
        IQuizData _data;
        IQuestion _question;
        int _currentQuestionId = -1;

        public string Title { get => _data.Quiz.Title; }
        public string Description { get => _data.Quiz.Description; }
        public string Author { get => _data.Quiz.Author; }
        public int MaxQuestions { get => _data.Quiz.Questions.Length; }
        public int TimerLimit => _data.Quiz.Config.TimerLimit;

        public IQuestion Question { get => _question; }
        public int CurrentQuestionId { get => _currentQuestionId; }

        public event EventHandler<QuizTimerEventArgs> QuizStarted;
        public event EventHandler QuizFinished;
        public event EventHandler<QuizTimerEventArgs> QuizTimerElapsed;

        public QuizModel()
        {
            _data = new QuizDataJson("test.json");
            
            _data.QuizTimerStarted += delegate (object s, QuizTimerEventArgs e) { QuizStarted?.Invoke(this, e); };
            _data.QuizTimerFinished += delegate (object s, EventArgs e) { QuizFinished?.Invoke(this, e); };
            _data.QuizTimerElapsed += delegate (object s, QuizTimerEventArgs e) { QuizTimerElapsed?.Invoke(this, e); };
        }

        /// <summary>
        /// Загрузить вопрос
        /// </summary>
        public void LoadQuestion(int id)
        {
            _currentQuestionId = id;
            _question = _data.Quiz.Questions[id];
        }
        /// <summary>
        /// Загрузить следующий вопрос
        /// </summary>
        public void LoadNextQuestion()
        {
            int id = CurrentQuestionId;
            int last_id = MaxQuestions - 1;
            if (id < last_id) ++id;
            LoadQuestion(id);
        }
        /// <summary>
        /// Загрузить предыдущий вопрос
        /// </summary>
        public void LoadPrevQuestion()
        {
            int id = CurrentQuestionId;
            if (id > 0) --id;
            LoadQuestion(id);
        }
        /// <summary>
        /// Загрузить первый вопрос
        /// </summary>
        public void LoadFirstQuestion()
        {
            LoadQuestion(0);
        }
        /// <summary>
        /// Загрузить последний вопрос
        /// </summary>
        public void LoadLastQuestion()
        {
            int last_id = MaxQuestions - 1;
            LoadQuestion(last_id);
        }

        /// <summary>
        /// Выбрать ответ на вопрос вопрос
        /// </summary>
        public void SendAnswer(string answer, bool stage = true)
        {
            _data.SendAnswer(Question.Guid, answer, stage);
        }

        /// <summary>
        /// Загрузить результат
        /// </summary>
        public Result GetResult()
        {
            return _data.GetResult();
        }

        /// <summary>
        /// Начать тестирование
        /// </summary>
        public void StartQuiz()
        {
            _data.StartQuiz();
        }
        /// <summary>
        /// Остановить тестирование
        /// </summary>
        public void StopQuiz()
        {
            _data.StopQuiz();
        }
    }
}
