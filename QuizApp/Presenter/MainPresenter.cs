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
        private int quizCurQuestion;

        public MainPresenter(IMainView mainView) 
        {
            MainView = mainView;
            QuizData = new QuizData();
            quizCurQuestion = 1;

            MainView.PrepareQuiz += MainView_PrepareQuiz;
            MainView.StartQuiz += MainView_StartQuiz;
            MainView.FinishQuiz += MainView_FinishQuiz;
            MainView.NextQuestion += MainView_NextQuestion;
            MainView.PrevQuestion += MainView_BackQuestion;
            MainView.SelectAnswer += MainView_SelectAnswer;
        }
        public IMainView MainView { get; set; }
        public IQuizData QuizData { get; set; }
        public int QuizCurQuestion { get => quizCurQuestion;  }

        private void MainView_SelectAnswer(object sender, Guid e)
        {
            QuizData.SelectAnswer(e);
        }

        private void MainView_BackQuestion(object sender, EventArgs e)
        {
            if (quizCurQuestion <= 1) return;

            if (quizCurQuestion > 1) --quizCurQuestion;
            if (quizCurQuestion <= 1)
            {
                MainView.CanPrevQuestion = false;
            }
            if (quizCurQuestion < QuizData.MaxQuestions)
            {
                MainView.CanNextQuestion = true;
            }
            LoadQuestion();
        }

        private void MainView_NextQuestion(object sender, EventArgs e)
        {
            if (quizCurQuestion >= QuizData.MaxQuestions)
            {
                MainView_FinishQuiz(sender,e);
            }
            else
            {
                if (quizCurQuestion < QuizData.MaxQuestions) ++quizCurQuestion;
                if (quizCurQuestion >= QuizData.MaxQuestions)
                {
                    MainView.CanNextQuestion = false;
                }
                if (quizCurQuestion > 1)
                {
                    MainView.CanPrevQuestion = true;
                }
                LoadQuestion();
            }
        }

        private void MainView_PrepareQuiz(object sender, EventArgs e)
        {
            QuizData.LoadQuiz();

            MainView.QuizTitle = QuizData.Title;
            MainView.QuizDescription = QuizData.Description;
            MainView.QuizAuthor = QuizData.Author;
            MainView.QuizMaxQuestions = QuizData.MaxQuestions;
            MainView.ChangePage(Page.Prepare);
        }

        private void MainView_StartQuiz(object sender, EventArgs e) 
        { 
            if (QuizData.QuizReady)
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
            if (QuizData.QuizReady)
            {
                LoadResult();
                MainView.ChangePage(Page.Result);
            }
        }
        private void LoadQuestion()
        {
            QuizData.LoadQuestion(quizCurQuestion);

            int answerCount = QuizData.Question.Answers.Length;
            IAnswerView[] answerViews = new IAnswerView[answerCount];
            for (int i = 0; i < answerCount; ++i)
            {
                Answer answer = QuizData.Question.Answers[i];
                answerViews[i] = new AnswerView()
                {
                    Guid = answer.Guid,
                    Content = answer.Description,
                    Checked = answer.Checked
                };
            }
            MainView.AddAnswers(answerViews);

            MainView.CurrentQuestion = quizCurQuestion;
            MainView.QuestionDescription = QuizData.Question.Description;
        }

        private void LoadResult()
        {
            QuizData.LoadResult();
        }
    }
}
