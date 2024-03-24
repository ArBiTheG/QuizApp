using QuizApp.Model;
using QuizApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Presenter
{
    public interface IResultPresenter
    {
        IResultView View { get; set; }
        IQuizModel QuizData { get; set; }
    }
}
