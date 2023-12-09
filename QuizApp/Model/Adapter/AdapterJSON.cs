using Newtonsoft.Json;
using QuizApp.Model.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp.Model.Adapter
{
    public class AdapterJSON : IAdapter
    {
        string JSONFileName;
        Quiz quiz;

        public Quiz GetQuiz()
        {
            if (File.Exists(JSONFileName))
            {
                try
                {
                    Console.WriteLine("Загрузка файла с тестированием...");
                    string jsonText = File.ReadAllText(JSONFileName);
                    Console.WriteLine("Десериализация JSON...");
                    quiz = JsonConvert.DeserializeObject<Quiz>(jsonText);
                    Console.WriteLine("Проверка корретности файла JSON...");
                    int countValided = quiz.ValidateQuestions();
                    if (countValided>0)
                    {
                        Console.WriteLine("Всего вопросов: " + quiz.Questions.Count);
                        Console.WriteLine("Корректных вопросов: " + countValided);
                        Console.WriteLine("Генерация вопросов...");
                        quiz.Questions = Quiz.ScatterQuestions(quiz.Questions, 10);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка. Файл с экземпляром для тестирования некорректный!");
                    }
                }
                catch
                {
                    Console.WriteLine("Произошла ошибка во время загрузки тестирования!");
                }
            }
            else
            {
                Console.WriteLine("Ошибка. Файл с экземпляром для тестирования не был найден!");
            }
            return quiz;
        }
        public AdapterJSON(string jSONFileName)
        {
            JSONFileName = jSONFileName;
            //Test();
        }
        public static void Test()
        {
            Quiz quiz = new Quiz();
            quiz.Title = "Title";
            quiz.Description = "Description";
            quiz.Author = "Daniil";

            for (int i = 0; i< 100; i++)
            {
                Question question = new Question();

                question.Description = "Question:" + i;
                for (int j = 0; j < 4; j++)
                {
                    Answer answer = new Answer();
                    answer.Description = "Answer:" + j;
                    question.Answers.Add(answer);
                }
                quiz.Questions.Add(question);
            }

            string textJson = JsonConvert.SerializeObject(quiz);
            File.WriteAllText("test.json", textJson);
        }
    }
}
