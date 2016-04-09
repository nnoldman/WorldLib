using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.TextProcessor
{
    public class IStore<TKey, TValue>
    {
        public delegate void OnAdd(TKey k, TValue v);
        public delegate void OnRemove(TKey k);

        public static OnAdd onAdd;
        public static OnRemove onRemove;
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
            if (onAdd != null)
                onAdd(k, v);
        }
        public static TValue Get(TKey key)
        {
            TValue tv;
            mStore.TryGetValue(key, out tv);
            return tv;
        }
        public static void Remove(TKey key)
        {
            if (onRemove != null)
                onRemove(key);
            mStore.Remove(key);
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
