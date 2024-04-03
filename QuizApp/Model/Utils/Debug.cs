using Newtonsoft.Json;
using QuizApp.Model.Data.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Utils
{
    public static class Debug
    {
        public static void CreateQuizJSON(string file, int max_questions = 10, int limit_questions = 5, int max_answers = 4)
        {
            Quiz quiz = new Quiz()
            {
                Title = "Title",
                Description = "Description",
                Author = "Daniil",
                Config = new QuizConfig()
                {
                    QuestionsLimit = limit_questions,
                    TimerLimit = 0,
                },
                Grades = new Grade[4]
                {
                    new Grade() { Name = "5", Description = "Отлично", Threshold = 4 },
                    new Grade() { Name = "4", Description = "Хорошо", Threshold = 3 },
                    new Grade() { Name = "3", Description = "Удовлетворительно", Threshold = 1 },
                    new Grade() { Name = "2", Description = "Неудовлетворительно" }
                },
                Questions = new Question[max_questions],
            };

            for (int i = 0; i < max_questions; i++)
            {
                Question question = new Question();

                question.Title = "Question:" + i;
                question.Description = "Question:" + i;
                question.Answers = new Answer[max_answers];
                for (int j = 0; j < max_answers; j++)
                {
                    Answer answer = new Answer();
                    answer.Text = "Answer:" + j;
                    question.Answers[j] = answer;
                }
                question.CorrectAnswer = question.Answers[0].Guid;
                question.Multiplier = 1.0;
                quiz.Questions[i] = question;
            }

            if (File.Exists(file)) File.Delete(file);
            string textJson = JsonConvert.SerializeObject(quiz, Formatting.Indented);
            File.WriteAllText(file, textJson);
        }
    }
}
