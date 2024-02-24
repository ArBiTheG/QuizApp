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
    public class QuestionPresenter: IQuestionPresenter
    {
        public IQuestionView View { get; set; }
        public IQuizData QuizData { get; set; }
        public int IdQuestion { get; set; }

        public QuestionPresenter(IQuestionView view, IQuizData quizData)
        {
            View = view;
            QuizData = quizData;
            IdQuestion = 0;

            View.LoadQuiz += View_LoadQuiz;
            View.NextQuestion += View_NextQuestion;
            View.PrevQuestion += View_PrevQuestion;
            View.FinishQuiz += View_FinishQuiz;
            View.SelectAnswer += View_SelectAnswer;

            View.Show();
        }

        private void View_SelectAnswer(object sender, Guid e)
        {
            QuizData.SelectAnswer(e);
        }

        private void View_PrevQuestion(object sender, EventArgs e)
        {
            int last_id = QuizData.MaxQuestions - 1;
            if (IdQuestion <= 0) return;
            
            if (IdQuestion > 0) --IdQuestion;
            if (IdQuestion <= 0)
            {
                View.CanPrevQuestion = false;
            }
            if (IdQuestion < last_id)
            {
                View.CanNextQuestion = true;
            }
            LoadQuestion();
        }

        private void View_NextQuestion(object sender, EventArgs e)
        {
            int last_id = QuizData.MaxQuestions - 1;
            if (IdQuestion >= last_id)
            {
                View_FinishQuiz(sender, e);
            }
            else
            {
                if (IdQuestion < last_id) ++IdQuestion;
                if (IdQuestion >= last_id)
                {
                    View.CanNextQuestion = false;
                }
                if (IdQuestion > 0)
                {
                    View.CanPrevQuestion = true;
                }
                LoadQuestion();
            }
        }

        private void View_LoadQuiz(object sender, EventArgs e)
        {
            if (QuizData.QuizReady)
            {
                QuizData.StartQuiz();
                LoadQuestion();
            }
            else
            {
                MessageBox.Show("Невозможно начать тестирование поскольку файл с тестом не найден", "Не удалось загрузить тестирование", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void View_FinishQuiz(object sender, EventArgs e)
        {
            View.Close();
            IResultView view = ResultForm.GetInstance((MainForm)View.ParentView);
            new ResultPresenter(view, QuizData);
        }

        private void LoadQuestion()
        {
            QuizData.LoadQuestion(IdQuestion);
        
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
            View.AddAnswers(answerViews);

            View.CurrentQuestion = IdQuestion;
            View.Description = QuizData.Question.Description;
        }
    }
}
