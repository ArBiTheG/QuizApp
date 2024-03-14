using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Entity
{
    public class Question : ICloneable
    {
        [JsonRequired]
        public Guid Guid { get; set; }
        [JsonRequired]
        public string Description { get; set; }
        [JsonRequired]
        public Guid RightAnswer { get; set; }
        [JsonRequired]
        public double Multiplier { get; set; } = 1.0;
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
            RightAnswer = answers[right_id].Guid;
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
                RightAnswer = RightAnswer,
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
