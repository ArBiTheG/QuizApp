using QuizApp.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    public interface IQuizData
    {
        void LoadQuiz();
        void LoadQuestion(int id);
        void SelectAnswer(Guid guid);
        Result LoadResult();
    }
}
