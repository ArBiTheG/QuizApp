using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.View.Entity
{
    public class AnswerView : IAnswerView
    {

        public Guid Guid { get; set; }
        public string Content { get; set ; }
        public bool Checked { get; set; }
    }
}
