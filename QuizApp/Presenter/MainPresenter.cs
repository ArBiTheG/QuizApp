using QuizApp.Model;
using QuizApp.Model.Data.Entity;
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
        public IMainView View { get; set; }
        public IQuizModel Model { get; set; }

        public MainPresenter(IMainView mainView) 
        {
            View = mainView;
            Model = new QuizModel();
            View.AppLoad += View_AppLoad;
            View.AppExit += View_AppExit;
            View.AppAbout += View_AppAbout;
        }

        private void View_AppLoad(object sender, EventArgs e)
        {
            View.AppStatus = "Подготовка тестирования...";

            IPrepareView view = PrepareForm.GetInstance((MainForm)View);
            new PreparePresenter(view, Model);
        }
        private void View_AppExit(object sender, EventArgs e)
        {

            View.Close();
        }
        private void View_AppAbout(object sender, EventArgs e)
        {
            using (AboutBox form = new AboutBox())
            {
                form.ShowDialog();
            }
        }
    }
}
