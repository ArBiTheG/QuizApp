using QuizApp.Model.Data;
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
        string Title { get; }
        string Description { get; }
        IQuestion Question { get; }
        string Author { get; }
        int MaxQuestions { get; }
        int CurrentQuestionId { get; }
        int TimerLimit { get; }

        event EventHandler<QuizTimerEventArgs> QuizStarted;
        event EventHandler QuizFinished;
        event EventHandler<QuizTimerEventArgs> QuizTimerElapsed;

        void LoadQuestion(int id);
        void LoadNextQuestion();
        void LoadPrevQuestion();
        void LoadFirstQuestion();
        void LoadLastQuestion();
        void SendAnswer(string answer, bool param = true);
        Result GetResult();
        void StartQuiz();
        void StopQuiz();
    }
}
