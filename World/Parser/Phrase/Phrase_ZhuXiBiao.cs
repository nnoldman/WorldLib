using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Object;
using World.Parser.Action;

namespace World.Parser
{
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
        public override void GenerateElement()
        {
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
