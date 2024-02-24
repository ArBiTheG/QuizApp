using QuizApp.View.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.View
{
    public enum Page
    {
        None,
        Prepare,
        Quiz,
        Result,
    }
    public interface IMainView
    {
        event EventHandler AppLoad;
        string AppStatus { get; set; }
    }
}
