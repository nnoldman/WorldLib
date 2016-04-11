using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace World.TextProcessor
{
    public class AtomicParameter
    {

    }
    public class Input
    {
        public List<AtomicParameter> parameters = new List<AtomicParameter>();
        public List<Word> wordVecotr;

        public Word GetWord(int index)
        {
            if (wordVecotr != null && wordVecotr.Count > index)
                return wordVecotr[index];
            return null;
        }
    }
}
