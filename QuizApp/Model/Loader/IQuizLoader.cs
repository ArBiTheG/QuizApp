using QuizApp.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Loader
{
    public interface IQuizLoader
    {
        Quiz LoadQuiz();
        Question LoadQuestion(int id);
        bool SendAnswer(Guid guidQuestion, Guid guidAnswer);
        Result LoadResult();
        bool StartQuiz();
        bool StopQuiz();

        int GetTimer();
    }
}
