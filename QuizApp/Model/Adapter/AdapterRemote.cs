using QuizApp.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Adapter
{
    public class AdapterRemote : IAdapter
    {
        public Quiz Connect()
        {
            throw new NotImplementedException();
        }

        public Question GetQuestion(int id)
        {
            throw new NotImplementedException();
        }

        public int CheckQuiz()
        {
            throw new NotImplementedException();
        }
    }
}
