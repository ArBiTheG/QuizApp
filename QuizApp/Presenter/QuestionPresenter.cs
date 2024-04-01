using QuizApp.Model;
using QuizApp.Model.Data;
using QuizApp.Model.Data.Entity;
using QuizApp.View;
using QuizApp.View.Entity;
using System;
using System.Windows.Forms;

namespace QuizApp.Presenter
{
    public class QuestionPresenter : IQuestionPresenter
    {
        public IQuestionView View { get; set; }
        public IQuizModel Model { get; set; }

        public QuestionPresenter(IQuestionView view, IQuizModel quizModel)
        {
            View = view;
            Model = quizModel;

            View.LoadQuiz += View_LoadQuiz;
            View.NextQuestion += View_NextQuestion;
            View.PrevQuestion += View_PrevQuestion;
            View.FinishQuiz += View_FinishQuiz;
            Model.QuizTimerElapsed += Model_QuizTimerElapsed;
            Model.QuizStarted += Model_QuizStarted; ;
            Model.QuizFinished += Model_QuizFinished;

            View.Show();
        }

        private void View_PrevQuestion(object sender, EventArgs e)
        {
            (View.ParentView as IMainView).AppStatus = "Отправляем ответ...";
            SendAnswerForQuestion();
            (View.ParentView as IMainView).AppStatus = "Загрузка вопроса...";
            Model.LoadPrevQuestion();

            int id = Model.CurrentQuestionId;
            int last_id = Model.MaxQuestions - 1;
            if (id <= 0)
            {
                View.CanPrevQuestion = false;
            }
            if (id < last_id)
            {
                View.CanNextQuestion = true;
            }
            RefreshQuestionViewContent();
        }
        private void View_NextQuestion(object sender, EventArgs e)
        {

            int id = Model.CurrentQuestionId;
            int last_id = Model.MaxQuestions - 1;
            if (id >= last_id)
            {
                (View.ParentView as IMainView).AppStatus = "Отправляем ответ...";
                SendAnswerForQuestion();
                (View.ParentView as IMainView).AppStatus = "Завершение тестирования...";
                Model.StopQuiz();
            }
            else
            {
                (View.ParentView as IMainView).AppStatus = "Отправляем ответ...";
                SendAnswerForQuestion();
                (View.ParentView as IMainView).AppStatus = "Загрузка вопроса...";
                Model.LoadNextQuestion();
                id = Model.CurrentQuestionId;

                if (id >= last_id)
                {
                    View.CanNextQuestion = false;
                }
                if (id > 0)
                {
                    View.CanPrevQuestion = true;
                }
                RefreshQuestionViewContent();
            }
        }
        private void View_LoadQuiz(object sender, EventArgs e)
        {
            Model.StartQuiz();
        }
        private void View_FinishQuiz(object sender, EventArgs e)
        {
            (View.ParentView as IMainView).AppStatus = "Отправляем ответ...";
            SendAnswerForQuestion();
            (View.ParentView as IMainView).AppStatus = "Завершение тестирования...";
            Model.StopQuiz();
        }

        private void Model_QuizStarted(object sender, QuizTimerEventArgs e)
        {
            Model.LoadFirstQuestion();
            View.SetDisplayTimer(e.Counter, e.Reverse);
            RefreshQuestionViewContent();
        }
        private void Model_QuizFinished(object sender, EventArgs e)
        {
            if (View.InvokeRequired)
            {
                View.Invoke((MethodInvoker)delegate
                {
                    View.Close();
                    IResultView view = ResultForm.GetInstance((MainForm)View.ParentView);
                    new ResultPresenter(view, Model);
                });
            }
            else
            {
                View.Close();
                IResultView view = ResultForm.GetInstance((MainForm)View.ParentView);
                new ResultPresenter(view, Model);
            }
        }
        private void Model_QuizTimerElapsed(object sender, QuizTimerEventArgs e)
        {
            if (View.InvokeRequired)
            {
                View.Invoke((MethodInvoker)delegate
                {
                    View.SetDisplayTimer(e.Counter, e.Reverse);
                });
            }
            else
            {
                View.SetDisplayTimer(e.Counter, e.Reverse);
            }
        }

        /// <summary>
        /// Отправить ответ на вопрос
        /// </summary>
        private void SendAnswerForQuestion()
        {
            foreach(IAnswerView answer in View.Answers)
            {
                if (answer.Checked == true)
                {
                    Model.SendReply(answer.Guid.ToString());
                }
            }
        }

        /// <summary>
        /// Обновить вопрос с вариантами ответа
        /// </summary>
        private void RefreshQuestionViewContent()
        {
            View.CurrentQuestion = Model.CurrentQuestionId + 1;
            View.Description = Model.Question.Description;

            int answerCount = Model.Question.Answers.Length;
            IAnswerView[] answerViews = new IAnswerView[answerCount];
            for (int i = 0; i < answerCount; ++i)
            {
                Answer answer = Model.Question.Answers[i];
                answerViews[i] = new AnswerView()
                {
                    Guid = answer.Guid,
                    Content = answer.Description,
                    Checked = answer.Checked
                };
            }
            View.CreateAnswerRadioButtons(answerViews);

            (View.ParentView as IMainView).AppStatus = string.Format("Всего вопросов: {0} | Текущий вопрос: {1}{2}",
                Model.MaxQuestions,
                Model.CurrentQuestionId + 1,
                (Model.MaxQuestions == Model.CurrentQuestionId + 1) ? " | Последний вопрос" : "");
        }

    }
}
