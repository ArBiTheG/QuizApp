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
    [JsonObject(MemberSerialization.OptIn)]
    public class Quiz: ICloneable
    {
        /// <summary>
        /// Уникальный идентификатор тестирования
        /// </summary>
        [JsonRequired]
        [JsonProperty("guid")]
        public Guid Guid { get; private set; }

        /// <summary>
        /// Заголовок тестирования
        /// </summary>
        [JsonRequired]
        [JsonProperty("title")]
        public string Title { get; private set; }

        /// <summary>
        /// Описание тестирования
        /// </summary>
        [JsonRequired]
        [JsonProperty("description")]
        public string Description { get; private set; }

        /// <summary>
        /// Автор тестирования
        /// </summary>
        [JsonProperty("author")]
        public string Author { get; private set; }

        /// <summary>
        /// Конфигурация тестирования
        /// </summary>
        [JsonProperty("config")]
        public Config Config { get; private set; }

        /// <summary>
        /// Массив с оценками
        /// </summary>
        [JsonRequired]
        [JsonProperty("grades")]
        public Grade[] Grades { get; private set; }

        /// <summary>
        /// Вопросы к тестированию
        /// </summary>
        [JsonRequired]
        [JsonProperty("questions")]
        public IQuestion[] Questions { get; set; }

        private Quiz()
        {
            Guid = Guid.NewGuid();
        }
        public Quiz(string title, string description, string author, Config config, Grade[] grades, IQuestion[] questions)
        {
            Guid = Guid.NewGuid();
            Title = title;
            Description = description;
            Author = author;
            Config = config;
            Grades = grades;
            Questions = questions;
        }

        [JsonConstructor]
        public Quiz(Guid guid, string title, string description, string author, Config config, Grade[] grades, IQuestion[] questions)
        {
            Guid = guid;
            Title = title;
            Description = description;
            Author = author;
            Config = config;
            Grades = grades;
            Questions = questions;
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
