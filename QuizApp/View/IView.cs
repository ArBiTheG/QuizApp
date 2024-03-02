using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.View
{
    public interface IView
    {
        IView ParentView { get; set; }
        void Show();
        void Close();
    }
}
