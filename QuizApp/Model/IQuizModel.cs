using QuizApp.Model.Handler;
using QuizApp.Model.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    public interface IQuizModel
    {
        IQuizHandler Quiz { get; }
    }
}
