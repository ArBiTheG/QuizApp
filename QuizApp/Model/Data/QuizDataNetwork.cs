using QuizApp.Model.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Data
{
    public class QuizDataNetwork : IQuizData
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
