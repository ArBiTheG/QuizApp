using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Model.Utils
{
    internal class QuizSerializationBinder : ISerializationBinder
    {
        public IList<Type> Types { get; private set; }
        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = null;
            typeName = serializedType.Name;
        }

        public Type BindToType(string assemblyName, string typeName)
        {
            return Types.SingleOrDefault(t => t.Name == typeName);
        }
        public QuizSerializationBinder(IList<Type> types)
        {
            Types = types;
        }
    }
}
