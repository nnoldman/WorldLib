using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Object
{
    public class SceneTime
    {
        public string stime;

        public int time = 0;
        public bool valid
        {
            get
            {
                return time > 0 || !string.IsNullOrEmpty(stime);
            }
        }
    }
}
