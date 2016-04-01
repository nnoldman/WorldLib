using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Object
{
    public class SceneThing : SceneObject
    {
        public SceneTime time = new SceneTime();
        public SceneSite site = new SceneSite();
        public List<SceneObject> objects = new List<SceneObject>();
    }
}
