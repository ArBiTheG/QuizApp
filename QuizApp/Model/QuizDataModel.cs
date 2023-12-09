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
        Quiz quiz;
        Question question;
        int maxQuestions = 0;
        bool quizReady = false;

        public Quiz Quiz => quiz;
        public Question Question => question;
        public bool QuizReady => quizReady;

        public int MaxQuestions => maxQuestions;

        IAdapter Adapter { get; set; }
        public QuizDataModel()
        {
            Adapter = new AdapterJSON("test.json");
        }

        public void LoadData()
        {
            quiz = Adapter.GetQuiz();
            if (quiz != null)
            {
                maxQuestions = Adapter.GetCountQuestions();
                quizReady = true;
            }
            else
            {
                quizReady = false;
                quiz = new Quiz();
                quiz.Title = "Тестирование не готово";
                quiz.Description = "Во время загрузки тестирования, что то пошло не так, возможные причины:\n" +
                    "- Файл с тестом не найден\n" +
                    "- Некорретный файл с тестом";
            }
        }

        public void LoadQuestion(int number)
        {
            question = Adapter.GetQuestion(number - 1);
        }
    }
}
