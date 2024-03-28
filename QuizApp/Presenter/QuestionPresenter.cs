using QuizApp.Model;
using QuizApp.Model.Data;
using QuizApp.Model.Data.Entity;
using QuizApp.View;
using QuizApp.View.Entity;
using System;

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
            View.SelectAnswer += View_SelectAnswer;
            Model.QuizTimerElapsed += Model_QuizTimerElapsed;

            View.Show();
        }

        private void Model_QuizTimerElapsed(object sender, QuizTimerElapsedEventArgs e)
        {
            View.SetDisplayTimer(e.Counter);
        }

        private void View_SelectAnswer(object sender, Guid e)
        {
            Model.SendReply(e.ToString());
        }

        private void View_PrevQuestion(object sender, EventArgs e)
        {
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
            (View.ParentView as IMainView).AppStatus = "Загрузка вопроса...";

            int id = Model.CurrentQuestionId;
            int last_id = Model.MaxQuestions - 1;
            if (id >= last_id)
            {
                DoFinishQuiz();
            }
            else
            {
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

            RefreshQuestionViewContent();
            View.SetDisplayTimer(0);
        }

        private void View_FinishQuiz(object sender, EventArgs e)
        {
            DoFinishQuiz();
        }

        private void DoFinishQuiz()
        {
            (View.ParentView as IMainView).AppStatus = "Завершение тестирования...";

            Model.StopQuiz();

            View.Close();
            IResultView view = ResultForm.GetInstance((MainForm)View.ParentView);
            new ResultPresenter(view, Model);
        }

        /// <summary>
        /// Обновить содержимое вопроса
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
            View.AddAnswers(answerViews);

            (View.ParentView as IMainView).AppStatus = string.Format("Всего вопросов: {0} | Текущий вопрос: {1}{2}",
                Model.MaxQuestions,
                Model.CurrentQuestionId + 1,
                (Model.MaxQuestions == Model.CurrentQuestionId + 1) ? " | Последний вопрос" : "");
        }

    }
}
