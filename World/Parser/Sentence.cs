using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Object;

namespace World.Parser
{
    public class Sentence
    {
        public Purpose type;

        public SceneObject target;
        public SceneObject something;

        public string text;
        public void Parse()
        {
            List<Phrase> phrases = GetPhrases();
            if (phrases.Count == 0)
            {
                Logger.Warning("There seemed to be nothing!");
                return;
            }
            Scene.Instance.Parse(phrases);
        }
        List<Phrase> GetPhrases()
        {
            List<Phrase> phrases = new List<Phrase>();

            Phrase cur = new Phrase();

            for (int i = 0; i < text.Length; ++i)
            {
                char c = text[i];

                cur.builder.Append(c);
                if (IsPunctuation(c))
                {
                    phrases.Add(cur);
                    cur = new Phrase();
                }
            }

            if (cur.builder.Length > 0)
                phrases.Add(cur);

            return phrases;
        }
        bool IsPunctuation(char c)
        {
            for (int i = 0; i < Punctuation.set.Length; ++i)
            {
                if (Punctuation.set[i] == c)
                    return true;
            }
            return false;
        }
    }
}
