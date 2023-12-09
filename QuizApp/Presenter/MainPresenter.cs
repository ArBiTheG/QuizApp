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
        private int quizMaxQuestions = 2;
        private int quizCurrentQuestion = 1;
        public IMainView MainView { get; set; }
        public QuizDataModel QuizDataModel { get; set; }

        public int QuizMaxQuestions { get => quizMaxQuestions; }
        public int QuizCurrentQuestion { get => quizCurrentQuestion; }

        public MainPresenter(IMainView mainView) 
        {
            MainView = mainView;
            QuizDataModel = new QuizDataModel();

            MainView.PrepareQuiz += MainView_PrepareQuiz;
            MainView.StartQuiz += MainView_StartQuiz;
            MainView.FinishQuiz += MainView_FinishQuiz;
            MainView.NextQuestion += MainView_NextQuestion;
            MainView.BackQuestion += MainView_BackQuestion;
        }

        private void MainView_BackQuestion(object sender, EventArgs e)
        {
            if (quizCurrentQuestion <= 1) return;

            if (quizCurrentQuestion > 1) --quizCurrentQuestion;
            if (quizCurrentQuestion <= 1)
            {
                MainView.CanBackQuestion = false;
            }
            if (quizCurrentQuestion < quizMaxQuestions)
            {
                MainView.CanNextQuestion = true;
            }

            QuizDataModel.LoadQuestion(quizCurrentQuestion);
            MainView.CurrentQuestion = quizCurrentQuestion;
            MainView.QuestionDescription = QuizDataModel.Question.Description;
        }

        private void MainView_NextQuestion(object sender, EventArgs e)
        {
            if (quizCurrentQuestion >= quizMaxQuestions)
            {
                MainView_FinishQuiz(sender,e);
            };

            if (quizCurrentQuestion < quizMaxQuestions) ++quizCurrentQuestion;
            if (quizCurrentQuestion >= quizMaxQuestions)
            {
                MainView.CanNextQuestion = false;
            }
            if (quizCurrentQuestion > 1)
            {
                MainView.CanBackQuestion = true;
            }

            QuizDataModel.LoadQuestion(quizCurrentQuestion);
            MainView.CurrentQuestion = quizCurrentQuestion;
            MainView.QuestionDescription = QuizDataModel.Question.Description;
        }

        private void MainView_PrepareQuiz(object sender, EventArgs e)
        {
            QuizDataModel.LoadData();
            quizMaxQuestions = QuizDataModel.MaxQuestions;

            MainView.QuizTitle = QuizDataModel.Quiz.Title;
            MainView.QuizDescription = QuizDataModel.Quiz.Description;
            MainView.ChangePage(Page.Prepare);

        }

        private void MainView_StartQuiz(object sender, EventArgs e) 
        { 
            if (QuizDataModel.QuizReady == true)
            {
                QuizDataModel.LoadQuestion(quizCurrentQuestion);
                MainView.CurrentQuestion = quizCurrentQuestion;
                MainView.QuestionDescription = QuizDataModel.Question.Description;
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
