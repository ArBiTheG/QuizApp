using QuizApp.Model.Data;
using QuizApp.Model.Handler;
using QuizApp.Model.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    public class QuizModel: IQuizModel
    {
        IQuizHandler _quizHandler;
        public IQuizHandler Quiz { get => _quizHandler; }
        public QuizModel()
        {
            IQuizData data = new QuizDataJson("text.json");
            _quizHandler = new QuizHandler( data.CreateQuiz() );
        }
    }
}
