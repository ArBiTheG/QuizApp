using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Entity
{
    public class Question : ICloneable
    {
        public Guid Guid { get; set; }
        public string Description { get; set; }
        public List<Answer> Answers { get; set; }
        public Question()
        {
            Guid = Guid.NewGuid();
            Answers = new List<Answer>();
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
        public bool IsValidated()
        {
            if (!string.IsNullOrEmpty(Description))
            {
                if (Answers != null)
                {
                    int countAnswersValid = 0;
                    for(int i = 0; i < Answers.Count; i++)
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
