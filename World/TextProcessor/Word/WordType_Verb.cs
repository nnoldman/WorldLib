using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Processor
{
    [WordTypeName(Name = Config.TokenVerb)]
    public  class WordType_Verb : WordType
    {
    }

    [WordTypeName(Name = Config.TokenCopula)]
    public  class WordType_Copula : WordType_Verb
    {
    }

    [WordTypeName(Name = Config.TokenPassivity)]
    public class WordType_Passivity : WordType_Verb
    {
    }
}
