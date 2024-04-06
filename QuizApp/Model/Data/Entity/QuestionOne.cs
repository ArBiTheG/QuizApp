using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Data.Entity
{
    [JsonObject(MemberSerialization.OptIn)]
    public class QuestionOne : IQuestionAnswerOne
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
        [JsonProperty("correct_answer")]
        public Guid CorrectAnswer { get; set; }

        [JsonRequired]
        [JsonProperty("answers")]
        public Answer[] Answers { get; set; }

        public QuestionOne()
        {
            Guid = Guid.NewGuid();
        }
        public QuestionOne(string description, Answer[] answers, int correct_id)
        {
            Guid = Guid.NewGuid();
            Description = description;
            Answers = answers;
            CorrectAnswer = answers[correct_id].Guid;
        }

        public object Clone()
        {
#if DEBUG
            Console.WriteLine("Clone: " + ToString() + " / Guid: " + Guid);
#endif
            return new QuestionOne
            {
                Guid = Guid,
                Title = Title,
                Description = Description,
                Multiplier = Multiplier,
                CorrectAnswer = CorrectAnswer,
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
                    for (int i = 0; i < Answers.Length; i++)
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
