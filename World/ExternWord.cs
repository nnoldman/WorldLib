using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Processor;

namespace GameData
{
    public class ExternWord : GameData<ExternWord>
    {
        static public readonly string fileName = "xml/ExternWord";
        public string content;

        public List<WordTypeFunction> wordTypes = new List<WordTypeFunction>();
    }
}
