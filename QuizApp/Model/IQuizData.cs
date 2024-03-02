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
        string Title { get; set; }
        string Description { get; set; }
        Question Question { get; set; }
        string Author { get; set; }
        int MaxQuestions { get; set; }
        int CurrentQuestionId { get; set; }
        void LoadQuiz();
        void LoadQuestion(int id);
        void LoadNextQuestion();
        void LoadPrevQuestion();
        void LoadFirstQuestion();
        void LoadLastQuestion();
        void SelectAnswer(Guid guid);
        Result LoadResult();
        void StartQuiz();
        void StopQuiz();
        int GetTimer();
    }
}
