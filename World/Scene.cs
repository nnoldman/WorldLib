using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using World.Object;
using World.Processor;

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

        Dictionary<int, SceneObject> mObjects = new Dictionary<int, SceneObject>();

        public void Initialize()
        {
            DataCenter.Initialize();

            AddObject(Myself.Instance);
        }
        public void AddObject(SceneObject obj)
        {
            if (!mObjects.ContainsKey(obj.id))
            {
                mObjects.Add(obj.id, obj);
            }
        }
        public void RemoveObject(SceneObject obj)
        {
            mObjects.Remove(obj.id);
        }
        public string OutPut()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var obj in mObjects)
            {
                sb.Append("\r\n");
                sb.Append(obj.Value.OutPut());
            }
            return sb.ToString();
        }
        public SceneObject GetObject(string name)
        {
            foreach(var obj in mObjects)
            {
                if (name == obj.Value.name)
                    return obj.Value;
            }
            return null;
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
