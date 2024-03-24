using QuizApp.Model;
using QuizApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Presenter
{
    public class PreparePresenter: IPreparePresenter
    {
        public IPrepareView View { get; set; }
        public IQuizModel QuizData { get; set; }

        public PreparePresenter(IPrepareView view, IQuizModel quizData)
        {
            View = view;
            QuizData = quizData;

            View.PrepareQuiz += View_PrepareQuiz;
            View.StartQuiz += View_StartQuiz;

            View.Show();
        }

        private void View_PrepareQuiz(object sender, EventArgs e)
        {

            QuizData.LoadQuiz();
            View.Title = QuizData.Title;
            View.Description = QuizData.Description;
            View.Author = QuizData.Author;
            View.MaxQuestions = QuizData.MaxQuestions.ToString();
            int timer = QuizData.GetTimer();
            if (timer <= 0)
            {
                View.Timer = "Нет";
            }
            else
            {
                View.Timer = TimeSpan.FromSeconds(timer).ToString("hh\\:mm\\:ss");
            }

            (View.ParentView as IMainView).AppStatus = "Тестирование готово";
        }

        private void View_StartQuiz(object sender, EventArgs e)
        {
            (View.ParentView as IMainView).AppStatus = "Запуск тестирования...";

            View.Close();
            IQuestionView view = QuestionForm.GetInstance((MainForm)View.ParentView);
            new QuestionPresenter(view, QuizData);
        }
    }
}
