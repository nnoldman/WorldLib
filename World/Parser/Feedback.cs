using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Object;

namespace World.Parser
{
    public class Feedback : IBool
    {
        public SceneObject executer;
        public SceneObject target;
        protected StringBuilder mContent = new StringBuilder();
        public virtual string GetContent()
        {
            return string.Empty;
        }
    }
}
