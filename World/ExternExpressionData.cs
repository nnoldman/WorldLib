using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.TextProcessor;

namespace GameData
{
    public class ExternExpressionData : GameData<ExternExpressionData>
    {
        static public readonly string fileName = "xml/ExternExpressionData";
        public List<string> elements;
        public string name;
    }
}
