using Newtonsoft.Json;
using QuizApp.Model.Data.Entity;
using QuizApp.Model.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuizApp.Model.Data
{
    public class QuizDataJson : IQuizData
    {
        string _fileName;

        public QuizDataJson(string fileName)
        {
            _fileName = fileName;
        }

        public Quiz CreateQuiz()
        {
#if DEBUG
            Debug.CreateQuizJSON(_fileName, 10, 5);
#endif
            string fileContent = File.ReadAllText(_fileName);
            Quiz temp_quiz = JsonConvert.DeserializeObject<Quiz>(fileContent, new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Auto,
                SerializationBinder = new QuizSerializationBinder(new List<Type>()
                {
                    typeof(QuestionOne),
                    typeof(QuestionMany),
                    typeof(QuestionText),
                })
            });
            List<IQuestion> temp_questions = new List<IQuestion>();
            foreach (IQuestion temp_question in temp_quiz.Questions)
            {
                if (temp_question.IsValidated())
                {
                    temp_questions.Add(temp_question);
                }
            }


            if (temp_questions.Count <= 0) throw new QuizInvalidException("Отсутствуют корректные вопросы");


            Quiz quiz = (Quiz)temp_quiz.Clone();
            quiz.Questions = QuizUtils.ShuffleAndCutQuestions(temp_questions.ToArray(), quiz.Config.QuestionsLimit);
            foreach (var question in quiz.Questions)
            {
                if (question is IQuestionAnswer)
                {
                    IQuestionAnswer questionAnswer = (question as IQuestionAnswer);
                    questionAnswer.Answers = QuizUtils.ShuffleAnswers(questionAnswer.Answers);
                }
            }

#if DEBUG
            Console.WriteLine("Всего вопросов: " + temp_quiz.Questions.Length);
            Console.WriteLine("Корректных вопросов: " + temp_questions.Count);
            Console.WriteLine("Отобрано вопросов: " + quiz.Questions.Length);
#endif
            return quiz;
        }
    }
}
