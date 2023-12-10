using QuizApp.Model;
using QuizApp.Model.Entity;
using QuizApp.View;
using QuizApp.View.Entity;
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
            MainView.SelectAnswer += MainView_SelectAnswer;
        }

        private void MainView_SelectAnswer(object sender, Guid e)
        {
            Answer answer = (QuizDataModel.Question.Answers.Find(obj => obj.Guid == e));
            answer.Checked = true;
        }

        void LoadQuestion()
        {
            QuizDataModel.LoadQuestion(quizCurrentQuestion);

            int answerCount = QuizDataModel.Question.Answers.Count;
            IAnswerView[] answerViews = new IAnswerView[answerCount];
            for (int i = 0; i < answerCount; ++i)
            {
                Answer answer = QuizDataModel.Question.Answers[i];
                answerViews[i] = new AnswerView()
                {
                    Guid = answer.Guid,
                    Content = answer.Description,
                    Checked = answer.Checked
                };
            }
            MainView.AddAnswers(answerViews);

            MainView.CurrentQuestion = quizCurrentQuestion;
            MainView.QuestionDescription = QuizDataModel.Question.Description;
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
            LoadQuestion();
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
            LoadQuestion();
        }

        private void MainView_PrepareQuiz(object sender, EventArgs e)
        {
            QuizDataModel.LoadData();
            quizMaxQuestions = QuizDataModel.MaxQuestions;

            MainView.QuizTitle = QuizDataModel.Title;
            MainView.QuizDescription = QuizDataModel.Description;
            MainView.ChangePage(Page.Prepare);

        }

        private void MainView_StartQuiz(object sender, EventArgs e) 
        { 
            if (QuizDataModel.QuizReady == true)
            {
                LoadQuestion();
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
