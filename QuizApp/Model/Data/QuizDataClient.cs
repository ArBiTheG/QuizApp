using QuizApp.Model.Data.Entity;
using QuizApp.Utils;
using QuizApp.View.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace QuizApp.Model.Data
{
    public abstract class QuizDataClient: IQuizData
    {
        protected QuizTimer timer = new QuizTimer();
        protected Quiz quiz;

        protected static Question[] SelectionQuestions(Question[] questions, int limit_count = 4)
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
                newQuestion.Answers = SelectionAnswers(oldQuestion.Answers);
                result[id] = newQuestion;
            }
            return result;
        }

        protected static Answer[] SelectionAnswers(Answer[] answers)
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


        /// <summary>
        /// Загрузить викторину
        /// </summary>
        /// <returns>Возвращает экземпляр викторины</returns>
        public virtual Quiz LoadQuiz()
        {
            quiz = new Quiz();
            quiz.Title = "Заголовок тестирования";
            quiz.Description = "Описание тестирования";
            quiz.Author = "Грабовский Д.А.";

            quiz.Setting = new QuizSetting();

            quiz.Grades = new Grade[4];
            quiz.Grades[0] = new Grade() { Title = "5", Description = "Отлично", Threshold = 4 };
            quiz.Grades[1] = new Grade() { Title = "4", Description = "Хорошо", Threshold = 3 };
            quiz.Grades[2] = new Grade() { Title = "3", Description = "Удовлетворительно", Threshold = 1 };
            quiz.Grades[3] = new Grade() { Title = "2", Description = "Неудовлетворительно" };

            quiz.Questions = new Question[5]
            {
                new Question("По своему типу питания медведи...",
                    new Answer[3]
                    {
                        new Answer("мясоеды"),
                        new Answer("всеядны"),
                        new Answer("травоядны"),
                    }, 1),
                new Question("Как назывался особый головной убор, который носили фараоны в Древнем Египте?",
                    new Answer[4]
                    {
                        new Answer("Картуз"),
                        new Answer("Немес"),
                        new Answer("Корона"),
                        new Answer("Убрус")
                    }, 1),
                new Question("У какого животного самые большие глаза относительно тела?",
                    new Answer[4]
                    {
                        new Answer("У лемура"),
                        new Answer("У летучей мыши"),
                        new Answer("У долгопята"),
                        new Answer("У тупайи")
                    }, 2),
                new Question("Цветы какого из этих растений не голубого цвета?",
                    new Answer[4]
                    {
                        new Answer("Василек"),
                        new Answer("Незабудка"),
                        new Answer("Лютик"),
                        new Answer("Цикорий")
                    }, 2),
                new Question("Как называется человек, покоряющий крыши многоэтажных домов?",
                    new Answer[4]
                    {
                        new Answer("Диггер"),
                        new Answer("Сталкер"),
                        new Answer("Руфер"),
                        new Answer("Байкер")
                    }, 2),
            };
            return quiz;
        }
        /// <summary>
        /// Загрузить отчёт о тестировании
        /// </summary>
        /// <returns>Возвращает экземпляр отчёта</returns>
        public virtual Result LoadResult()
        {
            int rightCount = 0;
            int maxQuestionsCount = 0;
            
            double scoreCount = 0;
            double maxScoreCount = 0;
            foreach (Question question in quiz.Questions)
            {
                Answer answer = question.Answers.First((a) => a.Guid == question.RightAnswer);
                if (answer != null)
                {
                    if (answer.Checked)
                    {
                        rightCount++;
                        scoreCount += question.Multiplier;
                    }
                }
                maxScoreCount += question.Multiplier;
                maxQuestionsCount++;
            }
            
            double minThreshold = -1;
            Grade grade = new Grade();
            foreach (Grade s in quiz.Grades)
            {
                if (scoreCount >= s.Threshold &&
                    s.Threshold > minThreshold)
                {
                    minThreshold = s.Threshold;
                    grade = s;
                }
            }
            
            Result result = new Result();
            result.Guid = Guid.NewGuid();
            result.Grade = grade.Title;
            result.GradeDescription = grade.Description;
            result.Score = scoreCount;
            result.MaxScore = maxScoreCount;
            result.RightQuestion = rightCount;
            result.MaxQuestions = maxQuestionsCount;
            result.Message = "Тестирование завершено";
            result.QuizStarted = timer.Started;
            result.QuizFinished = timer.Started;
            result.QuizTimePass = (result.QuizFinished - result.QuizStarted).Seconds;
            
            
            return result;
        }

        /// <summary>
        /// Загрузить вопрос
        /// </summary>
        /// <param name="id">Номер вопроса</param>
        /// <returns>Возвращает экземпляр вопроса</returns>
        public virtual Question LoadQuestion(int id)
        {
            int lastId = quiz.Questions.Length - 1;
            if (id > lastId) id = lastId;
            if (id < 0) id = 0;
            return quiz.Questions[id];
        }

        /// <summary>
        /// Отправить ответ на вопрос
        /// </summary>
        /// <param name="guidQuestion">GUID вопроса</param>
        /// <param name="guidAnswer">GUID выбранного ответа</param>
        /// <returns></returns>
        public virtual bool SendAnswer(Guid guidQuestion, Guid guidAnswer)
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

        /// <summary>
        /// Запустить викторину
        /// </summary>
        /// <returns></returns>
        public bool StartQuiz()
        {
            timer.StartTimer();
            return true;
        }
        /// <summary>
        /// Остановить викторину
        /// </summary>
        /// <returns></returns>
        public bool StopQuiz()
        {
            timer.StopTimer();
            return true;
        }

        /// <summary>
        /// Получить счётчик таймера
        /// </summary>
        /// <returns>Возвращает пройденное время в секундах</returns>
        public int GetTimerCounter()
        {
            return timer.Counter;
        }
    }
}
