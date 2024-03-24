using QuizApp.Model.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Data
{
    public interface IQuizData
    {
        Quiz LoadQuiz();
        Question LoadQuestion(int id);
        bool SendAnswer(Guid guidQuestion, Guid guidAnswer);
        Result LoadResult();
        bool StartQuiz();
        bool StopQuiz();
        int GetTimerCounter();
    }
}
