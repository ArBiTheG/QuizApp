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
        Question Question { get; }
        string Author { get; }
        int MaxQuestions { get; }
        int CurrentQuestionId { get; }
        int TimerLimit { get; }

        event EventHandler QuizTimerStarted;
        event EventHandler QuizTimerFinished;
        event EventHandler<QuizTimerElapsedEventArgs> QuizTimerElapsed;

        void LoadQuestion(int id);
        void LoadNextQuestion();
        void LoadPrevQuestion();
        void LoadFirstQuestion();
        void LoadLastQuestion();
        void SendReply(params string[] answer);
        Result GetResult();
        void StartQuiz();
        void StopQuiz();
    }
}
