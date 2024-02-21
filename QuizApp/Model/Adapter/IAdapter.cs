using QuizApp.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Adapter
{
    public interface IAdapter
    {
        Quiz Connect();
        Question GetQuestion(int id);
        Result CheckQuiz();
    }
}
