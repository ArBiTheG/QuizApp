using QuizApp.Model;
using QuizApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp.Presenter
{
    public class MainPresenter: IMainPresenter
    {
        public IMainView MainView { get; set; }
        public QuizDataModel QuizDataModel { get; set; }
        public MainPresenter(IMainView mainView) 
        {
            MainView = mainView;
            QuizDataModel = new QuizDataModel();

            MainView.PrepareQuiz += MainView_PrepareQuiz;
            MainView.StartQuiz += MainView_StartQuiz;
            MainView.FinishQuiz += MainView_FinishQuiz;
        }


        private void MainView_PrepareQuiz(object sender, EventArgs e)
        {
            QuizDataModel.LoadData();
            MainView.QuizTitle = QuizDataModel.Quiz.Title;
            MainView.QuizDescription = QuizDataModel.Quiz.Description;
            MainView.ChangePage(Page.Prepare);
        }

        private void MainView_StartQuiz(object sender, EventArgs e) 
        { 
            if (QuizDataModel.QuizReady == true)
            {
                MainView.ChangePage(Page.Quiz);
            }
            else
            {
                MessageBox.Show("Невозможно начать тестирование поскольку файл с тестом не найден", "Не удалось загрузить тестирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void MainView_FinishQuiz(object sender, EventArgs e)
        {
            if (QuizDataModel.QuizReady == true)
            {
                MainView.ChangePage(Page.Result);
            }
        }
    }
}
