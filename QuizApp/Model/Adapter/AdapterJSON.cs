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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

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
                        quiz.Questions = ScatterQuestions(obj.Questions, obj.Setting.LimitQuestions);
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
        public static List<Question> ScatterQuestions(List<Question> questions, int count = 4)
        {
            List<Question> result = new List<Question>();
            if (questions != null)
            {

                if (questions.Count > 0)
                {
                    int maxCount = questions.Count;

                    if (count <= 0 || count > maxCount) count = maxCount;

                    int[] busyIds = new int[maxCount];
                    //Забиваем массив порядковыми числами 
                    for (int id = 0; id < busyIds.Length; ++id)
                    {
                        busyIds[id] = id;
                    }
                    //Выполняем перемешивание
                    Shuffler.Shuffle(busyIds);

                    //Отспекаем первые count вопросы
                    for (int id = 0; id < count; ++id)
                    {
                        Question oldQuestion = questions[busyIds[id]];
                        Question newQuestion = (Question)oldQuestion.Clone();
                        newQuestion.Answers = ScatterAnswers(oldQuestion.Answers);
                        result.Add(newQuestion);
                    }
                }
            }
            return result;
        }
        public static Answer[] ScatterAnswers(Answer[] answers)
        {
            int[] busyIds = new int[answers.Length];
            Answer[] result = new Answer[answers.Length];

            //Забиваем массив порядковыми числами 
            for (int id = 0; id < busyIds.Length; ++id)
            {
                busyIds[id] = id;
            }
            //Выполняем перемешивание
            Shuffler.Shuffle(busyIds);

            for (int id = 0; id < busyIds.Length; ++id)
            {
                result[id] = (Answer)answers[busyIds[id]].Clone();
            }
            return result;
        }

        public static void Test(string file, int max_questions = 10, int limit_questions = 5, int max_answers = 4)
        {
            Quiz quiz = new Quiz();
            quiz.Title = "Title";
            quiz.Description = "Description";
            quiz.Author = "Daniil";

            quiz.Setting = new QuizSetting()
            {
                LimitQuestions = limit_questions,
            };

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
                quiz.Questions.Add(question);
            }

            if (File.Exists(file)) File.Delete(file);
            string textJson = JsonConvert.SerializeObject(quiz, Formatting.Indented);
            File.WriteAllText("test.json", textJson);
        }
    }
}
