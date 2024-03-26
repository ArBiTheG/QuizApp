using QuizApp.Model;
using QuizApp.Model.Data.Entity;
using QuizApp.View;
using QuizApp.View.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace QuizApp.Presenter
{
    public class QuestionPresenter : IQuestionPresenter
    {
        public IQuestionView View { get; set; }
        public IQuizModel QuizModel { get; set; }

        public QuestionPresenter(IQuestionView view, IQuizModel quizModel)
        {
            View = view;
            QuizModel = quizModel;

            View.LoadQuiz += View_LoadQuiz;
            View.NextQuestion += View_NextQuestion;
            View.PrevQuestion += View_PrevQuestion;
            View.FinishQuiz += View_FinishQuiz;
            View.SelectAnswer += View_SelectAnswer;

            View.Show();
        }

        private void View_SelectAnswer(object sender, Guid e)
        {
            QuizModel.DoReply(e.ToString());
        }

        private void View_PrevQuestion(object sender, EventArgs e)
        {
            (View.ParentView as IMainView).AppStatus = "Загрузка вопроса...";

            QuizModel.LoadPrevQuestion();

            int id = QuizModel.CurrentQuestionId;
            int last_id = QuizModel.MaxQuestions - 1;
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

            int id = QuizModel.CurrentQuestionId;
            int last_id = QuizModel.MaxQuestions - 1;
            if (id >= last_id)
            {
                DoFinishQuiz();
            }
            else
            {
                QuizModel.LoadNextQuestion();
                id = QuizModel.CurrentQuestionId;

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
            QuizModel.StartQuiz();
            StartTimerListen();

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

            QuizModel.StopQuiz();
            _isTimerListenStarted = false;

            View.Close();
            IResultView view = ResultForm.GetInstance((MainForm)View.ParentView);
            new ResultPresenter(view, QuizModel);
        }

        /// <summary>
        /// Обновить содержимое вопроса
        /// </summary>
        private void RefreshQuestionViewContent()
        {
            View.CurrentQuestion = QuizModel.CurrentQuestionId + 1;
            View.Description = QuizModel.Question.Description;

            int answerCount = QuizModel.Question.Answers.Length;
            IAnswerView[] answerViews = new IAnswerView[answerCount];
            for (int i = 0; i < answerCount; ++i)
            {
                Answer answer = QuizModel.Question.Answers[i];
                answerViews[i] = new AnswerView()
                {
                    Guid = answer.Guid,
                    Content = answer.Description,
                    Checked = answer.Checked
                };
            }
            View.AddAnswers(answerViews);

            (View.ParentView as IMainView).AppStatus = string.Format("Всего вопросов: {0} | Текущий вопрос: {1}{2}",
                QuizModel.MaxQuestions,
                QuizModel.CurrentQuestionId + 1,
                (QuizModel.MaxQuestions == QuizModel.CurrentQuestionId + 1) ? " | Последний вопрос" : "");
        }

        #region Прослушивание таймера из Model
        private bool _isTimerListenStarted = false;
        private async void StartTimerListen()
        {
            _isTimerListenStarted = true;
#if DEBUG
            Console.WriteLine("Запуск прослушивания таймера тестирования...");
#endif
            int old_timer = -1;
            int new_timer = 0;
            while (_isTimerListenStarted)
            {
                new_timer = QuizModel.TimerCounter;
                if (new_timer != old_timer)
                {
                    old_timer = new_timer;
                    View.SetDisplayTimer(new_timer);
                }
                await Task.Delay(100);
            }
#if DEBUG
            Console.WriteLine("Прослушивания таймера тестирования остановлено!");
#endif
        }
        #endregion
    }
}
