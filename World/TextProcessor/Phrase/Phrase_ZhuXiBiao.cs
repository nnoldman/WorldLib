using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Object;

namespace World.Processor
{
    public class PhraseCmd : Phrase
    {
    }
    [PhraseElement(wordType = Config.TokenUnknown)]
    [PhraseElement(wordType = Config.TokenCopula)]
    [PhraseName(Name = Config.TokenPhrase_Cmd)]
    public class Phrase_AddWord : PhraseCmd
    {
        public void Growing()
        {
            SceneObject obj = Scene.Instance.GetObject(mWordRoot.word.content);
            Feedback_Description desc = new Feedback_Description();
            desc.executer = obj;
        }
    }

    [PhraseElement(wordType = Config.TokenNoun)]
    [PhraseElement(wordType = Config.TokenCopula)]
    [PhraseElement(wordType = Config.TokenPronoun)]
    [PhraseElement(wordType = Config.TokenPunction_WenHao)]
    [PhraseName(Name = Config.TokenPhrase_ZhuXiBiao)]
    public class Phrase_ZhuXiBiao : Phrase
    {
        public SceneObject executer;
        public SceneObject target;
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
            Nervous.Linker.Invoke(Nervous.Linker.AddObjectByReplace, words, 0);
            Nervous.Linker.Invoke(Nervous.Linker.SetAction, words, 1);
            Nervous.Linker.Invoke(Nervous.Linker.LinkObjectName, words, 0);
            return Nervous.Linker.GetText(); 
        }
        public override Feedback GetFeedback()
        {
            SceneObject obj = Scene.Instance.GetObject(mWordRoot.word.content);
            Feedback_Description desc = new Feedback_Description();
            desc.executer = obj;
            return desc;
        }
    }
}
