using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Data.Entity
{
    public class Result
    {
        public Guid Guid { get; set; }
        public string Grade { get; set; }
        public string GradeDescription { get; set; }
        public string Message { get; set; }
        public double Score { get; set; }
        public double MaxScore { get; set; }
        public int RightQuestion { get; set; }
        public int MaxQuestions { get; set; }
        public DateTime QuizStarted { get; set; }
        public DateTime QuizFinished { get; set; }
        public int QuizTimePass { get; set; }
    }
}
