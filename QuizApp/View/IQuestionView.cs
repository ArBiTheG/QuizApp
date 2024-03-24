using QuizApp.View.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.View
{
    public interface IQuestionView: IView
    {
        event EventHandler LoadQuiz;
        event EventHandler FinishQuiz;
        event EventHandler PrevQuestion;
        event EventHandler NextQuestion;
        event EventHandler<Guid> SelectAnswer;
        
        bool CanPrevQuestion { get; set; }
        bool CanNextQuestion { get; set; }
        int CurrentQuestion { get; set; }

        string Description { get; set; }
        void AddAnswers(IAnswerView[] answerView);

        void SetDisplayTimer(int time, bool reverse = false);
    }
}
