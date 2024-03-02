using QuizApp.View.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.View
{
    public interface IMainView: IView
    {
        event EventHandler AppLoad;
        event EventHandler AppExit;
        event EventHandler AppAbout;
        string AppStatus { get; set; }
    }
}
