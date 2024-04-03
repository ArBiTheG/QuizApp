using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Data.Entity
{
    public class Answer : ICloneable
    {
        /// <summary>
        /// Уникальный идентификатор ответа
        /// </summary>
        [JsonRequired]
        public Guid Guid { get; set; }

        /// <summary>
        /// Текст ответа на вопрос
        /// </summary>
        [JsonRequired]
        public string Text { get; set; }

        /// <summary>
        /// Выделенный
        /// </summary>
        [JsonIgnore]
        public bool Checked { get; set; }

        public Answer()
        {
            Guid = Guid.NewGuid();
        }
        public Answer(string text)
        {
            Guid = Guid.NewGuid();
            Text = text;
        }
        public object Clone()
        {
#if DEBUG
            Console.WriteLine("Clone: " + ToString() + " / Guid: " + Guid);
#endif
            return new Answer()
            {
                Guid = Guid,
                Text = Text,
                Checked= Checked
            };
        }
        public bool IsValidated()
        {
            if (!string.IsNullOrEmpty(Text))
            {
                return true;
            }
            return false;
        }
    }
}
