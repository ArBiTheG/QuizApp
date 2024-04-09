using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Handler
{
    public interface IQuizTimer
    {
        DateTime Started { get; }
        DateTime Finished { get; }
        TimeSpan Passed { get; }
        int Counter { get; }
        bool IsActive { get; }

        event EventHandler<QuizTimerEventArgs> ElapseStarted;
        event EventHandler<QuizTimerEventArgs> ElapseFinished;
        event EventHandler<QuizTimerEventArgs> Elapsed;
    }
}
