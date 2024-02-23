using QuizApp.View.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.View
{
    public enum Page
    {
        None,
        Prepare,
        Quiz,
        Result,
    }
    public interface IMainView
    {
        void ChangePage(Page pageFlags);
        event EventHandler PrepareQuiz;
        event EventHandler StartQuiz;
        event EventHandler FinishQuiz;
        event EventHandler PrevQuestion;
        event EventHandler NextQuestion;
        event EventHandler<Guid> SelectAnswer;

        bool CanPrevQuestion { get; set; }
        bool CanNextQuestion { get; set; }
        int CurrentQuestion { get; set; }

        string QuizGuid { get; set; }
        string QuizTitle { get; set; }
        string QuizDescription { get; set; }
        string QuizAuthor { get; set; }
        int QuizMaxQuestions { get; set; }

        string QuestionDescription { get; set; }
        string AppStatus { get; set; }

        void AddAnswers(IAnswerView[] answerView);
    }
}
