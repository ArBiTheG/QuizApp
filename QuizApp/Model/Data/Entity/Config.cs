using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Data.Entity
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Config
    {
        /// <summary>
        /// Уникальный идентификатор ответа
        /// </summary>
        [JsonRequired]
        [JsonProperty("guid")]
        public Guid Guid { get; set; }

        /// <summary>
        /// Лимит вопросов
        /// </summary>
        [JsonProperty("question_limit")]
        public int QuestionsLimit { get; set; }

        /// <summary>
        /// Лимит времени 
        /// </summary>
        [JsonProperty("time_limit")]
        public int TimerLimit { get; set; }

        public Config()
        {
            Guid = Guid.NewGuid();
            QuestionsLimit = 0;
            TimerLimit = 0;
        }
    }
}
