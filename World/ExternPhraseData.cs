using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.TextProcessor;

namespace GameData
{
    public class ExternPhraseData : GameData<ExternPhraseData>
    {
        static public readonly string fileName = "xml/ExternPhraseData";
        public List<string> elements;
        public string name;
    }
}
