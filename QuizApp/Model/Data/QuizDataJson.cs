using Newtonsoft.Json;
using QuizApp.Model.Data.Entity;
using System;
using System.Collections.Generic;
using System.IO;

namespace QuizApp.Model.Data
{
    public class QuizDataJson: QuizDataClient, IQuizData
    {
        private string _JSONFileName;
        private string _JSONFileTextContent;

        public QuizDataJson(string jSONFileName)
        {
            _JSONFileName = jSONFileName;
            Debug.CreateQuizJSON(jSONFileName);
        }
        public new Quiz LoadQuiz()
        {
            if (File.Exists(_JSONFileName))
            {
                _JSONFileTextContent = File.ReadAllText(_JSONFileName);
                
                Quiz tempQuiz = JsonConvert.DeserializeObject<Quiz>(_JSONFileTextContent);

                bool validatedHeaderQuiz = true;
                if (tempQuiz.Title.Length==0)
                {
                    validatedHeaderQuiz = false;
                }

                List<Question> validatedQuestionList = new List<Question>();
                foreach (Question tempQuestion in tempQuiz.Questions)
                {
                    if (tempQuestion.IsValidated())
                    {
                        validatedQuestionList.Add(tempQuestion);
                    }
                }

                if (validatedHeaderQuiz && validatedQuestionList.Count > 0)
                {
                    quiz = (Quiz)tempQuiz.Clone();
                    quiz.Questions = SelectionQuestions(validatedQuestionList.ToArray(), quiz.Setting.LimitQuestions);
#if DEBUG
                    Console.WriteLine("Всего вопросов: " + tempQuiz.Questions.Length);
                    Console.WriteLine("Корректных вопросов: " + validatedQuestionList.Count);
                    Console.WriteLine("Отобрано вопросов: " + quiz.Questions.Length);
#endif
                }
                else
                {
                    throw new Exception("Некорректный файл с тестированием");
                }
            }
            else
            {
                throw new Exception("Файл с тестированием не найден");
            }
            return quiz;
        }
    }
}
