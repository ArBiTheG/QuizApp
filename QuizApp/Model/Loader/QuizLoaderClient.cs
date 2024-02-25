using QuizApp.Model.Entity;
using QuizApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace QuizApp.Model.Loader
{
    public abstract class QuizLoaderClient
    {
        // Всё для таймера
        private Timer timer;
        private int timer_count = 0;

        protected Quiz quiz;
        protected DateTime quizStarted;
        protected DateTime quizFinished;

        protected static Question[] ScatterQuestions(Question[] questions, int limit_count = 4)
        {
            int all_count = questions.Length;
            int[] busyIds = new int[all_count];
            for (int id = 0; id < busyIds.Length; ++id)
            {
                busyIds[id] = id;
            }
            //Выполняем перемешивание
            Shuffler.Shuffle(busyIds);

            //Создание границ между максимальным количеством вопросов и установленным лимитом вопросов
            if (limit_count <= 0 || limit_count > all_count) limit_count = all_count;

            //Отспекаем первые  вопросы
            Question[] result = new Question[limit_count];
            for (int id = 0; id < limit_count; ++id)
            {
                Question oldQuestion = questions[busyIds[id]];
                Question newQuestion = (Question)oldQuestion.Clone();
                newQuestion.Answers = ScatterAnswers(oldQuestion.Answers);
                result[id] = newQuestion;
            }
            return result;
        }

        protected static Answer[] ScatterAnswers(Answer[] answers)
        {
            int all_count = answers.Length;
            int[] busyIds = new int[all_count];
            for (int id = 0; id < busyIds.Length; ++id)
            {
                busyIds[id] = id;
            }
            //Выполняем перемешивание
            Shuffler.Shuffle(busyIds);

            Answer[] result = new Answer[all_count];
            for (int id = 0; id < busyIds.Length; ++id)
            {
                result[id] = (Answer)answers[busyIds[id]].Clone();
            }
            return result;
        }

        public Question LoadQuestion(int id)
        {
            int lastId = quiz.Questions.Length - 1;
            if (id > lastId) id = lastId;
            if (id < 0) id = 0;

            return quiz.Questions[id];
        }

        public bool SendAnswer(Guid guidQuestion, Guid guidAnswer)
        {
            Question question = quiz.Questions.First(q => q.Guid == guidQuestion);
            foreach (Answer a in question.Answers)
            {
                if (a.Guid == guidAnswer)
                {
                    a.Checked = true;
                }
                else
                {
                    a.Checked = false;
                }
            }
            return true;
        }

        public bool StartQuiz()
        {
            quizStarted = DateTime.Now;
            StartTimer();
            return true;
        }
        public bool StopQuiz()
        {
            quizFinished = DateTime.Now;
            StopTimer();
            return true;
        }

        public int GetTimer()
        {
            return timer_count;
        }

        private void StartTimer()
        {
            if (timer == null)
            {
                timer = new Timer();
                timer.AutoReset = true;
                timer.Interval = 1000;
                timer.Elapsed += (s, e) =>
                {
                    timer_count++;
                    Console.WriteLine("TimerTest: " + timer_count);
                };
                timer.Start();
            }
        }

        private void StopTimer()
        {
            if (timer != null)
            {
                timer.Stop();
                timer = null;
            }
        }

    }
}
