using Newtonsoft.Json;
using QuizApp.Model.Entity;
using QuizApp.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace QuizApp.Model.Loader
{
    public class QuizLoaderJson: QuizLoaderClient, IQuizLoader
    {
        string JSONFileName;
        string JSONFileTextContent;

        public QuizLoaderJson(string jSONFileName)
        {
            JSONFileName = jSONFileName;
            Debug.CreateQuizJSON(jSONFileName);
        }
        public Quiz LoadQuiz()
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
                        Console.WriteLine("Всего вопросов: " + tempQuiz.Questions.Length);
                        Console.WriteLine("Корректных вопросов: " + countValided);
                        Console.WriteLine("Отобрано вопросов: " + quiz.Questions.Length);
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

        public Result LoadResult()
        {
            // Считаем баллы
            int rightCount = 0;
            int maxQuestionsCount = 0;

            double scoreCount = 0;
            double maxScoreCount = 0;
            if (quiz != null)
            {
                if (quiz.Questions != null)
                {
                    Quiz tempQuiz = JsonConvert.DeserializeObject<Quiz>(JSONFileTextContent);
                    foreach (Question tempQuestion in tempQuiz.Questions)
                    {
                        Question findedQuestion = Array.Find(quiz.Questions,(question) => question.Guid == tempQuestion.Guid);
                        if (findedQuestion != null)
                        {
                            Answer findedAnswer = findedQuestion.Answers.First((answer) => answer.Guid == tempQuestion.RightAnswer);
                            if (findedAnswer != null)
                            {
                                if (findedAnswer.Checked)
                                {
                                    rightCount++;
                                    scoreCount += tempQuestion.Multiplier;
                                }
                            }
                            maxScoreCount += tempQuestion.Multiplier;
                            maxQuestionsCount++;
                        }
                    }
                }
            }

            // Потом оптимизировать
            // Узнаём оценку
            double minThreshold = -1;
            Grade grade = new Grade();
            foreach (Grade s in quiz.Grades)
            {
                if (scoreCount >= s.Threshold &&
                    s.Threshold > minThreshold)
                {
                    minThreshold = s.Threshold;
                    grade = s;
                }
            }

            // Сформированный отчёт
            Result result = new Result();
            result.Guid = Guid.NewGuid();
            result.Title = grade.Title;
            result.Description = grade.Description;
            result.Score = scoreCount;
            result.MaxScore = maxScoreCount;
            result.RightQuestion = rightCount;
            result.MaxQuestions = maxQuestionsCount;
            result.Message = "Здесь будет сообщение к пользователю";
            result.QuizStarted = quizStarted;
            result.QuizFinished = quizFinished;
            result.QuizTimePass = (result.QuizFinished - result.QuizStarted).Seconds;


            return result;
        }
    }
}
