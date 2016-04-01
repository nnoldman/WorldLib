using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using World.Object;
using World.Parser;

namespace World
{
    public class Scene : IBool
    {
        static Scene mInstance;
        public static Scene Instance
        {
            get
            {
                if (!mInstance)
                {
                    mInstance = new Scene();
                }
                return mInstance;
            }
        }

        Dictionary<string, SceneObject> mObjects = new Dictionary<string, SceneObject>();

        public void Initialize()
        {
            DataCenter.Initialize();

            AddObject(Myself.Instance);
        }
        public void AddObject(SceneObject obj)
        {
            if (string.IsNullOrEmpty(obj.name))
            {
                Logger.Error("Name is Empty");
                return;
            }
            if (!mObjects.ContainsKey(obj.name))
            {
                mObjects.Add(obj.name, obj);
            }
        }

        public SceneObject GetObject(string name)
        {
            SceneObject obj;
            mObjects.TryGetValue(name, out obj);
            return obj;
        }
        public void Parse(List<Phrase> phrases)
        {
            foreach (var p in phrases)
            {
                Feedback fd = p.GetFeedback();
                if (fd)
                {
                    Myself.Instance.OutPut(fd.GetContent());
                }
            }
        }
        public void Load()
        {

        }
        public void Save()
        {

        }
    }
}
