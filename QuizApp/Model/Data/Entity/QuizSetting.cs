using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Data.Entity
{
    public class QuizSetting
    {
        public int LimitQuestions { get; set; } = 0;
        public int LimitTimer { get; set; } = 0;
    }
}
