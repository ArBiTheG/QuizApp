using QuizApp.Model.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Utils
{
    public static class CalculatorCorrectAnswer
    {
        /// <summary>
        /// Рассчитать правильные варианты ответов
        /// </summary>
        /// <param name="quiz">Объект викторины</param>
        /// <param name="maxQuestions">Максимальное колличество вопросов</param>
        /// <param name="maxQuestionsScore">Максимальное колличество баллов</param>
        /// <param name="correctQuestions">Колличество правильных ответов</param>
        /// <param name="correctQuestionsScore">Колличество набранных баллов с правильных ответов</param>
        public static void Calculate(Quiz quiz, out int maxQuestions, out double maxQuestionsScore, out int correctQuestions, out double correctQuestionsScore)
        {
            maxQuestions = 0;
            maxQuestionsScore = 0;
            correctQuestions = 0;
            correctQuestionsScore = 0;

            foreach (IQuestion question in quiz.Questions)
            {
                if (question is IQuestionAnswerOne)
                {
                    calcCorrectAnswerOne(question as IQuestionAnswerOne, ref correctQuestions, ref correctQuestionsScore);
                }
                else if (question is IQuestionAnswerMany)
                {
                    calcCorrectAnswerMany(question as IQuestionAnswerMany, ref correctQuestions, ref correctQuestionsScore);
                }
                else if (question is IQuestionText)
                {
                    calcCorrectAnswerText(question as IQuestionText, ref correctQuestions, ref correctQuestionsScore);
                }

                maxQuestions++;
                maxQuestionsScore += question.Multiplier;
            }
        }

        private static void calcCorrectAnswerOne(IQuestionAnswerOne question, ref int correctQuestions, ref double correctQuestionsScore)
        {
            Answer answer = question.Answers.First((a) => a.Guid == question.CorrectAnswer);
            if ((bool)(answer?.Checked))
            {
                correctQuestions++;
                correctQuestionsScore += question.Multiplier;
            }
        }

        private static void calcCorrectAnswerMany(IQuestionAnswerMany question, ref int correctQuestions, ref double correctQuestionsScore)
        {
            double maxAnswers = question.CorrectAnswers.Length;
            double correctAnswers = 0;

            foreach (Answer answer in question.Answers)
            {
                bool hasCorrectAnswer = question.CorrectAnswers.Contains(answer.Guid);
                if (hasCorrectAnswer && answer.Checked)
                    correctAnswers += 1;
                else if (!hasCorrectAnswer && answer.Checked)
                    correctAnswers -= 1;
            }

            if (correctAnswers < 0)
                correctAnswers = 0;

            if (correctAnswers == question.CorrectAnswers.Length)
            {
                correctQuestions++;
                correctQuestionsScore += question.Multiplier;
            }
        }

        private static void calcCorrectAnswerText(IQuestionText question, ref int correctQuestions, ref double correctQuestionsScore)
        {
            string selectText = question.SelectText;
            string correctText = question.CorrectText;

            selectText = selectText == null ? "" : selectText;
            correctText = correctText == null ? "" : correctText;

            selectText = selectText.ToLower();
            correctText = correctText.ToLower();

            selectText = selectText.Trim(' ');
            correctText = correctText.Trim(' ');

            if (selectText == correctText)
            {
                correctQuestions++;
                correctQuestionsScore += question.Multiplier;
            }
        }
    }
}
