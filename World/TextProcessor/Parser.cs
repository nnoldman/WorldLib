using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Processor
{
    public class Parser
    {
        public Phrase Parse(List<Word> words)
        {
            Phrase p = null;

            foreach(var phrase in StorePhrase.getStore)
            {
                if (phrase.Value.Match(words))
                {
                    p = phrase.Value;
                    break;
                }
            }
            return p;
        }
    }
}
