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

        event EventHandler QuizTimerStarted;
        event EventHandler QuizTimerFinished;
        event EventHandler<QuizTimerElapsedEventArgs> QuizTimerElapsed;

        Result GetResult();
        void StartQuiz();
        void StopQuiz();
        void DoReply(Guid guid_question, params string[] guid_answers);
    }
}
