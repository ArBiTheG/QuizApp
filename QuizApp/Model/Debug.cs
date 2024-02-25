using Newtonsoft.Json;
using QuizApp.Model.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    public static class Debug
    {
        public static void CreateQuizJSON(string file, int max_questions = 10, int limit_questions = 5, int max_answers = 4)
        {
            Quiz quiz = new Quiz();
            quiz.Title = "Title";
            quiz.Description = "Description";
            quiz.Author = "Daniil";

            quiz.Setting = new QuizSetting()
            {
                LimitQuestions = limit_questions,
                Timer = 0,
            };
            quiz.Grades = new Grade[4];
            quiz.Grades[0] = new Grade() { Title = "5", Description = "Отлично", Threshold = 4 };
            quiz.Grades[1] = new Grade() { Title = "4", Description = "Хорошо", Threshold = 3 };
            quiz.Grades[2] = new Grade() { Title = "3", Description = "Удовлетворительно", Threshold = 1 };
            quiz.Grades[3] = new Grade() { Title = "2", Description = "Неудовлетворительно" };

            quiz.Questions = new Question[max_questions];
            for (int i = 0; i < max_questions; i++)
            {
                Question question = new Question();

                question.Description = "Question:" + i;
                question.Answers = new Answer[max_answers];
                for (int j = 0; j < max_answers; j++)
                {
                    Answer answer = new Answer();
                    answer.Description = "Answer:" + j;
                    question.Answers[j] = answer;
                }
                question.RightAnswer = question.Answers[0].Guid;
                question.Multiplier = 1.1;
                quiz.Questions[i] = question;
            }

            if (File.Exists(file)) File.Delete(file);
            string textJson = JsonConvert.SerializeObject(quiz, Formatting.Indented);
            File.WriteAllText("test.json", textJson);
        }
    }
}
