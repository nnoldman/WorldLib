using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Object;

namespace World.Processor
{
    [PhraseElement(wordType = Config.TokenNoun)]
    [PhraseElement(wordType = Config.TokenVerb)]
    [PhraseElement(wordType = Config.TokenNoun)]
    public class Phrase_ZhuWeiBing : Phrase
    {
        public SceneObject executer;
        public SceneObject target;
    }
}
