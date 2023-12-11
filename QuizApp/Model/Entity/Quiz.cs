using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizApp.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuizApp.Model.Entity
{
    public class Quiz: ICloneable
    {
        [JsonRequired]
        public Guid Guid { get; set; }
        [JsonRequired]
        public string Title { get; set; }
        [JsonRequired]
        public string Description { get; set; }
        public string Author { get; set; }
        public QuizSetting Setting { get; set; }
        [JsonRequired]
        public List<Question> Questions { get; set; }
        public Quiz()
        {
            Guid = Guid.NewGuid();
            Questions = new List<Question>();
        }

        public object Clone()
        {
            Console.WriteLine("Clone " + ToString() + " /guid: " + Guid);
            return new Quiz()
            {
                Guid = Guid,
                Title = Title,
                Description = Description,
                Author = Author,
            };

        }
        public int ValidateQuestions()
        {
            if (Questions == null) return 0;

            if (!string.IsNullOrEmpty(Title))
            {
                int countQuestionValid = 0;
                for (int i = 0; i < Questions.Count; i++)
                {
                    if (Questions[i].IsValidated())
                    {
                        countQuestionValid++;
                    }
                    else
                    {
                        Questions.RemoveAt(i);
                    }
                }
                return countQuestionValid;
            };
            return 0;
        }
    }
}
