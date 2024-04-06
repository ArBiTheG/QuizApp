using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Data.Entity
{
    public interface IQuestionAnswer: IQuestion
    {
        /// <summary>
        /// Варианты ответов
        /// </summary>
        Answer[] Answers { get; set; }
    }
}
