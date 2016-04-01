using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Parser
{
    public  class IStore<TKey,TValue>
    {
        public static Dictionary<TKey,TValue> getStore
        {
            get
            {
                return mStore;
            }
        }
        protected static Dictionary<TKey, TValue> mStore = new Dictionary<TKey, TValue>();
        public static void Add(TKey k,TValue v)
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
    public  class StoreWord : IStore<string, Word>
    {
    }
    public  class StorePhrase : IStore<string, Phrase>
    {
    }
}
