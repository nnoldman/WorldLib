using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Object;
using World.Processor.Action;

namespace World.Processor
{
    [PhraseElement(wordType = Config.TokenNoun)]
    [PhraseElement(wordType = Config.TokenCopula)]
    [PhraseElement(wordType = Config.TokenEverything)]
    public class Phrase_Cmd : Phrase
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
    public class Phrase_ZhuXiBiao : Phrase
    {
        public SceneObject executer;
        public SceneObject target;
    }
    [PhraseElement(wordType = Config.TokenNoun)]
    [PhraseElement(wordType = Config.TokenCopula)]
    [PhraseElement(wordType = Config.TokenQueryPronoun)]
    public class Phrase_ZhuXiBiao_YiWen : Phrase
    {
        public override Feedback GetFeedback()
        {
            SceneObject obj = Scene.Instance.GetObject(mWordRoot.word.content);
            Feedback_Description desc = new Feedback_Description();
            desc.executer = obj;
            return desc;
        }
    }
}
