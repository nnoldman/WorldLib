using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Processor
{
    [WordTypeName(Name = Config.TokenPronoun, ParentName = Config.TokenNoun)]
    public class WordType_Pronoun : WordType
    {
    }
    [WordTypeName(Name = Config.TokenQueryPronoun, ParentName = Config.TokenPronoun)]
    public class WordType_QueryPronoun : WordType
    {
    }
}
