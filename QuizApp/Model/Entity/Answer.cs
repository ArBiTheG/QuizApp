using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Entity
{
    public class Answer : ICloneable
    {
        public Guid Guid { get; set; }
        public string Description { get; set; }
        public bool Checked { get; set; }
        public Answer()
        {
            Guid = Guid.NewGuid();
        }

        public object Clone()
        {
            return new Answer()
            {
                Guid = Guid,
                Description = Description,
                Checked= Checked
            };
        }
        public bool IsValidated()
        {
            if (!string.IsNullOrEmpty(Description))
            {
                return true;
            }
            return false;
        }
    }
}
