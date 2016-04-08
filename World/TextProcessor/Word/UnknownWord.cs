using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.TextProcessor
{
    public class UnknownWord : Word
    {
        public override bool IsKnown()
        {
            return false;
        }
    }
}
