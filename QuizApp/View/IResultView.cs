using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.View
{
    public interface IResultView
    {
        IMainView ParentView { get; set; }
        void Show();
        void Close();

        event EventHandler LoadResult;
        string Guid { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        string Message { get; set; }
        string Author { get; set; }
        string Grade { get; set; }
        string GradeDescr { get; set; }
        string MaxScore { get; set; }
        string Score { get; set; }
        string MaxQuestions { get; set; }
        string RightQuestions { get; set; }
        string TimeStarted { get; set; }
        string TimeFinihed { get; set; }
        string TimePassed { get; set; }
    }
}
