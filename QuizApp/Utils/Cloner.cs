using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Utils
{
    public static class Cloner<T>
    {
        public static T Clone(T obj)
        {
            if (obj is ICloneable)
            {
                return (T)(obj as ICloneable).Clone();
            }
            return obj;
        }
    }
}
