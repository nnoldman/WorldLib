using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Processor
{
    public class WordTypeFunction
    {
        public string typeName;
        public string functionName;
    }
    public class Word : IBool
    {
        public string content;
        public List<WordTypeFunction> typeFunctions = new List<WordTypeFunction>();

        public virtual bool IsKnown()
        {
            return true;
        }
        public bool IsType(string wordTypeName)
        {
            WordType wordtype = StoreWordType.Get(wordTypeName);
            if(wordtype)
            {
                foreach (var wt in typeFunctions)
                {
                    if (wordtype.IsType(wt.typeName))
                        return true;
                }
            }

            return false;
        }
        public void Clear()
        {
            content = string.Empty;
        }
    }
}
