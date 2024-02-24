using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Entity
{
    public class Grade
    {
        [JsonRequired]
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Threshold { get; set; } = 0;
        public Grade()
        {
            Guid = Guid.NewGuid();
        }
    }
}
