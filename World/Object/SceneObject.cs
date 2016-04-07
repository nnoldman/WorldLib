using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace World.Object
{
    public class SceneObject : Nothing
    {
        static int CountOfObject = 0;

        public int id;
        public string name;
        public List<ObjectAttribute> attributes = new List<ObjectAttribute>();

        public SceneObject()
        {
            id = ++CountOfObject;
            Scene.Instance.AddObject(this);
        }
        ~SceneObject()
        {
            id = ++CountOfObject;
            Scene.Instance.AddObject(this);
        }
        public string GetName()
        {
            if (!string.IsNullOrEmpty(name))
                return name;
            foreach(var attr in attributes)
            {
                if(attr is SceneObjectName)
                {
                    return attr.name;
                }
            }
            return string.Empty;
        }
        public virtual string OutPut()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Format("SceneObject({0}):", GetName()));
            sb.Append(Config.TokenEnter + "{" + Config.TokenEnter);
            foreach (var attr in attributes)
            {
                sb.Append("    ");
                sb.Append(attr.OutPut());
            }
            sb.Append("}");
            return sb.ToString();
        }
        public void Execute(string action,string target)
        {

        }
        public MatchResult MatchAttribute(ObjectAttribute attr)
        {
            foreach (var i in this.attributes)
            {
                var res = attr.Match(i);
                if (res == MatchResult.None)
                    continue;
                return res;
            }
            return MatchResult.None;
        }
        public MatchResult MatchAttributes(SceneObject b)
        {
            foreach (var att in b.attributes)
            {
                MatchResult res = MatchAttribute(att);
                if (res == MatchResult.None)
                    continue;
                return res;
            }
            return MatchResult.None;
        }
        public MatchResult MatchAttributesWithoutKind( SceneObject b, string kind)
        {
            foreach (var att in b.attributes)
            {
                if (kind == att.kind)
                    continue;
                MatchResult res = MatchAttribute(att);
                if (res == MatchResult.None)
                    continue;
                return res;
            }
            return MatchResult.None;
        }
        public MatchResult Is(SceneObject something)
        {
            if (!Is(something.name))
            {
                return MatchAttributesWithoutKind(something, Config.TokenName);
            }
            else
            {
                return MatchResult.MatchSucess;
            }
        }

        //public bool IsDefine(ObjectDefine def)
        //{
        //    return def.IsThis(this);
        //}
        public bool Is(string name)
        {
            if (this.name == name)
                return true;

            foreach(var attr in attributes)
            {
                SceneObjectName objname = (SceneObjectName)attr;

                if (objname)
                {
                    if (objname.name == name)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool Can(Nothing right)
        {
            return false;
        }

        public List<ObjectAttribute> GetAttribute(string kind)
        {
            List<ObjectAttribute> attrs = new List<ObjectAttribute>();

            foreach (var att in this.attributes)
            {
                if(att.kind==kind)
                {
                    attrs.Add(att);
                }
            }
            return attrs;
        }
        public ObjectDefine GetDefine()
        {
            ObjectDefine def = (ObjectDefine)GetFirstAttribute(Config.TokenDefine);
            return def;
        }
        public ObjectAttribute GetFirstAttribute(string kind)
        {
            List<ObjectAttribute> attrs = new List<ObjectAttribute>();

            foreach (var att in this.attributes)
            {
                if (att.kind == kind)
                {
                    return att;
                }
            }
            return null;
        }

        public override string GetContent()
        {
            if (!string.IsNullOrEmpty(name))
                return name;

            ObjectAttribute attr = GetFirstAttribute(Config.TokenName);
            if (attr)
                return attr.name;
            return Config.TokenUnknown;
        }
    }
}
