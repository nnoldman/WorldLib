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
    [PhraseElement(wordType = Config.TokenCommand)]
    [PhraseElement(wordType = Config.TokenUnknown)]
    [PhraseElement(wordType = Config.TokenSingletonWord)]
    [PhraseElement(wordType = Config.TokenCopula)]
    [PhraseElement(wordType = Config.TokenWordType)]
    [PhraseName(Name = Config.TokenPhrase_Cmd)]
    public class Phrase_AddWordType : PhraseCmd
    {
        public override void ExecuteCmd(List<Word> words)
        {
            WordType wt = new WordType();
            wt.name = words[1].content + Config.TokenSingletonWord;
            wt.parent = words[4].content;
            StoreWordType.Add(wt.name, wt);
        }
    }

    [PhraseElement(wordType = Config.TokenCommand)]
    [PhraseElement(wordType = Config.TokenUnknown)]
    [PhraseElement(wordType = Config.TokenWordType)]
    [PhraseElement(wordType = Config.TokenCopula)]
    [PhraseElement(wordType = Config.TokenWordType)]
    [PhraseName(Name = Config.TokenPhrase_Cmd)]
    public class Phrase_AddWordType1 : PhraseCmd
    {
        public override void ExecuteCmd(List<Word> words)
        {
            WordType wt = new WordType();
            wt.name = words[1].content + Config.TokenSingletonWord;
            wt.parent = words[4].content;
            StoreWordType.Add(wt.name, wt);
        }
    }

    [PhraseElement(wordType = Config.TokenCommand)]
    [PhraseElement(wordType = Config.TokenUnknown)]
    [PhraseElement(wordType = Config.TokenCopula)]
    [PhraseElement(wordType = Config.TokenWordType)]
    [PhraseName(Name = Config.TokenWordType)]
    public class Phrase_AddWord : PhraseCmd
    {
        public override void ExecuteCmd(List<Word> words)
        {
            Nervous.Linker.Clear();
            Nervous.Linker.Invoke(Nervous.Linker.CacheOldWord, words, 1);
            Nervous.Linker.Invoke(Nervous.Linker.AddWordWithCache, words, 3);
        }
    }

    [PhraseElement(wordType = Config.TokenNoun)]
    [PhraseElement(wordType = Config.TokenCopula)]
    [PhraseElement(wordType = Config.TokenPronoun)]
    [PhraseElement(wordType = Config.TokenPunction_WenHao)]
    [PhraseName(Name = Config.TokenPhrase_ZhuXiBiao)]
    public class Phrase_ZhuXiBiao : Phrase
    {
    }
    [PhraseElement(wordType = Config.TokenNoun)]
    [PhraseElement(wordType = Config.TokenCopula)]
    [PhraseElement(wordType = Config.TokenQueryPronoun)]
    [PhraseName(Name = Config.TokenPhrase_ZhuXiBiaoQuery)]
    public class Phrase_ZhuXiBiao_YiWen : Phrase
    {
        public override string GenerateAnswer(List<Word> words)
        {
            Nervous.Linker.Clear();
            Nervous.Linker.Invoke(Nervous.Linker.LinkObjectByReplace, words, 0);
            Nervous.Linker.Invoke(Nervous.Linker.LinkWord, words, 1);
            Nervous.Linker.Invoke(Nervous.Linker.LinkObjectName, words, 0);
            return Nervous.Linker.GetText(); 
        }
    }

    [PhraseElement(wordType = Config.TokenNoun)]
    [PhraseElement(wordType = Config.TokenVerb)]
    [PhraseElement(wordType = Config.TokenNoun)]
    public class Phrase_ZhuWeiBing : Phrase
    {
    }

    [PhraseElement(wordType = Config.TokenUnknown)]
    [PhraseElement(wordType = Config.TokenCopula)]
    [PhraseElement(wordType = Config.TokenNoun)]
    public class Phrase_Define : Phrase
    {
    }
}
