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
    public class ObjectAttribute : IBool
    {
        public string kind;
        public bool canRemove;
        public string name = "attribute";

        public ObjectAttribute()
        {
        }
        public MatchResult Match(ObjectAttribute attr)
        {
            if (this.kind == attr.kind  )
            {
                return this.name == attr.name ? MatchResult.MatchSucess : MatchResult.MatchFailed;
            }
            return MatchResult.None;
        }

        public  string GetContent()
        {
            return name;
        }
        public  string OutPut()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("[{0}]{1}", kind, name));
            sb.Append(Config.TokenEnter);
            return sb.ToString();
        }
    }
}
