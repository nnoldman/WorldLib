using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.TextProcessor
{
    public  class WordType : IBool
    {
        public string name;
        public string parent;

        WordType parentType
        {
            get
            {
                if (string.IsNullOrEmpty(parent))
                    return null;
                return StoreWordType.Get(parent);
            }
        }
        public static bool TypeIsType(string name,string typeName)
        {
            WordType wt = StoreWordType.Get(typeName);
            if (!wt)
                return false;
            return wt.IsType(name);
        }
        public bool IsType(string name)
        {
            if (this.name == name)
                return true;
            WordType parentType = this.parentType;
            if (parentType)
                return parentType.IsType(name);
            else
                return false;
        }
    }
}
