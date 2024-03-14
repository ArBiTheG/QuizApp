using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace QuizApp.Model
{
    public class QuizTimer
    {
        private Timer _timer;
        private int _timer_counter = 0;
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
#if DEBUG
                Console.WriteLine("Запущен таймер тестирования...");
#endif
            }
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e)
        {
            _timer_counter++;
#if DEBUG
            Console.WriteLine("Счётчик таймера тестирования: " + _timer_counter);
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
            }
#if DEBUG
            Console.WriteLine("Таймер тестирования остановлен!");
#endif
        }

        /// <summary>
        /// Получить счётчик таймера
        /// </summary>
        /// <returns>Пройдено\осталось времени в секундах</returns>
        public int GetTimerCounter()
        {
            return _timer_counter;
        }
    }
}
