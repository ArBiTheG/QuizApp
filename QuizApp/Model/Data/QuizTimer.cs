using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace QuizApp.Model.Data
{
    public class QuizTimer: IQuizTimer
    {
        Timer _timer;
        QuizTimerEventArgs _elapsedEventArgs;
        DateTime _timerStarted;
        DateTime _timerFinished;
        int _timerCounter = 0;
        bool _isActive = false;
        bool _isReverse = false;

        public DateTime Started { get => _timerStarted; }
        public DateTime Finished { get => _timerFinished; }
        public int Counter { get => _timerCounter; }
        public bool IsActive { get => _isActive; }
        public bool IsReverse { get => _isReverse; }

        public event EventHandler<QuizTimerEventArgs> ElapseStarted;
        public event EventHandler ElapseFinished;
        public event EventHandler<QuizTimerEventArgs> Elapsed;
        public QuizTimer(int left_time = 0) 
        {
            _timer = new Timer();
            _timer.AutoReset = true;
            _timer.Interval = 1000;
            _timer.Elapsed += TimerElapsed;

            _elapsedEventArgs = new QuizTimerEventArgs(this);

            _timerCounter = left_time;
            if (left_time>0)
            {
                _isReverse = true;
            }
        }
        /// <summary>
        /// Запустить таймер
        /// </summary>
        public void Start()
        {
            _timer.Start();
            _timerStarted = DateTime.Now;
            _timerFinished = DateTime.Now;
            _isActive = true;
            ElapseStarted?.Invoke(this, _elapsedEventArgs);
#if DEBUG
            Console.WriteLine("Запущен таймер тестирования...");
#endif
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
#if DEBUG
            Console.WriteLine("Счётчик таймера тестирования: " + _timerCounter);
#endif
            if (!_isReverse)
            {
                _timerCounter++;
            }
            else
            {
                if (_timerCounter > 1)
                {
                    _timerCounter--;
                }
                else
                {
                    Stop();
                    return;
                }

            }
            Elapsed?.Invoke(this, _elapsedEventArgs);
        }

        /// <summary>
        /// Остановить таймер
        /// </summary>
        public void Stop()
        {
            _timer.Stop();
            _timerFinished = DateTime.Now;
            _isActive = false;
            ElapseFinished?.Invoke(this, EventArgs.Empty);
#if DEBUG
            Console.WriteLine("Таймер тестирования остановлен!");
#endif
        }

    }
}
