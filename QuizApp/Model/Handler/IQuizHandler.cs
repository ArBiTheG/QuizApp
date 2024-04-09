using QuizApp.Model.Data.Entity;
using QuizApp.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Handler
{
    public interface IQuizHandler
    {
        string Title { get; }
        string Description { get; }
        string Author { get; }
        int MaxQuestions { get; }
        int QuestionId { get; }
        IQuestion Question { get; }
        int TimerLimit { get; }

        event EventHandler<QuizTimerEventArgs> QuizStarted;
        event EventHandler<QuizTimerEventArgs> QuizFinished;
        event EventHandler<QuizTimerEventArgs> QuizTimerElapsed;

        IQuestion GetQuestion(int id);
        IQuestion GetNextQuestion();
        IQuestion GetPrevQuestion();
        IQuestion GetFirstQuestion();
        IQuestion GetLastQuestion();
        void SetAnswer(string answer, bool param = true);
        Result GetResult();
        void StartQuiz();
        void StopQuiz();
    }
}
