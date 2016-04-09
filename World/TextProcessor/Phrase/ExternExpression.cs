using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.TextProcessor
{
    public class ExternExpression : Expression
    {
        public void Init(GameData.ExternExpressionData data)
        {
            if (data.elements != null)
            {
                mElements = new List<ExpressionElement>();
                foreach (var ele in data.elements)
                {
                    ExpressionElement element = new ExpressionElement();
                    element.wordType = ele;
                    mElements.Add(element);
                }
            }
        }
    }
}
