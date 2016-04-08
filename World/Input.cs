using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace World.TextProcessor
{
    public class Input
    {
        public List<Word> words;

        public Word GetWord(int index)
        {
            if (words != null && words.Count > index)
                return words[index];
            return null;
        }
    }
}
