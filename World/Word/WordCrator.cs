using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Processor;

namespace World
{
    public enum PostionType
    {
        Before,
        Behind,
        Between,
    }
    public class WordCrator
    {
        public Word word;
        public WordType wordType;
        public PostionType postion;
        public string wordTypeName;
        public string function;
        public Word MakeWith(Word word)
        {
            WordType wt = StoreWordType.Get(this.wordTypeName);
            Word w = new Word();
            w.content = postion == PostionType.Before ? this.word.content + word.content : word.content + this.word.content;
            //w.typeFunctions.Add(wordTypeName);
            StoreWord.Add(w.content, w);
            return w;
        }
        public void AddTypeToStore()
        {
            WordType wt = StoreWordType.Get(this.wordTypeName);
            if (wt)
                return;
            wt = new WordType();
            wt.name = this.wordTypeName;
            StoreWordType.Add(this.wordTypeName, wt);
        }
    }
}
