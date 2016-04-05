using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Processor
{
    public class IStore<TKey, TValue>
    {
        public static Dictionary<TKey, TValue> getStore
        {
            get
            {
                return mStore;
            }
        }
        protected static Dictionary<TKey, TValue> mStore = new Dictionary<TKey, TValue>();
        public static void Add(TKey k, TValue v)
        {
            mStore.Add(k, v);
        }
        public static TValue Get(TKey key)
        {
            TValue tv;
            mStore.TryGetValue(key, out tv);
            return tv;
        }


    }
    public class StoreWordType : IStore<string, WordType>
    {

    }
    public class StoreWord : IStore<string, Word>
    {
        public static Word MakeUnknownWord(string text)
        {
            Word w = Get(text);
            if (w)
                return w;
            UnknownWord uw = new UnknownWord();
            uw.content = text;
            Add(text, uw);
            return uw;
        }
    }
    public class StorePhrase : IStore<string, Phrase>
    {
    }
}
