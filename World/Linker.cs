using System.Collections;
using System.Collections.Generic;
using System;
using World.TextProcessor;
using World;
using World.Object;
using System.Text;
using System.Reflection;

namespace World
{
    public enum ErrorType
    {
        Wrong,
        PossibleWrong,
        Unknown,
        PossibleRight,
        Right,
    }
    public class InputLayer
    {
        public string text;
    }
    public class OutputLayer
    {
        public InputLayer input;
    }
    public class LinkerParam
    {
        public string action;
        public int wordIndex;
    }
    public class Linker
    {
        static List<LinkerParam> mParams = new List<LinkerParam>();
        static StringBuilder mCurText = new StringBuilder();
        static Word mCacheWord = null;
        static WordType mCacheWordType = null;

        public static List<string> GetProcesseres()
        {
            List<string> nameList = new List<string>();

            Type tp = typeof(Linker);
            MethodInfo[] methods = tp.GetMethods();
            foreach(var m in methods)
            {
                if (null != m.GetCustomAttribute(typeof(Proccessor)))
                    nameList.Add(m.Name);
            }
            return nameList;
        }

        public static string GetText()
        {
            return mCurText.ToString();
        }

        public static void Clear()
        {
            mCurText.Clear();
            mParams.Clear();
            mCacheWord = null;
        }

        public static void Invoke(Action<Word> p, List<Word> words, int wordIndex)
        {
            LinkerParam param = new LinkerParam();
            param.action = p.Method.Name;
            param.wordIndex = wordIndex;
            mParams.Add(param);
            p(words[wordIndex]);
        }
        public static void LinkWord(Word w)
        {
            mCurText.Append(w.content);
        }
        [Proccessor]
        public static void LinkObjectByReplace(Word w)
        {
            SceneObject obj = Scene.Instance.GetObjectByReplace(w.content);
            if(obj)
            {
                OutReplaceAttribute att = obj.GetAttributeByType<OutReplaceAttribute>();
                mCurText.Append(att.name);
            }
        }
        [Proccessor]
        public static void SetCacheWordTypeParent(Word w)
        {
            if (mCacheWordType)
                mCacheWordType.parent = w.content;
            if (mCacheWordType)
            {
                if(StoreWordType.getStore.Remove(mCacheWordType.name))
                    StoreWordType.Add(mCacheWordType.name, mCacheWordType);
            }
        }
        [Proccessor]
        public static void CacheWordTypeWithSingleWord(Word w)
        {
            mCacheWordType = new WordType();
            mCacheWordType.name = w.content + Config.TokenSingletonWord;
        }
        [Proccessor]
        public static void CacheWordTypeWithWordType(Word w)
        {
            mCacheWordType = new WordType();
            mCacheWordType.name = w.content + Config.TokenWordType;
        }
        [Proccessor]
        public static void CacheWordTypeAppendWordType(Word w)
        {
            if (mCacheWordType)
                mCacheWordType.name += w.content;
        }
        
        [Proccessor]
        public static void CacheOldWord(Word w)
        {
            mCacheWord = w;
            StoreWord.Remove(w.content);
        }
        [Proccessor]
        public static void AddWordWithCache(Word w)
        {
            if(mCacheWord)
            {
                Word newword = new Word();
                newword.content = mCacheWord.content;
                WordTypeFunction wtf = new WordTypeFunction();
                wtf.typeName = w.content;
                newword.typeFunctions = new List<WordTypeFunction>();
                newword.typeFunctions.AddRange(mCacheWord.typeFunctions);
                newword.typeFunctions.Add(wtf);
                StoreWord.Add(newword.content, newword);
            }
        }
        [Proccessor]
        public static void LinkObjectName(Word w)
        {
            SceneObject obj = Scene.Instance.GetObjectByReplace(w.content);
            mCurText.Append(obj.GetName());
        }
    }
}

