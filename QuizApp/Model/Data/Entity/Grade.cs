using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Data.Entity
{
    public class Grade
    {
        /// <summary>
        /// Уникальный идентификатор оценки
        /// </summary>
        [JsonRequired]
        public Guid Guid { get; set; }

        /// <summary>
        /// Наименование оценки
        /// </summary>
        [JsonRequired]
        public string Name { get; set; }

        /// <summary>
        /// Описание оценки
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Порог баллов для получения указанной оценки
        /// </summary>
        public double Threshold { get; set; } = 0;

        public Grade()
        {
            Guid = Guid.NewGuid();
        }
    }
}
