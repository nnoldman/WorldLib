using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.TextProcessor
{
    public class Parser
    {
        public Expression Parse(List<Word> words)
        {
            Expression p = null;
            foreach(var Expression in StoreExpression.getStore)
            {
                if (Expression.Value.Match(words))
                {
                    p = Expression.Value;
                    break;
                }
            }
            return p;
        }
    }
}
