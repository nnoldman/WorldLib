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
        public override void ExecuteCmdNativelly(List<Word> wordVecotr)
        {
            AtomicOperationArgment args = new AtomicOperationArgment() { WordVecotr = wordVecotr };
            AtomicOperation.Invoke(AtomicOperation.AddParam, ref args, 1);
            AtomicOperation.Invoke(AtomicOperation.AddParam, ref args, 4);
            AtomicOperation.Invoke(AtomicOperation.AddWord,ref args);
            args.Record(this);
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
        public override void ExecuteCmdNativelly(List<Word> wordVecotr)
        {
            //Linker.Clear();
            //Linker.Invoke(Linker.CacheWordTypeWithWordType, words, 1);
            //Linker.Invoke(Linker.CacheWordTypeAppendWordType, words, 2);
            //Linker.Invoke(Linker.SetCacheWordTypeParent, words, 4);
        }
    }

    [ExpressionElement(wordType = Config.TokenCommandType)]
    [ExpressionElement(wordType = Config.TokenUnknown)]
    [ExpressionElement(wordType = Config.TokenCopula)]
    [ExpressionElement(wordType = Config.TokenWordType)]
    [ExpressionName(Name = "Expression_AddWord")]
    public class Expression_AddWord : ExpressionCmd
    {
        public override void ExecuteCmdNativelly(List<Word> wordVecotr)
        {
            AtomicOperationArgment args = new AtomicOperationArgment() { WordVecotr = wordVecotr };
            AtomicOperation.Invoke(AtomicOperation.AddParam, ref args, 1);
            AtomicOperation.Invoke(AtomicOperation.AddParam, ref args, 3);
            AtomicOperation.Invoke(AtomicOperation.AddWord, ref args);
            args.Record(this);
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
        public override string GenerateAnswerNativelly(List<Word> wordVecotr)
        {
            AtomicOperationArgment args = new AtomicOperationArgment() { WordVecotr = wordVecotr };
            AtomicOperation.Invoke(AtomicOperation.LinkObjectByReplace, ref args, 0);
            AtomicOperation.Invoke(AtomicOperation.LinkWord, ref args, 1);
            AtomicOperation.Invoke(AtomicOperation.LinkObjectName, ref args, 0);
            args.Record(this);
            return args.OutputString.ToString();
        }
    }

    [ExpressionElement(wordType = Config.TokenNoun)]
    [ExpressionElement(wordType = Config.TokenVerb)]
    [ExpressionElement(wordType = Config.TokenNoun)]
    [ExpressionName(Name = "Expression_ZhuWeiBing")]
    public class Expression_ZhuWeiBing : Expression
    {
        public override void ExecuteCmdNativelly(List<Word> wordVecotr)
        {
            //Input input = new Input();
            //AtomicOperation.GetFunc(input);
            //AtomicOperation.PushParam(input);
            //AtomicOperation.PushParam(input);
            //AtomicOperation.Invoke(input);
        }
    }

    [ExpressionElement(wordType = Config.TokenUnknown)]
    [ExpressionElement(wordType = Config.TokenCopula)]
    [ExpressionElement(wordType = Config.TokenNoun)]
    [ExpressionName(Name = "Expression_Define")]
    public class Expression_Define : Expression
    {
    }
}
