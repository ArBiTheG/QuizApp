using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Data.Entity
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Grade
    {
        /// <summary>
        /// Уникальный идентификатор оценки
        /// </summary>
        [JsonRequired]
        [JsonProperty("guid")]
        public Guid Guid { get; set; }

        /// <summary>
        /// Наименование оценки
        /// </summary>
        [JsonRequired]
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Описание оценки
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// Порог баллов для получения указанной оценки
        /// </summary>
        [JsonProperty("threshold")]
        public double Threshold { get; set; }

        public Grade()
        {
            Guid = Guid.NewGuid();
            Threshold = 0;
        }
    }
}
