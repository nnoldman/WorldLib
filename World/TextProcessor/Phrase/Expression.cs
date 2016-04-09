using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Object;

namespace World.TextProcessor
{
    public class ExpressionCmd : Expression
    {
        public override bool IsCmd()
        {
            return true;
        }
    }
    [ExpressionElement(wordType = Config.TokenCommandType)]
    [ExpressionElement(wordType = Config.TokenUnknown)]
    [ExpressionElement(wordType = Config.TokenSingletonWord)]
    [ExpressionElement(wordType = Config.TokenCopula)]
    [ExpressionElement(wordType = Config.TokenWordType)]
    [ExpressionName(Name = "Expression_AddWordType")]
    public class Expression_AddWordType : ExpressionCmd
    {
        public override void ExecuteCmd(List<Word> words)
        {
            Linker.Clear();
            Linker.Invoke(Linker.CacheWordTypeWithSingleWord, words, 1);
            Linker.Invoke(Linker.SetCacheWordTypeParent, words, 4);
        }
    }

    [ExpressionElement(wordType = Config.TokenCommandType)]
    [ExpressionElement(wordType = Config.TokenUnknown)]
    [ExpressionElement(wordType = Config.TokenWordType)]
    [ExpressionElement(wordType = Config.TokenCopula)]
    [ExpressionElement(wordType = Config.TokenWordType)]
    [ExpressionName(Name = "Expression_AddWordType1")]
    public class Expression_AddWordType1 : ExpressionCmd
    {
        public override void ExecuteCmd(List<Word> words)
        {
            Linker.Clear();
            Linker.Invoke(Linker.CacheWordTypeWithWordType, words, 1);
            Linker.Invoke(Linker.CacheWordTypeAppendWordType, words, 2);
            Linker.Invoke(Linker.SetCacheWordTypeParent, words, 4);
        }
    }

    [ExpressionElement(wordType = Config.TokenCommandType)]
    [ExpressionElement(wordType = Config.TokenUnknown)]
    [ExpressionElement(wordType = Config.TokenCopula)]
    [ExpressionElement(wordType = Config.TokenWordType)]
    [ExpressionName(Name = "Expression_AddWord")]
    public class Expression_AddWord : ExpressionCmd
    {
        public override void ExecuteCmd(List<Word> words)
        {
            Linker.Clear();
            Linker.Invoke(Linker.CacheOldWord, words, 1);
            Linker.Invoke(Linker.AddWordWithCache, words, 3);
        }
    }

    [ExpressionElement(wordType = Config.TokenNoun)]
    [ExpressionElement(wordType = Config.TokenCopula)]
    [ExpressionElement(wordType = Config.TokenPronoun)]
    [ExpressionElement(wordType = Config.TokenPunction_WenHao)]
    [ExpressionName(Name = "Expression_ZhuXiBiao")]
    public class Expression_ZhuXiBiao : Expression
    {
    }
    [ExpressionElement(wordType = Config.TokenNoun)]
    [ExpressionElement(wordType = Config.TokenCopula)]
    [ExpressionElement(wordType = Config.TokenQueryPronoun)]
    [ExpressionName(Name = "Expression_ZhuXiBiao_YiWen")]
    public class Expression_ZhuXiBiao_YiWen : Expression
    {
        public override string GenerateAnswer(List<Word> words)
        {
            Linker.Clear();
            Linker.Invoke(Linker.LinkObjectByReplace, words, 0);
            Linker.Invoke(Linker.LinkWord, words, 1);
            Linker.Invoke(Linker.LinkObjectName, words, 0);
            return Linker.GetText(); 
        }
    }

    [ExpressionElement(wordType = Config.TokenNoun)]
    [ExpressionElement(wordType = Config.TokenVerb)]
    [ExpressionElement(wordType = Config.TokenNoun)]
    [ExpressionName(Name = "Expression_ZhuWeiBing")]
    public class Expression_ZhuWeiBing : Expression
    {
    }

    [ExpressionElement(wordType = Config.TokenUnknown)]
    [ExpressionElement(wordType = Config.TokenCopula)]
    [ExpressionElement(wordType = Config.TokenNoun)]
    [ExpressionName(Name = "Expression_Define")]
    public class Expression_Define : Expression
    {
    }
}
