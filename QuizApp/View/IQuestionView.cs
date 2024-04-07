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
        
        bool CanPrevQuestion { get; set; }
        bool CanNextQuestion { get; set; }
        int CurrentQuestion { get; set; }

        string Description { get; set; }
        IAnswerView[] Answers { get; }
        string AnswerText { get; }
        void CreateAnswerRadioButtons(IAnswerView[] answerView);
        void CreateAnswerCheckBoxes(IAnswerView[] answerView);
        void CreateAnswerTextBox(string textBox);

        void SetDisplayTimer(int time, bool reverse = false);

        bool InvokeRequired { get; }
        object Invoke(Delegate method);
    }
}
