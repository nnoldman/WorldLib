using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    public enum WordPosition
    {
        None,
        Before,
        Behind,
        JointBefore,
        JointBehind,
    }
    public class WordFunction
    {
        public WordPosition postion;
        public string targetWordType;
        public string jointWord;
        public string wordType;

        public string functionName;
        public string method;
    }
}
