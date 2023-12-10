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
        bool quizReady = false;
        private string title;
        private string description;
        Question question;
        int maxQuestions = 0;

        public bool QuizReady => quizReady;
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public Question Question { get => question; set => question = value; }
        public int MaxQuestions => maxQuestions;

        IAdapter Adapter { get; set; }
        public QuizDataModel()
        {
            Adapter = new AdapterJSON("test.json");
        }

        public void LoadData()
        {
            Quiz quiz = Adapter.Connect();
            if (quiz != null)
            {
                quizReady = true;
                Title = quiz.Title;
                Description = quiz.Description;
                maxQuestions = Adapter.GetCountQuestions();
            }
            else
            {
                quizReady = false;
                Title = "Тестирование не готово";
                Description = "Во время загрузки тестирования, что то пошло не так, возможные причины:\n" +
                    "- Файл с тестом не найден\n" +
                    "- Некорретный файл с тестом";
            }
        }

        public void LoadQuestion(int number)
        {
            Question = Adapter.GetQuestion(number - 1);
        }

        public void SelectAnswer(Question question, Guid guid)
        {
            foreach (Answer answer in question.Answers)
            {
                if (answer.Guid == guid)
                {
                    answer.Checked = true;
                }
                else
                {
                    answer.Checked = false;
                }
            }
        }
    }
}
