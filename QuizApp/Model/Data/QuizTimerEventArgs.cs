using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Data
{
    public class QuizTimerEventArgs : EventArgs
    {
        QuizTimer _quizTimer;
        public int Counter { get => _quizTimer.Counter; }
        public bool Reverse { get => _quizTimer.IsReverse; }
        public QuizTimerEventArgs(QuizTimer quizTimer)
        {
            _quizTimer = quizTimer;
        }
    }
}
