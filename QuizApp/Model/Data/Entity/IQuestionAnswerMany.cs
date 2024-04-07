using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Data.Entity
{
    public interface IQuestionAnswerMany: IQuestionAnswer
    {
        /// <summary>
        /// Правильные ответы - определяет идентификаторы нескольких правильных ответов на вопрос
        /// </summary>
        Guid[] CorrectAnswers { get; set; }
    }
}
