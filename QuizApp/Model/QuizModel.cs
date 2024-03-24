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
        public QuizModel()
        {
            Data = new QuizDataJson("test.json");
        }
        IQuizData Data { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Question Question { get; set; }
        public string Author { get; set; }
        public int MaxQuestions { get; set; }
        public int CurrentQuestionId { get; set; }

        /// <summary>
        /// Загрузить викторину
        /// </summary>
        public void LoadQuiz()
        {
            Quiz quiz = Data.LoadQuiz();
            Title = quiz.Title;
            Description = quiz.Description;
            Author = quiz.Author;
            MaxQuestions = quiz.Questions.Length;
        }

        /// <summary>
        /// Загрузить вопрос
        /// </summary>
        public void LoadQuestion(int id)
        {
            CurrentQuestionId = id;
            Question = Data.LoadQuestion(id);
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
        public void SelectAnswer(Guid guid)
        {
            Data.SendAnswer(Question.Guid, guid);
        }

        /// <summary>
        /// Загрузить результат
        /// </summary>
        public Result LoadResult()
        {
            return Data.LoadResult(); ;
        }

        /// <summary>
        /// Начать тестирование
        /// </summary>
        public void StartQuiz()
        {
            Data.StartQuiz();
            LoadFirstQuestion();
        }
        /// <summary>
        /// Остановить тестирование
        /// </summary>
        public void StopQuiz()
        {
            Data.StopQuiz();
        }

        /// <summary>
        /// Получить счётчик таймера
        /// </summary>
        public int GetTimer()
        {
            return Data.GetTimerCounter();
        }
    }
}
