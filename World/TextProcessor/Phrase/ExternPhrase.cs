using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Processor
{
    public class ExternPhrase : Phrase
    {
        public void Init(GameData.ExternPhraseData data)
        {
            if (data.elements != null)
            {
                mElements = new List<PhraseElement>();
                foreach (var ele in data.elements)
                {
                    PhraseElement element = new PhraseElement();
                    element.wordType = ele;
                    mElements.Add(element);
                }
            }
        }
    }
}
