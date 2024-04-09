using QuizApp.Model;
using QuizApp.Model.Handler;
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
            Model.Quiz.QuizTimerElapsed += Model_QuizTimerElapsed;
            Model.Quiz.QuizStarted += Model_QuizStarted; ;
            Model.Quiz.QuizFinished += Model_QuizFinished;

            View.Show();
        }

        private void View_PrevQuestion(object sender, EventArgs e)
        {
            (View.ParentView as IMainView).AppStatus = "Отправляем ответ...";
            SendAnswerForQuestion();
            (View.ParentView as IMainView).AppStatus = "Загрузка вопроса...";
            Model.Quiz.GetPrevQuestion();

            int id = Model.Quiz.QuestionId;
            int last_id = Model.Quiz.MaxQuestions - 1;
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

            int id = Model.Quiz.QuestionId;
            int last_id = Model.Quiz.MaxQuestions - 1;
            if (id >= last_id)
            {
                (View.ParentView as IMainView).AppStatus = "Отправляем ответ...";
                SendAnswerForQuestion();
                (View.ParentView as IMainView).AppStatus = "Завершение тестирования...";
                Model.Quiz.StopQuiz();
            }
            else
            {
                (View.ParentView as IMainView).AppStatus = "Отправляем ответ...";
                SendAnswerForQuestion();
                (View.ParentView as IMainView).AppStatus = "Загрузка вопроса...";
                Model.Quiz.GetNextQuestion();
                id = Model.Quiz.QuestionId;

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
            Model.Quiz.StartQuiz();
        }
        private void View_FinishQuiz(object sender, EventArgs e)
        {
            (View.ParentView as IMainView).AppStatus = "Отправляем ответ...";
            SendAnswerForQuestion();
            (View.ParentView as IMainView).AppStatus = "Завершение тестирования...";
            Model.Quiz.StopQuiz();
        }

        private void Model_QuizStarted(object sender, QuizTimerEventArgs e)
        {
            Model.Quiz.GetFirstQuestion();
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
            if (Model.Quiz.Question is IQuestionAnswer)
            {
                foreach (IAnswerView answer in View.Answers)
                {
                    Model.Quiz.SetAnswer(answer.Guid.ToString(), answer.Checked);
                }
            }
            else if (Model.Quiz.Question is IQuestionText)
            {
                Model.Quiz.SetAnswer(View.AnswerText);
            }
        }

        /// <summary>
        /// Обновить вопрос с вариантами ответа
        /// </summary>
        private void RefreshQuestionViewContent()
        {
            View.CurrentQuestion = Model.Quiz.QuestionId + 1;
            View.Description = Model.Quiz.Question.Description;

            if (Model.Quiz.Question is IQuestionAnswer)
            {
                IAnswerView[] answerViews = CreateAnswerViews(Model.Quiz.Question as IQuestionAnswer);
                if (Model.Quiz.Question is IQuestionAnswerOne)
                    View.CreateAnswerRadioButtons(answerViews);
                else if (Model.Quiz.Question is IQuestionAnswerMany)
                    View.CreateAnswerCheckBoxes(answerViews);
            }
            else if (Model.Quiz.Question is IQuestionText)
            {
                View.CreateAnswerTextBox((Model.Quiz.Question as IQuestionText).SelectText);
            }

            (View.ParentView as IMainView).AppStatus = string.Format("Всего вопросов: {0} | Текущий вопрос: {1}{2}",
                Model.Quiz.MaxQuestions,
                Model.Quiz.QuestionId + 1,
                (Model.Quiz.MaxQuestions == Model.Quiz.QuestionId + 1) ? " | Последний вопрос" : "");
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
