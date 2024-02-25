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

        protected static List<Question> ScatterQuestions(List<Question> questions, int count = 4)
        {
            List<Question> result = new List<Question>();
            if (questions != null)
            {

                if (questions.Count > 0)
                {
                    int maxCount = questions.Count;

                    if (count <= 0 || count > maxCount) count = maxCount;

                    int[] busyIds = new int[maxCount];
                    //Забиваем массив порядковыми числами 
                    for (int id = 0; id < busyIds.Length; ++id)
                    {
                        busyIds[id] = id;
                    }
                    //Выполняем перемешивание
                    Shuffler.Shuffle(busyIds);

                    //Отспекаем первые count вопросы
                    for (int id = 0; id < count; ++id)
                    {
                        Question oldQuestion = questions[busyIds[id]];
                        Question newQuestion = (Question)oldQuestion.Clone();
                        newQuestion.Answers = ScatterAnswers(oldQuestion.Answers);
                        result.Add(newQuestion);
                    }
                }
            }
            return result;
        }

        protected static Answer[] ScatterAnswers(Answer[] answers)
        {
            int[] busyIds = new int[answers.Length];
            Answer[] result = new Answer[answers.Length];

            //Забиваем массив порядковыми числами 
            for (int id = 0; id < busyIds.Length; ++id)
            {
                busyIds[id] = id;
            }
            //Выполняем перемешивание
            Shuffler.Shuffle(busyIds);

            for (int id = 0; id < busyIds.Length; ++id)
            {
                result[id] = (Answer)answers[busyIds[id]].Clone();
            }
            return result;
        }

        public Question LoadQuestion(int id)
        {
            int lastId = quiz.Questions.Count - 1;
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
