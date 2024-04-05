using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Data.Entity
{
    public class Question : ICloneable
    {
        /// <summary>
        /// Уникальный идентификатор вопроса
        /// </summary>
        [JsonRequired]
        public Guid Guid { get; set; }

        /// <summary>
        /// Заголовок вопроса
        /// </summary>
        [JsonRequired]
        public string Title { get; set; }

        /// <summary>
        /// Описание вопроса
        /// </summary>
        [JsonRequired]
        public string Description { get; set; }

        /// <summary>
        /// Вес вопроса - определяет множитель полученных очков за правильный ответ на вопрос
        /// </summary>
        [JsonRequired]
        public double Multiplier { get; set; } = 1.0;
        /// <summary>
        /// Способ ответа на вопрос
        /// </summary>
        [JsonRequired]
        public AnswerQuestionType AnswerQuestionType { get; set; }
        /// <summary>
        /// Правильный ответ - определяет идентификатор одного правильного ответа на вопрос
        /// </summary>
        public Guid CorrectAnswer { get; set; }

        /// <summary>
        /// Правильные ответы - определяет идентификаторы нескольких правильных ответов на вопрос
        /// </summary>
        public Guid[] CorrectAnswers { get; set; }

        /// <summary>
        /// Введенный ответ пользователем
        /// </summary>
        [JsonIgnore]
        public string SelectText { get; set; }
        /// <summary>
        /// Произвольный правильный ответ - определяет текст для правильного ответа на вопрос
        /// </summary>
        public string CorrectText { get; set; }

        /// <summary>
        /// Варианты ответов
        /// </summary>
        public Answer[] Answers { get; set; }

        public Question()
        {
            AnswerQuestionType = AnswerQuestionType.None;
            Guid = Guid.NewGuid();
        }
        public Question(string description, Answer[] answers, int correct_id)
        {
            Guid = Guid.NewGuid();
            Description = description;
            AnswerQuestionType = AnswerQuestionType.CorrectOne;
            Answers = answers;
            CorrectAnswer = answers[correct_id].Guid;
        }
        public Question(string description, Answer[] answers, int[] correct_ids)
        {
            Guid = Guid.NewGuid();
            Description = description;
            AnswerQuestionType = AnswerQuestionType.CorrectMany;
            Answers = answers;
            CorrectAnswers = new Guid[correct_ids.Length];
            for (int i = 0; i < correct_ids.Length; i++)
                CorrectAnswers[i] = answers[i].Guid;
        }
        public Question(string description, string correct_text)
        {
            Guid = Guid.NewGuid();
            Description = description;
            AnswerQuestionType = AnswerQuestionType.CorrectText;
            CorrectText = correct_text;
        }

        public object Clone()
        {
#if DEBUG
            Console.WriteLine("Clone: " + ToString() + " / Guid: " + Guid);
#endif
            return new Question
            {
                Guid = Guid,
                Description = Description,
                AnswerQuestionType = AnswerQuestionType,
                CorrectAnswer = CorrectAnswer,
                CorrectAnswers = CorrectAnswers,
                CorrectText = CorrectText,
                Multiplier = Multiplier,
                Answers = Answers
            };
        }
        public bool IsValidated()
        {
            if (!string.IsNullOrEmpty(Description))
            {
                if (Answers != null)
                {
                    int countAnswersValid = 0;
                    for(int i = 0; i < Answers.Length; i++)
                    {
                        if (Answers[i].IsValidated()) countAnswersValid++;
                    }
                    return countAnswersValid > 1;
                }
            };
            return false;
        }
    }
}
