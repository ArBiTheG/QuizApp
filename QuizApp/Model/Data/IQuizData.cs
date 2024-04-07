using QuizApp.Model.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Data
{
    public interface IQuizData
    {
        Quiz Quiz { get; }

        event EventHandler<QuizTimerEventArgs> QuizTimerStarted;
        event EventHandler QuizTimerFinished;
        event EventHandler<QuizTimerEventArgs> QuizTimerElapsed;

        Result GetResult();
        void StartQuiz();
        void StopQuiz();
        void SendAnswer(Guid guid_question, string answer, bool stage = true);
    }
}
