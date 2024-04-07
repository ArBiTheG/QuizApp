using Newtonsoft.Json;
using System;

namespace QuizApp.Model.Data.Entity
{
    public interface IQuestion : ICloneable
    {
        /// <summary>
        /// Уникальный идентификатор вопроса
        /// </summary>
        Guid Guid { get; set; }

        /// <summary>
        /// Заголовок вопроса
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Описание вопроса
        /// </summary>
        string Description { get; set; }

        /// <summary>
        /// Вес вопроса - определяет множитель полученных очков за правильный ответ на вопрос
        /// </summary>
        double Multiplier { get; set; }
        /// <summary>
        /// Способ ответа на вопрос
        /// </summary>
        //AnswerQuestionType AnswerQuestionType { get; set; }

        bool IsValidated();
    }
}
