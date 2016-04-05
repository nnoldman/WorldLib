using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Processor
{
    public  class Phrase
    {
        //public string text;

        public Word root = new Word();

        protected SequenceWord mWordRoot;
        /// <summary>
        /// 构件
        /// </summary>
        List<PhraseElement> elements
        {
            get
            {
                if (mElements == null)
                {
                    MakeElementInner();
                }
                return mElements;
            }
        }
        List<PhraseElement> mElements;

        public StringBuilder builder = new StringBuilder();

        public virtual void Clear()
        {
            throw new Exception();
        }
        protected void MakeElementInner()
        {
            mElements = new List<PhraseElement>();
            Type tp = this.GetType();
            object[] attrs = tp.GetCustomAttributes(true);
            if (attrs != null)
            {
                foreach (var att in attrs)
                {
                    if (att is PhraseElement)
                    {
                        mElements.Add((PhraseElement)att);
                    }
                }
            }
        }
        public virtual Feedback GetFeedback()
        {
            return null;
        }
        public virtual bool Match()
        {
            mWordRoot  = new SequenceWord();
            MakeSequence(builder.ToString(), ref mWordRoot, OnUnknownContent);
            return Match(mWordRoot);
        }
        bool Match(SequenceWord seq)
        {
            if (elements.Count == 0)
            {
                Logger.Error("");
                return false;
            }

            SequenceWord sw = seq;
            for (int i = 0; i < elements.Count; ++i)
            {
                PhraseElement cur = elements[i];
                if (!seq.word.IsType(cur.wordType))
                    return false;
                sw = seq.right;
                if (!sw)
                    return false;
            }
            if (sw.right)
                return false;
            return true;
        }
        public void OnUnknownContent(string text)
        {
            throw new Exception();
        }
        public Phrase Copy()
        {
            Phrase phrase = new Phrase();
            phrase = this;
            return phrase;
        }
        public static Phrase Get(string text)
        {
            foreach (var p in phraseStore)
            {
                p.builder.Clear();
                p.builder.Append(text);
                if (p.Match())
                {
                    return p.Copy();
                }
            }
            return null;
        }

        public static void MakeSequence(string text, ref SequenceWord last, Action<string> unknownHandler)
        {
            int startIndex = 0;
            int index = text.Length - 1;

            while (index > startIndex&&index>0)
            {
                string cur = text.Substring(startIndex, index);
                Word w = StoreWord.Get(cur);
                if (w)
                {
                    SequenceWord seq = new SequenceWord();
                    seq.word = w;
                    if (last)
                    {
                        seq.left = last;
                        last.right = seq;
                    }

                    MakeSequence(text.Substring(index), ref seq, unknownHandler);
                }
                else
                {
                    if (unknownHandler != null)
                        unknownHandler(cur);
                }
                index--;
            }
        }

        static Dictionary<string, Word> wordStore = new Dictionary<string, Word>();

        static List<Phrase> phraseStore = new List<Phrase>();
    }


}
