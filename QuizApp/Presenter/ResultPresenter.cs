using QuizApp.Model;
using QuizApp.Model.Entity;
using QuizApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizApp.Presenter
{
    public class ResultPresenter: IResultPresenter
    {
        public IResultView View { get; set; }
        public IQuizData QuizData { get; set; }

        public ResultPresenter(IResultView view, IQuizData quizData)
        {
            View = view;
            QuizData = quizData;
            View.LoadResult += View_LoadResult;
            View.Show();
        }

        private void View_LoadResult(object sender, EventArgs e)
        {
            if (QuizData.QuizReady)
            {
                Result result = QuizData.LoadResult();
                View.Title = QuizData.Title;
                View.Description = QuizData.Description;
                View.Author = QuizData.Author;
                View.Message = result.Message;
                View.Grade = result.Title;
                View.GradeDescr = result.Description;
                View.MaxScore = result.MaxScore.ToString("f1"); ;
                View.Score = result.Score.ToString("f1");
                View.MaxQuestions = result.MaxQuestions.ToString();
                View.RightQuestions = result.RightQuestion.ToString();
                View.TimeStarted = result.QuizStarted.ToString("HH\\:mm\\:ss");
                View.TimeFinihed = result.QuizFinished.ToString("HH\\:mm\\:ss");
                TimeSpan timeSpan = TimeSpan.FromSeconds(result.QuizTimePass);
                View.TimePassed = string.Format("{0} час. {1} мин. {2} сек.", timeSpan.Hours, timeSpan.Minutes, timeSpan.TotalSeconds);
            }
        }
    }
}
