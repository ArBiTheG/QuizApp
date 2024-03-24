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

        public void LoadQuiz()
        {
            Quiz quiz = Data.LoadQuiz();
            Title = quiz.Title;
            Description = quiz.Description;
            Author = quiz.Author;
            MaxQuestions = quiz.Questions.Length;
        }

        public void LoadQuestion(int id)
        {
            CurrentQuestionId = id;
            Question = Data.LoadQuestion(id);
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
            Data.SendAnswer(Question.Guid, guid);
        }

        public Result LoadResult()
        {
            return Data.LoadResult(); ;
        }

        public void StartQuiz()
        {
            Data.StartQuiz();
            LoadFirstQuestion();
        }
        public void StopQuiz()
        {
            Data.StopQuiz();
        }

        public int GetTimer()
        {
            return Data.GetTimerCounter();
        }
    }
}
