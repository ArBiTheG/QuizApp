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
        public IQuizModel Model { get; set; }

        public ResultPresenter(IResultView view, IQuizModel quizData)
        {
            View = view;
            Model = quizData;
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
            Result result = Model.Quiz.GetResult();
            View.Title = Model.Quiz.Title;
            View.Description = Model.Quiz.Description;
            View.Author = Model.Quiz.Author;
            View.Message = result.Message;
            View.Grade = result.Grade;
            View.GradeDescr = result.GradeDescription;
            View.MaxScore = result.MaxScore.ToString("f1"); ;
            View.Score = result.Score.ToString("f1");
            View.MaxQuestions = result.MaxQuestions.ToString();
            View.RightQuestions = result.RightQuestion.ToString();
            View.TimeStarted = result.QuizStarted.ToString("HH\\:mm\\:ss\\,f");
            View.TimeFinihed = result.QuizFinished.ToString("HH\\:mm\\:ss\\,f");
            View.TimePassed = result.QuizTimePass.ToString("hh\\:mm\\:ss");

            (View.ParentView as IMainView).AppStatus = string.Format("Тестирование завершено за {0:hh\\:mm\\:ss}, оценка {1}",
                result.QuizTimePass, 
                result.Grade);
        }
    }
}
