using QuizApp.Model.Adapter;
using QuizApp.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    public class QuizDataModel
    {
        private bool quizReady;
        private string title;
        private string description;
        private string author;
        private Question question;
        private int maxQuestions;

        public QuizDataModel()
        {
            Adapter = new AdapterJSON("test.json");
        }

        IAdapter Adapter { get; set; }
        public bool QuizReady => quizReady;
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public Question Question { get => question; set => question = value; }
        public string Author { get => author; set => author = value; }
        public int MaxQuestions { get => maxQuestions; set => maxQuestions = value; }

        public void LoadData()
        {
            Quiz quiz = Adapter.Connect();
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

        public void LoadQuestion(int number)
        {
            if (QuizReady)
            {
                Question = Adapter.GetQuestion(number - 1);
                Console.WriteLine("Загружен вопрос № " + number + " / Guid:" + Question.Guid);
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
                if (Question!=null)
                {
                    if (Question.Answers != null)
                    {
                        foreach (Answer answer in Question.Answers)
                        {
                            if (answer.Guid == guid)
                            {
                                answer.Checked = true;
                                Console.WriteLine("Выбран вариант ответа под Guid:" + answer.Guid);
                            }
                            else
                            {
                                answer.Checked = false;
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Невозможно отправить ответ, поскольку тестирование не готово");
            } 
        }

        public void LoadResult()
        {
            if (QuizReady)
            {
                int count = Adapter.CheckQuiz();
                Console.WriteLine("----------------------");
                Console.WriteLine("Тестирование завершено");
                Console.WriteLine("Правильных вариантов ответа: " + count);
            }
            else
            {
                Console.WriteLine("Невозможно загрузить результаты, поскольку тестирование не готово");
            }
        }
    }
}
