using QuizApp.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Loader
{
    public class QuizLoaderNetwork : IQuizLoader
    {
        public Quiz LoadQuiz()
        {
            throw new NotImplementedException();
        }

        public Question LoadQuestion(int id)
        {
            throw new NotImplementedException();
        }

        public Result LoadResult()
        {
            throw new NotImplementedException();
        }

        public bool SendAnswer(Guid guidQuestion, Guid guidAnswer)
        {
            throw new NotImplementedException();
        }

        public bool StartQuiz()
        {
            throw new NotImplementedException();
        }

        public int GetTimerCounter()
        {
            throw new NotImplementedException();
        }

        public bool StopQuiz()
        {
            throw new NotImplementedException();
        }
    }
}
