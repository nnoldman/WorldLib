using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace World.Object
{
    public class SceneObjectName : ObjectAttribute
    {
        public SceneObjectName()
        {
            kind = Config.TokenName;
            this.name = string.Empty;
        }
    }
}
