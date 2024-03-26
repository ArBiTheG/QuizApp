using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace QuizApp.Model.Data
{
    public class QuizTimer
    {
        Timer _timer;
        DateTime _timerStarted;
        DateTime _timerFinished;
        int _timerCounter = 0;
        bool _isActive = false;

        public DateTime Started { get => _timerStarted; }
        public DateTime Finished { get => _timerFinished; }
        public int Counter { get => _timerCounter; }
        public bool IsActive { get => _isActive; }
        public QuizTimer() 
        {
            _timer = new Timer();
            _timer.AutoReset = true;
            _timer.Interval = 1000;
            _timer.Elapsed += TimerElapsed;
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
#if DEBUG
            Console.WriteLine("Запущен таймер тестирования...");
#endif
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            _timerCounter++;
#if DEBUG
            Console.WriteLine("Счётчик таймера тестирования: " + _timerCounter);
#endif
        }

        /// <summary>
        /// Остановить таймер
        /// </summary>
        public void Stop()
        {
            _timer.Stop();
            _timerFinished = DateTime.Now;
            _isActive = false;
#if DEBUG
            Console.WriteLine("Таймер тестирования остановлен!");
#endif
        }

    }
}
