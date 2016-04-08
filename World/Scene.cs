using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using World.Object;
using World.TextProcessor;

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
                sb.Append(Config.TokenEnter);
                sb.Append(obj.Value.OutPut());
            }
            return sb.ToString();

        }
        public SceneObject GetObjectByReplace(string name)
        {
            foreach (var obj in mObjects)
            {
                var att = obj.Value.GetAttributeByType<OutReplaceAttribute>();
                if (att && att.target == name)
                    return obj.Value;

            }
            return null;
        }
        public SceneObject GetObject(string name)
        {
            foreach(var obj in mObjects)
            {
                if (name == obj.Value.GetName())
                    return obj.Value;
            }
            return null;
        }
        
        public void Load()
        {

        }
        public void Save()
        {

        }
    }
}
