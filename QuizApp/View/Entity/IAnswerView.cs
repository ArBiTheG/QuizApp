using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.View.Entity
{
    public interface IAnswerView
    {
        Guid Guid { get; set; }
        string Content { get; set; }
        bool Checked { get; set; }
    }
}
