using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Data.Entity
{
    [JsonObject(MemberSerialization.OptIn)]
    public class QuestionMany : IQuestionAnswerMany
    {
        [JsonRequired]
        [JsonProperty("guid")]
        public Guid Guid { get; set; }

        [JsonRequired]
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonRequired]
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("multiplier")]
        public double Multiplier { get; set; } = 1.0;

        [JsonRequired]
        [JsonProperty("correct_answers")]
        public Guid[] CorrectAnswers { get; set; }

        [JsonRequired]
        [JsonProperty("answers")]
        public Answer[] Answers { get; set; }

        public object Clone()
        {
#if DEBUG
            Console.WriteLine("Clone: " + ToString() + " / Guid: " + Guid);
#endif
            return new QuestionMany
            {
                Guid = Guid,
                Title = Title,
                Description = Description,
                Multiplier = Multiplier,
                CorrectAnswers = CorrectAnswers,
                Answers = Answers
            };
        }

        public QuestionMany()
        {
            Guid = Guid.NewGuid();
        }

        public bool IsValidated()
        {

            if (string.IsNullOrEmpty(Description))
                return false;

            foreach (Guid correct_answers in CorrectAnswers)
                if (!Answers.Any(x => x.Guid == correct_answers))
                    return false;

            if (Answers != null)
            {
                int countAnswersValid = 0;
                for (int i = 0; i < Answers.Length; i++)
                {
                    if (Answers[i].IsValidated()) countAnswersValid++;
                }

                if (countAnswersValid > 1)
                    return true;
            }
            return false;
        }
    }
}
