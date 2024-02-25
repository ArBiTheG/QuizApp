using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizApp.Utils;
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
        public Grade[] Grades { get; set; }
        [JsonRequired]
        public Question[] Questions { get; set; }
        public Quiz()
        {
            Guid = Guid.NewGuid();
        }

        public object Clone()
        {
            Console.WriteLine("Created " + ToString() + " /guid: " + Guid);
            return new Quiz()
            {
                Guid = Guid,
                Title = Title,
                Description = Description,
                Author = Author,
                Grades = Grades,
            };

        }
        public int ValidateQuestions()
        {
            if (Questions == null) return 0;

            List<Question> temp = new List<Question>();

            if (!string.IsNullOrEmpty(Title))
            {
                for (int i = 0; i < Questions.Length; i++)
                {
                    if (Questions[i].IsValidated())
                    {
                        temp.Add(Questions[i]);
                    }
                }
                Questions = temp.ToArray();
                return Questions.Length;
            };
            return 0;
        }
    }
}
