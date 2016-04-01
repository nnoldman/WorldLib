using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Parser
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public  class WordTypeName : Attribute
    {
        public string Name;
        public Type type;
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class PhraseElement : Attribute
    {
        public string wordType;
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public  class PhraseElementNull : Attribute
    {
        public bool CanNullAll;
    }
}
