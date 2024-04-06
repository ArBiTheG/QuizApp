using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Data.Entity
{
    public interface IQuestionAnswerOne: IQuestionAnswer
    {
        /// <summary>
        /// Правильный ответ - определяет идентификатор одного правильного ответа на вопрос
        /// </summary>
        Guid CorrectAnswer { get; set; }
    }
}
