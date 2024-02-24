using QuizApp.Model;
using QuizApp.Model.Entity;
using QuizApp.View;
using QuizApp.View.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp.Presenter
{
    public class MainPresenter: IMainPresenter
    {
        //private int quizCurQuestion;

        public MainPresenter(IMainView mainView) 
        {
            View = mainView;
            QuizData = new QuizData();
            View.AppLoad += View_AppLoad;
        }

        public IMainView View { get; set; }
        public IQuizData QuizData { get; set; }

        private void View_AppLoad(object sender, EventArgs e)
        {
            IPrepareView view = PrepareForm.GetInstance((MainForm)View);
            new PreparePresenter(view, QuizData);
        }
    }
}
