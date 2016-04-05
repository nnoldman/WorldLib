using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Processor;

namespace GameData
{
    public class ExternPhrase : GameData<ExternPhrase>
    {
        static public readonly string fileName = "xml/ExternPhrase";
        public string content;
    }
}
