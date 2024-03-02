using QuizApp.Model;
using QuizApp.Model.Entity;
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
        public IQuizData QuizData { get; set; }

        public QuestionPresenter(IQuestionView view, IQuizData quizData)
        {
            View = view;
            QuizData = quizData;

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
            (View.ParentView as IMainView).AppStatus = "Загрузка вопроса...";

            QuizData.LoadPrevQuestion();

            int id = QuizData.CurrentQuestionId;
            int last_id = QuizData.MaxQuestions - 1;
            if (id <= 0)
            {
                View.CanPrevQuestion = false;
            }
            if (id < last_id)
            {
                View.CanNextQuestion = true;
            }
            RefreshQuestion();
        }

        private void View_NextQuestion(object sender, EventArgs e)
        {
            (View.ParentView as IMainView).AppStatus = "Загрузка вопроса...";

            int id = QuizData.CurrentQuestionId;
            int last_id = QuizData.MaxQuestions - 1;
            if (id >= last_id)
            {
                View_FinishQuiz(sender, e);
            }
            else
            {
                QuizData.LoadNextQuestion();
                id = QuizData.CurrentQuestionId;

                if (id >= last_id)
                {
                    View.CanNextQuestion = false;
                }
                if (id > 0)
                {
                    View.CanPrevQuestion = true;
                }
                RefreshQuestion();
            }
        }

        private void View_LoadQuiz(object sender, EventArgs e)
        {
            QuizData.StartQuiz();
            RefreshQuestion();
            ChangeTimer(0);
            StartThreadListenTimer();
        }

        private void View_FinishQuiz(object sender, EventArgs e)
        {
            (View.ParentView as IMainView).AppStatus = "Завершение тестирования...";

            QuizData.StopQuiz();
            StopThreadListenTimer();

            View.Close();
            IResultView view = ResultForm.GetInstance((MainForm)View.ParentView);
            new ResultPresenter(view, QuizData);
        }

        private void RefreshQuestion()
        {
            View.CurrentQuestion = QuizData.CurrentQuestionId + 1;
            View.Description = QuizData.Question.Description;

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

            (View.ParentView as IMainView).AppStatus = string.Format("Всего вопросов: {0} | Текущий вопрос: {1}{2}",
                QuizData.MaxQuestions,
                QuizData.CurrentQuestionId + 1,
                (QuizData.MaxQuestions == QuizData.CurrentQuestionId + 1) ? " | Последний вопрос" : "");
        }


        private Thread thread;
        private void StartThreadListenTimer()
        {
            SynchronizationContext sync = SynchronizationContext.Current;
            thread = new Thread(CheckTimer);
            thread.Name = "Listen Server Timer";
            thread.IsBackground = true;
            thread.Start(sync);
        }
        private void StopThreadListenTimer()
        {
            thread.Abort();
        }
        private void CheckTimer(object state)
        {
            SynchronizationContext sync = state as SynchronizationContext;
            while (true)
            {
                int old_timer = 0;
                int new_timer = QuizData.GetTimer();
                if (old_timer != new_timer)
                {
                    sync.Post((object st) => ChangeTimer((int)st), new_timer);
                }
                Thread.Sleep(100);
            }
        }
        private void ChangeTimer(int time,bool reverse = false)
        {
            string text;
            if (!reverse)
                text = "Прошло: " + TimeSpan.FromSeconds(time).ToString("hh\\:mm\\:ss");
            else
                text = "Осталось: " + TimeSpan.FromSeconds(time).ToString("hh\\:mm\\:ss");
            View.Timer = text;
        }
    }
}
