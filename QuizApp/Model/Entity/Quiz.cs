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
        [JsonRequired]
        public Grade[] Grades { get; set; }
        [JsonRequired]
        public Question[] Questions { get; set; }
        public Quiz()
        {
            Guid = Guid.NewGuid();
        }
        public Quiz(string title, string description)
        {
            Guid = Guid.NewGuid();
            Title = title;
            Description = description;
        }

        public object Clone()
        {
#if DEBUG
            Console.WriteLine("Clone: " + ToString() + " / Guid: " + Guid);
#endif
            return new Quiz()
            {
                Guid = Guid,
                Title = Title,
                Description = Description,
                Author = Author,
                Setting = Setting,
                Grades = Grades,
                Questions = Questions,
            };

        }
    }
}
