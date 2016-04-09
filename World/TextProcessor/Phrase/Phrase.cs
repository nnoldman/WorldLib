using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.TextProcessor
{
    public class Expression : IBool
    {
        //public string text;
        public string name = string.Empty;

        public Word root = new Word();

        protected SequenceWord mWordRoot;

        public virtual bool IsCmd()
        {
            return false;
        }

        public List<List<Word>> MakeUp(List<Word> words)
        {
            throw new Exception();
        }

        public virtual void ExecuteCmd(List<Word> words)
        {

        }
        /// <summary>
        /// 构件
        /// </summary>
        public List<ExpressionElement> elements
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
        protected List<ExpressionElement> mElements;

        public StringBuilder builder = new StringBuilder();

        public virtual void Clear()
        {
            throw new Exception();
        }
        protected void MakeElementInner()
        {
            mElements = new List<ExpressionElement>();
            Type tp = this.GetType();
            object[] attrs = tp.GetCustomAttributes(true);
            if (attrs != null)
            {
                foreach (var att in attrs)
                {
                    if (att is ExpressionElement)
                    {
                        mElements.Add((ExpressionElement)att);
                    }
                }
            }
        }
        public virtual string GenerateAnswer(List<Word> words)
        {
            throw new Exception();
        }
        public bool Match(List<Word> words)
        {
            if (words.Count < elements.Count)
                return false;
            if (words.Count == elements.Count)
            {
                for (int i = 0; i < words.Count; ++i)
                {
                    Word word = words[i];
                    ExpressionElement element = elements[i];
                    if (!word.IsType(element.wordType))
                        return false;
                }
            }

            return true;
        }

        public string OutPut()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("Expression({0}):", name));
            foreach (var ele in elements)
            {
                sb.Append(ele.wordType);
                sb.Append('.');
            }
            return sb.ToString();
        }
        public Expression Copy()
        {
            Expression exp = new Expression();
            exp = this;
            return exp;
        }
    }


}
