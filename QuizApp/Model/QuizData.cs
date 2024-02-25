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
        private bool quizReady;
        private string title;
        private string description;
        private string author;
        private Question question;
        private int maxQuestions;


        public QuizData()
        {
            Loader = new QuizLoaderJson("test.json");
        }

        IQuizLoader Loader { get; set; }
        public bool QuizReady => quizReady;
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public Question Question { get => question; set => question = value; }
        public string Author { get => author; set => author = value; }
        public int MaxQuestions { get => maxQuestions; set => maxQuestions = value; }

        public void LoadQuiz()
        {
            Quiz quiz = Loader.LoadQuiz();
            if (quiz != null)
            {
                quizReady = true;
                Title = quiz.Title;
                Description = quiz.Description;
                Author = quiz.Author;
                MaxQuestions = quiz.Questions.Count;
                Console.WriteLine("Тестирование готово!");
                Console.WriteLine("--------------------");
            }
            else
            {
                quizReady = false;
                Title = "Тестирование не готово";
                Description = "Во время загрузки тестирования, что то пошло не так, возможные причины:\n" +
                    "- Файл с тестом не найден\n" +
                    "- Некорретный файл с тестом";
                Console.WriteLine("Тестирование не готово!");
                Console.WriteLine("-----------------------");
            }
        }

        public void LoadQuestion(int id)
        {
            if (QuizReady)
            {
                Question = Loader.LoadQuestion(id);
                Console.WriteLine("Загружен вопрос № " + id + " / Guid:" + Question.Guid);
            }
            else
            {
                Console.WriteLine("Невозможно загрузить вопрос, поскольку тестирование не готово");
            }
        }

        public void SelectAnswer(Guid guid)
        {
            if (QuizReady)
            {
                Loader.SendAnswer(Question.Guid, guid);
            }
            else
            {
                Console.WriteLine("Невозможно отправить ответ, поскольку тестирование не готово");
            } 
        }

        public Result LoadResult()
        {
            Result result = null;
            if (QuizReady)
            {
                result = Loader.LoadResult();
                Console.WriteLine("----------------------");
                Console.WriteLine("Тестирование завершено");
                Console.WriteLine(result.Title);
                Console.WriteLine(result.Description);
                Console.WriteLine(result.Message);
                Console.WriteLine("Очков" + result.Score);
                Console.WriteLine(result.QuizStarted);
                Console.WriteLine(result.QuizFinished);
                Console.WriteLine(result.QuizTimePass);
            }
            else
            {
                Console.WriteLine("Невозможно загрузить результаты, поскольку тестирование не готово");
            }
            return result;
        }

        public void StartQuiz()
        {
            Loader.StartQuiz();
        }
        public void StopQuiz()
        {
            Loader.StopQuiz();
        }

        public int GetTimer()
        {
            return Loader.GetTimer();
        }
    }
}
