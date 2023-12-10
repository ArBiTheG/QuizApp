using Newtonsoft.Json;
using QuizApp.Model.Entity;
using QuizApp.Model.Utils;
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

        public Quiz Connect()
        {
            if (File.Exists(JSONFileName))
            {
                try
                {
                    Console.WriteLine("Загрузка файла с тестированием...");
                    string jsonText = File.ReadAllText(JSONFileName);
                    Console.WriteLine("Десериализация JSON...");
                    Quiz obj = JsonConvert.DeserializeObject<Quiz>(jsonText);
                    Console.WriteLine("Проверка корретности файла JSON...");
                    int countValided = obj.ValidateQuestions();
                    if (countValided>0)
                    {
                        Console.WriteLine("Генерация вопросов...");
                        quiz = (Quiz)obj.Clone();
                        quiz.Questions = Quiz.ScatterQuestions(obj.Questions, 8);
                        Console.WriteLine("Всего вопросов: " + obj.Questions.Count);
                        Console.WriteLine("Корректных вопросов: " + countValided);
                        Console.WriteLine("Отобрано случайных вопросов: " + quiz.Questions.Count);
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

        public Question GetQuestion(int id)
        {
            if (quiz!= null)
            {
                if (quiz.Questions != null)
                {
                    if (quiz.Questions.Count > 0)
                    {
                        int lastId = quiz.Questions.Count-1;
                        if (id < 0) id = 0;
                        if (id > lastId) id = lastId;

                        return quiz.Questions[id];
                    }
                }
            }
            return null;
        }
        public int GetCountQuestions()
        {
            return quiz.Questions.Count;
        }

        public AdapterJSON(string jSONFileName)
        {
            JSONFileName = jSONFileName;
            Test(jSONFileName);
        }
        public static void Test(string file)
        {
            Quiz quiz = new Quiz();
            quiz.Title = "Title";
            quiz.Description = "Description";
            quiz.Author = "Daniil";

            for (int i = 0; i< 10; i++)
            {
                Question question = new Question();

                question.Description = "Question:" + i;
                for (int j = 0; j < 12; j++)
                {
                    Answer answer = new Answer();
                    answer.Description = "Answer:" + j;
                    question.Answers.Add(answer);
                }
                quiz.Questions.Add(question);
            }

            if (File.Exists(file)) File.Delete(file);
            string textJson = JsonConvert.SerializeObject(quiz);
            File.WriteAllText("test.json", textJson);
        }
    }
}
