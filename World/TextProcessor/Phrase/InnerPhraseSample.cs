using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Object;

namespace World.TextProcessor
{
    public class PhraseCmd : Phrase
    {
        public override bool IsCmd()
        {
            return true;
        }
    }
    [PhraseElement(wordType = Config.TokenCommandType)]
    [PhraseElement(wordType = Config.TokenUnknown)]
    [PhraseElement(wordType = Config.TokenSingletonWord)]
    [PhraseElement(wordType = Config.TokenCopula)]
    [PhraseElement(wordType = Config.TokenWordType)]
    [PhraseName(Name = "Phrase_AddWordType")]
    public class Phrase_AddWordType : PhraseCmd
    {
        public override void ExecuteCmd(List<Word> words)
        {
            Linker.Clear();
            Linker.Invoke(Linker.CacheWordTypeWithSingleWord, words, 1);
            Linker.Invoke(Linker.SetCacheWordTypeParent, words, 4);
        }
    }

    [PhraseElement(wordType = Config.TokenCommandType)]
    [PhraseElement(wordType = Config.TokenUnknown)]
    [PhraseElement(wordType = Config.TokenWordType)]
    [PhraseElement(wordType = Config.TokenCopula)]
    [PhraseElement(wordType = Config.TokenWordType)]
    [PhraseName(Name = "Phrase_AddWordType1")]
    public class Phrase_AddWordType1 : PhraseCmd
    {
        public override void ExecuteCmd(List<Word> words)
        {
            Linker.Clear();
            Linker.Invoke(Linker.CacheWordTypeWithWordType, words, 1);
            Linker.Invoke(Linker.CacheWordTypeAppendWordType, words, 2);
            Linker.Invoke(Linker.SetCacheWordTypeParent, words, 4);
        }
    }

    [PhraseElement(wordType = Config.TokenCommandType)]
    [PhraseElement(wordType = Config.TokenUnknown)]
    [PhraseElement(wordType = Config.TokenCopula)]
    [PhraseElement(wordType = Config.TokenWordType)]
    [PhraseName(Name = "Phrase_AddWord")]
    public class Phrase_AddWord : PhraseCmd
    {
        public override void ExecuteCmd(List<Word> words)
        {
            Linker.Clear();
            Linker.Invoke(Linker.CacheOldWord, words, 1);
            Linker.Invoke(Linker.AddWordWithCache, words, 3);
        }
    }

    [PhraseElement(wordType = Config.TokenNoun)]
    [PhraseElement(wordType = Config.TokenCopula)]
    [PhraseElement(wordType = Config.TokenPronoun)]
    [PhraseElement(wordType = Config.TokenPunction_WenHao)]
    [PhraseName(Name = "Phrase_ZhuXiBiao")]
    public class Phrase_ZhuXiBiao : Phrase
    {
    }
    [PhraseElement(wordType = Config.TokenNoun)]
    [PhraseElement(wordType = Config.TokenCopula)]
    [PhraseElement(wordType = Config.TokenQueryPronoun)]
    [PhraseName(Name = "Phrase_ZhuXiBiao_YiWen")]
    public class Phrase_ZhuXiBiao_YiWen : Phrase
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

    [PhraseElement(wordType = Config.TokenNoun)]
    [PhraseElement(wordType = Config.TokenVerb)]
    [PhraseElement(wordType = Config.TokenNoun)]
    [PhraseName(Name = "Phrase_ZhuWeiBing")]
    public class Phrase_ZhuWeiBing : Phrase
    {
    }

    [PhraseElement(wordType = Config.TokenUnknown)]
    [PhraseElement(wordType = Config.TokenCopula)]
    [PhraseElement(wordType = Config.TokenNoun)]
    [PhraseName(Name = "Phrase_Define")]
    public class Phrase_Define : Phrase
    {
    }
}
