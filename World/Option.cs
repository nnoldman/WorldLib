using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    public class Command
    {
        public bool isGodMode = false;
        public bool isCommand = false;
        public bool isOpenCommandMode = true;

        public bool isControlling
        {
            get
            {
                return !isGodMode && isCommand && isOpenCommandMode;
            }
        }
    }
    public class Option
    {
        public static Command command = new Command();
    }
}
