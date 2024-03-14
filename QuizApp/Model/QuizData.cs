using QuizApp.Model.Loader;
using QuizApp.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    public class QuizData: IQuizData
    {
        public QuizData()
        {
            Loader = new QuizLoaderJson("test.json");
        }

        IQuizLoader Loader { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Question Question { get; set; }
        public string Author { get; set; }
        public int MaxQuestions { get; set; }
        public int CurrentQuestionId { get; set; }

        public void LoadQuiz()
        {
            Quiz quiz = Loader.LoadQuiz();
            Title = quiz.Title;
            Description = quiz.Description;
            Author = quiz.Author;
            MaxQuestions = quiz.Questions.Length;
        }

        public void LoadQuestion(int id)
        {
            CurrentQuestionId = id;
            Question = Loader.LoadQuestion(id);
        }
        public void LoadNextQuestion()
        {
            int id = CurrentQuestionId;
            int last_id = MaxQuestions - 1;
            if (id < last_id) ++id;
            LoadQuestion(id);
        }
        public void LoadPrevQuestion()
        {
            int id = CurrentQuestionId;
            if (id > 0) --id;
            LoadQuestion(id);
        }
        public void LoadFirstQuestion()
        {
            LoadQuestion(0);
        }
        public void LoadLastQuestion()
        {
            int last_id = MaxQuestions - 1;
            LoadQuestion(last_id);
        }

        public void SelectAnswer(Guid guid)
        {
            Loader.SendAnswer(Question.Guid, guid);
        }

        public Result LoadResult()
        {
            return Loader.LoadResult(); ;
        }

        public void StartQuiz()
        {
            Loader.StartQuiz();
            LoadFirstQuestion();
        }
        public void StopQuiz()
        {
            Loader.StopQuiz();
        }

        public int GetTimer()
        {
            return Loader.GetTimerCounter();
        }
    }
}
