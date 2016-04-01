using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace World.Object
{
    public class Mood : InnateAttribute
    {
        public double value;
        public Mood()
        {
            this.name = Config.TokenMood;
        }
    }
}
