using QuizApp.Model;
using QuizApp.Model.Data.Entity;
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
        public IQuizModel QuizData { get; set; }

        public ResultPresenter(IResultView view, IQuizModel quizData)
        {
            View = view;
            QuizData = quizData;
            View.LoadResult += View_LoadResult;
            View.AppExit += View_Exit;
            View.Show();
        }

        private void View_Exit(object sender, EventArgs e)
        {
            View.ParentView.Close();
        }

        private void View_LoadResult(object sender, EventArgs e)
        {
            Result result = QuizData.LoadResult();
            View.Title = QuizData.Title;
            View.Description = QuizData.Description;
            View.Author = QuizData.Author;
            View.Message = result.Message;
            View.Grade = result.Grade;
            View.GradeDescr = result.GradeDescription;
            View.MaxScore = result.MaxScore.ToString("f1"); ;
            View.Score = result.Score.ToString("f1");
            View.MaxQuestions = result.MaxQuestions.ToString();
            View.RightQuestions = result.RightQuestion.ToString();
            View.TimeStarted = result.QuizStarted.ToString("HH\\:mm\\:ss");
            View.TimeFinihed = result.QuizFinished.ToString("HH\\:mm\\:ss");
            TimeSpan timeSpan = TimeSpan.FromSeconds(result.QuizTimePass);
            View.TimePassed = string.Format("{0} час. {1} мин. {2} сек.", timeSpan.Hours, timeSpan.Minutes, timeSpan.TotalSeconds);

            (View.ParentView as IMainView).AppStatus = string.Format("Тестирование завершено за {0:hh\\:mm\\:ss}, оценка {1}", 
                timeSpan, 
                result.Grade);
        }
    }
}
