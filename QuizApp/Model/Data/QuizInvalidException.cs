using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Data
{
    internal class QuizInvalidException: Exception
    {
        public QuizInvalidException() { }
        public QuizInvalidException(string message) : base(message) { }
    }
}
