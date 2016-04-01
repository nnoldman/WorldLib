using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Object
{
    public class ObjectAttributeUsage : Attribute
    {
        public bool CanRemove = true;
        public bool CanNull = true;
    }
}
