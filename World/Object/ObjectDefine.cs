using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Object
{
    public class ObjectDefine : ObjectAttribute
    {
        public float fitRate = 0.5f;
        public ObjectDefine()
        {
            this.kind = Config.TokenDefine;
        }
    }
}
