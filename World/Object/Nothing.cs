using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace World.Object
{
    public class Nothing
    {
        public static implicit operator bool(Nothing right)
        {
            return right != null;
        }
        public virtual string GetContent()
        {
            return Config.TokenSpace;
        }

        public virtual ObjectDefine GetDefine()
        {
            return null;
        }
    }
}
