using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Processor
{
    public  class WordType : IBool
    {
        public string name;
        public string parent;
        public List<WordType> children = new List<WordType>();

        WordType parentType
        {
            get
            {
                if (string.IsNullOrEmpty(parent))
                    return null;
                return StoreWordType.Get(parent);
            }
        }

        WordType GetType(string name)
        {
            WordType wt;
            wordTypes.TryGetValue(name, out wt);
            return wt;
        }
        static bool Exist(string name)
        {
            return wordTypes.ContainsKey(name);
        }
        public void RemoveChild(string name)
        {
            children.RemoveAll((item) => item.name == name);
        }
        public bool HasChild(string name)
        {
            foreach (var t in children)
            {
                if (t.name == name)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool TypeIsType(string name,string typeName)
        {
            WordType wt = StoreWordType.Get(typeName);
            if (!wt)
                return false;
            return wt.IsType(name);
        }
        public bool IsType(string name)
        {
            if (this.name == name)
                return true;
            WordType parentType = this.parentType;
            if (parentType)
                return parentType.IsType(name);
            else
                return false;
        }
        public SetWordTypeParentResult SetWordTypeParent(string name, string parent)
        {
            WordType newtype;
            if (!wordTypes.TryGetValue(name, out newtype))
            {
                return SetWordTypeParentResult.NoThis;
            }

            WordType parentType;
            if (!wordTypes.TryGetValue(parent, out parentType))
            {
                return SetWordTypeParentResult.NoParent;
            }

            if (parentType.HasChild(name))
                return SetWordTypeParentResult.YetHasSameChild;

            newtype.parent = parentType.name;
            parentType.children.Add(newtype);

            return SetWordTypeParentResult.Sucess;
        }
        public AddWordTypeResult AddWordType(string name, string parent = "")
        {
            if (WordType.Exist(name))
                return AddWordTypeResult.Existed;

            WordType newtype = new WordType();
            newtype.name = name;

            WordType wt;
            if (!string.IsNullOrEmpty(parent))
            {
                if (!wordTypes.TryGetValue(parent, out wt))
                {
                    return AddWordTypeResult.NoParent;
                }
                else
                {
                    newtype.parent = parent;
                    wt.children.Add(newtype);
                }
            }
            wordTypes.Add(name, newtype);
            return AddWordTypeResult.Sucess;
        }

        public static Dictionary<string, WordType> wordTypes = new Dictionary<string, WordType>();
    }
}
