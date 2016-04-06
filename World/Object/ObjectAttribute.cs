using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Object
{
    public enum MatchResult
    {
        None,
        MatchSucess,
        MatchFailed,
    }
    public class ObjectAttribute : SceneObject
    {
        public string kind;
        public string content;
        public bool canRemove;

        public MatchResult Match(ObjectAttribute attr)
        {
            if (this.kind == attr.kind  )
            {
                return this.content == attr.content ? MatchResult.MatchSucess : MatchResult.MatchFailed;
            }
            return MatchResult.None;
        }

        public override string GetContent()
        {
            return content;
        }
        public override string OutPut()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("=>{0}{1}", name, content));
            return sb.ToString();
        }
    }
}
