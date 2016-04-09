using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.TextProcessor
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public  class WordTypeName : Attribute
    {
        public string Name;
        public string ParentName;
        public Type type;
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class ExpressionElement : Attribute
    {
        public string wordType = Config.TokenUnknown;
    }
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ExpressionName : Attribute
    {
        public string Name = string.Empty;
    }


    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class Proccessor : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ForwardPropagation : Attribute
    {
    }
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class BackwardPropagation : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class Propagation : Attribute
    {
    }
}
