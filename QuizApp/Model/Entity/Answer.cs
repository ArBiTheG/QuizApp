using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Entity
{
    public class Answer : ICloneable
    {
        [JsonRequired]
        public Guid Guid { get; set; }
        [JsonRequired]
        public string Description { get; set; }
        [JsonIgnore]
        public bool Checked { get; set; }
        public Answer()
        {
            Guid = Guid.NewGuid();
        }

        public object Clone()
        {
            Console.WriteLine("Created " + ToString() + " /guid: " + Guid);
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
