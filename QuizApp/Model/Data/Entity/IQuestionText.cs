using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Data.Entity
{
    public interface IQuestionText: IQuestion
    {
        /// <summary>
        /// Введенный ответ пользователем
        /// </summary>
        string SelectText { get; set; }
        /// <summary>
        /// Произвольный правильный ответ - определяет текст для правильного ответа на вопрос
        /// </summary>
        string CorrectText { get; set; }
    }
}
