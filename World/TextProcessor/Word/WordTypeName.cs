using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Processor
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public  class WordTypeName : Attribute
    {
        public string Name;
        public string ParentName;
        public Type type;
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class PhraseElement : Attribute
    {
        public string wordType = Config.TokenUnknown;
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class PhraseName : Attribute
    {
        public string Name = string.Empty;
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public  class PhraseElementNull : Attribute
    {
        public bool CanNullAll;
    }
}
