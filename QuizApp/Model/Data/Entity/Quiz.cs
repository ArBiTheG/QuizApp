using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuizApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace QuizApp.Model.Data.Entity
{
    public class Quiz: ICloneable
    {
        /// <summary>
        /// Уникальный идентификатор тестирования
        /// </summary>
        [JsonRequired]
        public Guid Guid { get; set; }

        /// <summary>
        /// Заголовок тестирования
        /// </summary>
        [JsonRequired]
        public string Title { get; set; }

        /// <summary>
        /// Описание тестирования
        /// </summary>
        [JsonRequired]
        public string Description { get; set; }

        /// <summary>
        /// Автор тестирования
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// Конфигурация тестирования
        /// </summary>
        public QuizConfig Config { get; set; }

        /// <summary>
        /// Массив с оценками
        /// </summary>
        [JsonRequired]
        public Grade[] Grades { get; set; }

        /// <summary>
        /// Вопросы к тестированию
        /// </summary>
        [JsonRequired]
        public Question[] Questions { get; set; }
        public Quiz()
        {
            Guid = Guid.NewGuid();
        }
        public Quiz(string title, string description)
        {
            Guid = Guid.NewGuid();
            Title = title;
            Description = description;
        }

        public object Clone()
        {
#if DEBUG
            Console.WriteLine("Clone: " + ToString() + " / Guid: " + Guid);
#endif
            return new Quiz()
            {
                Guid = Guid,
                Title = Title,
                Description = Description,
                Author = Author,
                Config = Config,
                Grades = Grades,
                Questions = Questions,
            };

        }
    }
}
