using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace World.Object
{
    public class InnateAttribute : ObjectAttribute
    {
        public InnateAttribute()
        {
            this.kind = Config.TokenInnate;
            this.canRemove = false;
        }
    }
}
