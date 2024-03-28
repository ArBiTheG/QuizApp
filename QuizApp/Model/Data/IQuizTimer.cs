using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Data
{
    public interface IQuizTimer
    {
        DateTime Started { get; }
        DateTime Finished { get; }
        int Counter { get; }
        bool IsActive { get; }

        event EventHandler ElapseStarted;
        event EventHandler ElapseFinished;
        event EventHandler<QuizTimerElapsedEventArgs> Elapsed;
    }
}
