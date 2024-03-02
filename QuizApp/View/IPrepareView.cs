using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.View
{
    public interface IPrepareView: IView
    {
        event EventHandler PrepareQuiz;
        event EventHandler StartQuiz;
        string Guid { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        string Author { get; set; }
        string MaxQuestions { get; set; }
        string Timer { get; set; }
    }
}
