using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Object
{
    public class SceneSite
    {
        public string name;

        public bool valid
        {
            get
            {
                return !string.IsNullOrEmpty(name);
            }
        }
    }
}
