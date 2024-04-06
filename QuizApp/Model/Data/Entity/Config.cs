using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Data.Entity
{
    public class QuizConfig
    {
        /// <summary>
        /// Лимит вопросов
        /// </summary>
        public int QuestionsLimit { get; set; } = 0;

        /// <summary>
        /// Лимит времени 
        /// </summary>
        public int TimerLimit { get; set; } = 0;
    }
}
