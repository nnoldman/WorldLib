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

        public List<LinkerParam> LinkParams = new List<LinkerParam>();

        public virtual bool IsCmd()
        {
            return false;
        }

        public List<List<Word>> MakeUp(List<Word> wordVecotr)
        {
            throw new Exception();
        }
        public string GenerateAnswer(List<Word> wordVecotr)
        {
            if (LinkParams.Count > 0)
                return GenerateAnswerByExperience(wordVecotr);
            else
                return GenerateAnswerNativelly(wordVecotr);
        }

        public string GenerateAnswerByExperience(List<Word> wordVecotr)
        {
            AtomicOperationArgment args = new AtomicOperationArgment() { WordVecotr = wordVecotr };
            if (LinkParams.Count > 0)
            {
                foreach (var param in LinkParams)
                    AtomicOperation.Invoke(param, ref args);
            }
            return args.OutputString.ToString();
        }
        public virtual string GenerateAnswerNativelly(List<Word> wordVecotr)
        {
            throw new Exception();
        }
        public virtual void ExecuteCmd(List<Word> wordVecotr)
        {
            if (LinkParams.Count > 0)
                ExecuteCmdByExperience(wordVecotr);
            else
                ExecuteCmdNativelly(wordVecotr);
        }
        public virtual void ExecuteCmdNativelly(List<Word> wordVector)
        {
            throw new Exception();
        }
        public void ExecuteCmdByExperience(List<Word> wordVector)
        {
            AtomicOperationArgment args = new AtomicOperationArgment() { WordVecotr = wordVector };
            if (LinkParams.Count > 0)
            {
                foreach (var param in LinkParams)
                    AtomicOperation.Invoke(param, ref args);
            }
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
        
        public bool Match(List<Word> wordVecotr)
        {
            if (wordVecotr.Count < elements.Count)
                return false;
            if (wordVecotr.Count == elements.Count)
            {
                for (int i = 0; i < wordVecotr.Count; ++i)
                {
                    Word word = wordVecotr[i];
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
