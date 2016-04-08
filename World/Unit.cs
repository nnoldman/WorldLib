﻿using System.Collections;
using System.Collections.Generic;
using System;
using World.TextProcessor;
using World;
using World.Object;
using System.Text;

namespace Nervous
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
        public static void LinkObjectByReplace(Word w)
        {
            SceneObject obj = Scene.Instance.GetObjectByReplace(w.content);
            if(obj)
            {
                OutReplaceAttribute att = obj.GetAttributeByType<OutReplaceAttribute>();
                mCurText.Append(att.name);
            }
        }

        public static void CacheOldWord(Word w)
        {
            mCacheWord = w;
            StoreWord.Remove(w.content);
        }
        public static void AddWordWithCache(Word w)
        {
            Word newword = new Word();
            newword.content = w.content;
            WordTypeFunction wtf = new WordTypeFunction();
            wtf.typeName = w.content;
            newword.typeFunctions = new List<WordTypeFunction>();
            newword.typeFunctions.AddRange(mCacheWord.typeFunctions);
            newword.typeFunctions.Add(wtf);
            StoreWord.Add(newword.content, newword);
        }
        public static void LinkObjectName(Word w)
        {
            SceneObject obj = Scene.Instance.GetObjectByReplace(w.content);
            mCurText.Append(obj.GetName());
        }
    }
}

