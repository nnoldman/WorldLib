using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Object;

namespace World.Processor
{
    public class Feedback_Description : Feedback
    {
        public override string GetContent()
        {
            ObjectDefine def = target.GetDefine();
            mContent.Append(executer.GetContent());
            mContent.Append(Config.TokenBe1);
            mContent.Append(def.GetContent());
            return mContent.ToString();
        }
    }
}
