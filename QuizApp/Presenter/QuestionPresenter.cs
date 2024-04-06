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
            if (Model.Question is IQuestionAnswer)
            {
                foreach (IAnswerView answer in View.Answers)
                {
                    Model.SendAnswer(answer.Guid.ToString(), answer.Checked);
                }
            }
            else if (Model.Question is IQuestionText)
            {
                Model.SendAnswer(View.AnswerText);
            }
        }

        /// <summary>
        /// Обновить вопрос с вариантами ответа
        /// </summary>
        private void RefreshQuestionViewContent()
        {
            View.CurrentQuestion = Model.CurrentQuestionId + 1;
            View.Description = Model.Question.Description;

            if (Model.Question is IQuestionAnswer)
            {
                IAnswerView[] answerViews = CreateAnswerViews(Model.Question as IQuestionAnswer);
                if (Model.Question is IQuestionAnswerOne)
                    View.CreateAnswerRadioButtons(answerViews);
                else if (Model.Question is IQuestionAnswerMany)
                    View.CreateAnswerCheckBoxes(answerViews);
            }
            else if (Model.Question is IQuestionText)
            {
                View.CreateAnswerTextBox((Model.Question as IQuestionText).SelectText);
            }

            (View.ParentView as IMainView).AppStatus = string.Format("Всего вопросов: {0} | Текущий вопрос: {1}{2}",
                Model.MaxQuestions,
                Model.CurrentQuestionId + 1,
                (Model.MaxQuestions == Model.CurrentQuestionId + 1) ? " | Последний вопрос" : "");
        }
        private IAnswerView[] CreateAnswerViews(IQuestionAnswer question)
        {
            int answerCount = question.Answers.Length;
            IAnswerView[] result = new IAnswerView[answerCount];
            for (int i = 0; i < answerCount; ++i)
            {
                Answer answer = question.Answers[i];
                result[i] = new AnswerView()
                {
                    Guid = answer.Guid,
                    Content = answer.Text,
                    Checked = answer.Checked
                };
            }
            return result;
        } 

    }
}
