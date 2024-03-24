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
        private Timer _timer;
        private DateTime _timerStarted;
        private DateTime _timerFinished;
        private int _timerCounter = 0;

        public DateTime Started { get => _timerStarted; }
        public DateTime Finished { get => _timerFinished; }
        public int Counter { get => _timerCounter; }
        public QuizTimer() 
        {
        }
        /// <summary>
        /// Запустить таймер
        /// </summary>
        public void StartTimer()
        {
            if (_timer == null)
            {
                _timer = new Timer();
                _timer.AutoReset = true;
                _timer.Interval = 1000;
                _timer.Elapsed += TimerElapsed;
                _timer.Start();

                _timerStarted = DateTime.Now;
                _timerFinished = DateTime.Now;
#if DEBUG
                Console.WriteLine("Запущен таймер тестирования...");
#endif
            }
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
        public void StopTimer()
        {
            if (_timer != null)
            {
                _timer.Stop();
                _timer = null;

                _timerFinished = DateTime.Now;
            }
#if DEBUG
            Console.WriteLine("Таймер тестирования остановлен!");
#endif
        }

    }
}
