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
        /// Правильный ответ - определяет идентификатор одного правильного ответа на вопрос
        /// </summary>
        [JsonRequired]
        public Guid CorrectAnswer { get; set; }

        /// <summary>
        /// Вес вопроса - определяет множитель полученных очков за правильный ответ на вопрос
        /// </summary>
        [JsonRequired]
        public double Multiplier { get; set; } = 1.0;

        /// <summary>
        /// Варианты ответов
        /// </summary>
        [JsonRequired]
        public Answer[] Answers { get; set; }

        public Question()
        {
            Guid = Guid.NewGuid();
        }
        public Question(string description, Answer[] answers, int right_id)
        {
            Guid = Guid.NewGuid();
            Description = description;
            Answers = answers;
            CorrectAnswer = answers[right_id].Guid;
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
                CorrectAnswer = CorrectAnswer,
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
