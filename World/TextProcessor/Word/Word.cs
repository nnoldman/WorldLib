using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Processor
{
    public class Word : IBool
    {
        public string content;
        public List<string> function;
        public List<string> wordTypes = new List<string>();

        public virtual bool IsKnown()
        {
            return true;
        }
        public bool IsType(string wordTypeName)
        {
            foreach(var wt in wordTypes)
            {
                if (wt == wordTypeName)
                    return true;
            }
            return false;
        }
        public void Clear()
        {
            content = string.Empty;
        }
    }
}
