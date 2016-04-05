using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Object;

namespace World.Processor
{
    public class TempWord : IBool
    {
        public Word word;
        public int start;
        public int end;
        public int length
        {
            get
            {
                return end - start;
            }
        }
    }
    /// <summary>
    /// 词法分析器，扫描后获得所有单词列表，从大词到小词匹配
    /// </summary>
    public class Scanner
    {
        protected string mText;
        public List<Word> Scan(string text)
        {
            mText = text.Trim('\r','\n');
            return GetWords();
        }
        /// <summary>
        /// 此处以后可做优化，方向是分布式
        /// </summary>
        /// <returns></returns>
        List<Word> GetWords()
        {
            List<Word> words = new List<Word>();
            List<TempWord> tempWordsKnown = GenerateKnownWords();
            List<TempWord> allwords = CompleteUnknownWords(tempWordsKnown);
            allwords.ForEach((item) => words.Add(item.word));
            return words;
        }
        List<TempWord> GenerateKnownWords()
        {
            List<TempWord> tempWords = new List<TempWord>();

            for (int i = 0; i < mText.Length;)
            {
                string curText = mText.Substring(i);
                TempWord tw = GetOneWord(curText, i);
                if (tw)
                {
                    tempWords.Add(tw);
                    i += tw.length;
                }
                else
                {
                    i++;
                }
            }
            return tempWords;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tempWords"></param>
        /// <returns>所有单词列表</returns>
        List<TempWord> CompleteUnknownWords(List<TempWord> tempWords)
        {
            List<TempWord> unknownword = new List<TempWord>();
            int len = mText.Length;
            int tempWordIndex = 0;
            for (int i = 0; i < len;)
            {
                TempWord tw = null;
                if (tempWordIndex < tempWords.Count)
                    tw = tempWords[tempWordIndex];
                if (tw)
                {
                    if (i < tw.start)
                    {
                        TempWord newtw = new TempWord();
                        newtw.word = StoreWord.MakeUnknownWord(mText.Substring(i, tw.start - 1));
                        newtw.start = i;
                        newtw.end = tw.start - 1;
                        unknownword.Add(newtw);
                    }
                    else
                    {
                        i = tw.end;
                        tempWordIndex++;
                    }
                }
                else
                {
                    TempWord newtw = new TempWord();
                    newtw.word = StoreWord.MakeUnknownWord(mText.Substring(i));
                    newtw.start = i;
                    newtw.end = mText.Length;
                    unknownword.Add(newtw);
                    break;
                }
            }
            tempWords.AddRange(unknownword);
            tempWords.Sort(SortFunc);
            return tempWords;
        }

        int SortFunc(TempWord a, TempWord b)
        {
            if (a.start == b.start)
                return 0;
            if (a.start < b.start)
                return -1;
            if (a.start > b.start)
                return 1;
            throw new Exception();
        }

        TempWord GetOneWord(string text, int start)
        {
            for (int i = text.Length; i > 0; --i)
            {
                string cur = text.Substring(0, i);
                Word w = StoreWord.Get(cur);
                if (w)
                {
                    TempWord tw = new TempWord();
                    tw.word = w;
                    tw.start = start;
                    tw.end = start + i;
                    return tw;
                }
            }
            return null;
        }

        bool IsPunctuation(char c)
        {
            for (int i = 0; i < Punctuation.set.Length; ++i)
            {
                if (Punctuation.set[i] == c)
                    return true;
            }
            return false;
        }
    }
}
