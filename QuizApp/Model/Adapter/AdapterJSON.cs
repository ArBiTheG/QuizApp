using Newtonsoft.Json;
using QuizApp.Model.Entity;
using QuizApp.Utils;
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
        string JSONFileTextContent;
        Quiz quiz;

        public AdapterJSON(string jSONFileName)
        {
            JSONFileName = jSONFileName;
            Test(jSONFileName);
        }
        public Quiz Connect()
        {
            if (File.Exists(JSONFileName))
            {
                try
                {
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("Загрузка файла тестированием...");
                    JSONFileTextContent = File.ReadAllText(JSONFileName);
                    Console.WriteLine("Десериализация JSON...");
                    Quiz tempQuiz = JsonConvert.DeserializeObject<Quiz>(JSONFileTextContent);
                    Console.WriteLine("Проверка корретности файла JSON...");
                    int countValided = tempQuiz.ValidateQuestions();
                    if (countValided > 0)
                    {
                        Console.WriteLine("Генерация вопросов...");
                        quiz = (Quiz)tempQuiz.Clone();
                        quiz.Questions = ScatterQuestions(tempQuiz.Questions, tempQuiz.Setting.LimitQuestions);
                        Console.WriteLine("Всего вопросов: " + tempQuiz.Questions.Count);
                        Console.WriteLine("Корректных вопросов: " + countValided);
                        Console.WriteLine("Отобрано вопросов: " + quiz.Questions.Count);
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
                finally
                {
                    Console.WriteLine("Загрузка файла тестирования завершено!");
                    Console.WriteLine("--------------------------------------");
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
            if (quiz != null)
            {
                if (quiz.Questions != null)
                {
                    if (quiz.Questions.Count > 0)
                    {
                        int lastId = quiz.Questions.Count - 1;
                        if (id < 0) id = 0;
                        if (id > lastId) id = lastId;

                        return quiz.Questions[id];
                    }
                }
            }
            return null;
        }
        public Result CheckQuiz()
        {
            int count = 0;

            if (quiz != null)
            {
                if (quiz.Questions != null)
                {
                    Quiz tempQuiz = JsonConvert.DeserializeObject<Quiz>(JSONFileTextContent);
                    foreach (Question tempQuestion in tempQuiz.Questions)
                    {
                        Question findedQuestion = quiz.Questions.Find((question) => question.Guid == tempQuestion.Guid);
                        if (findedQuestion != null)
                        {
                            Answer findedAnswer = findedQuestion.Answers.First((answer) => answer.Guid == tempQuestion.RightAnswer);
                            if (findedAnswer != null)
                            {
                                if (findedAnswer.Checked)
                                    count++;
                            }
                        }
                    }
                }
            }

            // Потом оптимизировать
            Result result = new Result();
            result.Guid = Guid.NewGuid();
            Score score = new Score();
            int minThreshold = -1;
            for (int i = 0; i < quiz.Scores.Count; i++)
            {
                if (count >= quiz.Scores[i].Threshold &&
                    quiz.Scores[i].Threshold > minThreshold)
                {
                    minThreshold = quiz.Scores[i].Threshold;
                    score = quiz.Scores[i];
                }
            }
            result.Title = score.Title;
            result.Description = score.Description;
            result.Score = count;
            result.Message = "Здесь будет сообщение к пользователю";
            result.QuizFinished = DateTime.Now;

            return result;
        }

        private static List<Question> ScatterQuestions(List<Question> questions, int count = 4)
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
        private static Answer[] ScatterAnswers(Answer[] answers)
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
        private static void Test(string file, int max_questions = 10, int limit_questions = 5, int max_answers = 4)
        {
            Quiz quiz = new Quiz();
            quiz.Title = "Title";
            quiz.Description = "Description";
            quiz.Author = "Daniil";

            quiz.Setting = new QuizSetting()
            {
                LimitQuestions = limit_questions,
            };
            quiz.Scores.Add(new Score() { Title= "5", Description = "Отлично", Threshold = 4 });
            quiz.Scores.Add(new Score() { Title = "4", Description = "Хорошо", Threshold = 3 });
            quiz.Scores.Add(new Score() { Title = "3", Description = "Удовлетворительно", Threshold = 1 });
            quiz.Scores.Add(new Score() { Title = "2", Description = "Неудовлетворительно" });

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
                quiz.Questions.Add(question);
            }

            if (File.Exists(file)) File.Delete(file);
            string textJson = JsonConvert.SerializeObject(quiz, Formatting.Indented);
            File.WriteAllText("test.json", textJson);
        }

    }
}
