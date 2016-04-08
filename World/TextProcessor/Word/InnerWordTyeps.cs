using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.TextProcessor
{
    [WordTypeName(Name = Config.TokenCommand)]
    public class WordType_Cmd : WordType
    {
    }

    [WordTypeName(Name = Config.TokenSingletonWord, ParentName = Config.TokenNoun)]
    public class WordType_KeyWord : WordType
    {
    }

    [WordTypeName(Name = Config.TokenWordType, ParentName = Config.TokenNoun)]
    public class WordType_WrodType : WordType
    {
    }

    [WordTypeName(Name = Config.TokenPronoun, ParentName = Config.TokenNoun)]
    public class WordType_Pronoun : WordType
    {
    }
    [WordTypeName(Name = Config.TokenQueryPronoun, ParentName = Config.TokenPronoun)]
    public class WordType_QueryPronoun : WordType
    {
    }

    [WordTypeName(Name = Config.TokenAdjitive)]
    public class WordType_Adjitive : WordType
    {
    }

    [WordTypeName(Name = Config.TokenAdverb)]
    public class WordType_Adverb : WordType
    {
    }

    [WordTypeName(Name = Config.TokenNoun)]
    public class WordType_Noun : WordType
    {
    }

    [WordTypeName(Name = Config.TokenNumber)]
    public class WordType_Number : WordType
    {
    }
    [WordTypeName(Name = Config.TokenPreposition)]
    public class WordType_Preposition : WordType
    {
    }


    [WordTypeName(Name = Config.TokenVerb)]
    public class WordType_Verb : WordType
    {
    }

    [WordTypeName(Name = Config.TokenCopula, ParentName = Config.TokenVerb)]
    public class WordType_Copula : WordType_Verb
    {
    }

    [WordTypeName(Name = Config.TokenPassivity, ParentName = Config.TokenVerb)]
    public class WordType_Passivity : WordType_Verb
    {
    }
}
