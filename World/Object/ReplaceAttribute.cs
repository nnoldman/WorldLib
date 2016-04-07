using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace World.Object
{
    public class OutReplaceAttribute : ObjectAttribute
    {
        public string target;
        public OutReplaceAttribute()
        {
            kind = Config.TokenReplace;
            this.name = string.Empty;
        }
    }
}
