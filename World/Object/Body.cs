using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Object
{
    public class Body : InnateAttribute
    {
        public double hp = 1000;
        public Body()
        {
            this.name = Config.TokenBody;
        }
    }
}
