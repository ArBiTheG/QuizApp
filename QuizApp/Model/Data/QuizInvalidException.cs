using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Data
{
    internal class QuizInvalidException: Exception
    {
        public QuizInvalidException()
        {
        }

        public QuizInvalidException(string message) : base(message)
        {
        }

        public QuizInvalidException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected QuizInvalidException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
