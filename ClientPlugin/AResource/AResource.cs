using System.Collections;
using System.Security;
using System.Collections.Generic;
using System.Xml;
using System;
using System.Text;
using System.Reflection;
using Mono.Xml;
using System.IO;
using GameData;


public class AResource
{
    public static char ListSeparation = ';';

    public static string GetResourcePath(string file)
    {
        if (string.IsNullOrEmpty(file))
            return string.Empty;
        file = file.ToLower();
        int pos = file.IndexOf(Setting.ResourcePath);
        if (pos == -1)
            return string.Empty;
        return file.Substring(pos + Setting.ResourcePath.Length);
    }


    private static SecurityElement LoadEles(String fileName)
    {
        return GameDataLoader.LoadOutter(fileName);
    }

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="content">xml text</param>
/// <returns></returns>
    public static T LoadXML<T>(string content) where T : XMLFile
    {
        if (string.IsNullOrEmpty(content))
            return default(T);
        SecurityElement root = GameDataLoader.LoadXML(content);
        if (root == null)
            return default(T);

        object obj;
        ParseFromXML(root, typeof(T), out obj);
        if (obj != null)
            return (T)obj;
        return default(T);
    }
    /// <summary>
    ///  保存结构体到XML中。形式如：文件头?xml version="1.0" encoding="utf-8"?,根节点root
    /// </summary>
    public static void SaveXML<T>(T obj, string file) where T : XMLFile
    {
        if (obj == null)
            return;

        XmlDocument doc = new XmlDocument();
        XmlDeclaration dlcl = doc.CreateXmlDeclaration("1.0", "utf-8", string.Empty);
        doc.AppendChild(dlcl);
        SaveNode(null, "root", doc, obj);
        file = Fun.EnsureFileNameWithExtenision_XML(file);
        doc.Save(file);
    }
    
    private static string GetTag(string node)
    {
        return node;
    }
    /// <summary>
    /// <record id="1" type="typeName">
    /// <content ></content>
    /// </record>
    /// </summary>
    /// <param name="file"></param>
    /// <returns></returns>
    public static bool LoadObjectWithMeta(string fileName,out Dictionary<int, object> result,ref Dictionary<string,Type> creators)
    {
        result = null;

        SecurityElement xml = LoadEles(fileName);
        if (xml != null)
        {
            result = new Dictionary<int, object>();

            foreach (SecurityElement record in xml.Children)
            {
                if(record.Attributes.Count>0)
                {
                    int id=int.Parse(record.Attributes["id"].ToString());
                    string typename=record.Attributes["typename"].ToString();

                    if (creators != null)
                    {
                        Type tp;
                        if(creators.TryGetValue(typename,out tp))
                        {
                            if (record.Children.Count > 0)
                            {
                                object obj = null;
                                SecurityElement child = (SecurityElement)record.Children[0];
                                ParseFromXML(child, tp, out obj);
                                if (obj != null)
                                {
                                    try
                                    {
                                        result.Add(id, obj);
                                    }
                                    catch (Exception )
                                    {
                                        ALog.error(string.Format("{0} Repeated ID:{1}", fileName, id));
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return result.Count>0;
        }
        return false;
    }
    public void SaveObjectWithTypeInfo(XmlElement node, object obj)
    {
    }

    public static void SaveNode(XmlElement node, string propName, XmlDocument doc, object obj)
    {
        string res = Converter.GetString(obj.GetType(), obj);

        if (res != null)
        {
            node.SetAttribute(propName, res);
        }
        else
        {
            Type type = obj.GetType();

            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
            {
                XmlElement child = doc.CreateElement(propName);

                int cnt = (int)type.GetProperty("Count").GetValue(obj, null);
                StringBuilder liststr = new StringBuilder();
                for (int i = 0; i < cnt; ++i)
                {
                    string listItemName = propName + "Item";
                    object[] args = new object[1];
                    args[0] = i;

                    PropertyInfo propinfo = type.GetProperty("Item");

                    object item = propinfo.GetValue(obj, args);
                    string itemstr = Converter.GetString(item.GetType(), item);
                    if (itemstr != null)
                    {
                        liststr.Append(itemstr);
                        liststr.Append(Token.ListKey);
                    }
                    else
                    {
                        SaveNode(child, listItemName, doc, item);
                    }
                }
                if (liststr.Length > 0)
                {
                    liststr.Remove(liststr.Length - 1, 1);
                    node.SetAttribute(propName, liststr.ToString());
                }
                else
                {
                    node.AppendChild(child);
                }
            }
            else///非list型且不是基本类型
            {
                XmlElement child = null;
                if (node == null)
                {
                    child = doc.CreateElement(propName);
                    doc.AppendChild(child);
                }
                else
                {
                    child = doc.CreateElement(propName);
                    node.AppendChild(child);
                }

                FieldInfo[] props = type.GetFields();

                foreach (FieldInfo prop in props)
                {
                    if (prop.IsStatic)
                        continue;
                    if (prop.MemberType == MemberTypes.Property || prop.MemberType == MemberTypes.Field)
                    {
                        System.Type proptype = prop.FieldType;
                        object childValue = prop.GetValue(obj);
                        if (childValue == null)
                            continue;
                        SaveNode(child, prop.Name, doc, childValue);
                    }
                }
            }
        }
    }
    public static void SaveGameData<T>(Dictionary<int, T> dataMap, string file, bool back = true) where T : GameData.GameData<T>
    {
        if (back)
        {
            if (File.Exists(file))
                File.Copy(file, file + ".back", true);
        }

        XmlDocument doc = new XmlDocument();
        XmlDeclaration dlcl = doc.CreateXmlDeclaration("1.0", "utf-8", string.Empty);
        doc.AppendChild(dlcl);
        XmlElement root = doc.CreateElement("root");
        doc.AppendChild(root);

        foreach (var pair in dataMap)
        {
            AResource.SaveNode(root, "record", doc, pair.Value);
        }
        file = Fun.EnsureFileNameWithExtenision_XML(file);
        doc.Save(file);
    }
    
    private static Boolean LoadIntMap(String fileName, out Dictionary<Int32, SecurityElement> map)
    {
        SecurityElement xml = LoadEles(fileName);
        map = LoadIntMap(xml, fileName);
        return true;
    }
    private static Dictionary<Int32, SecurityElement> LoadIntMap(SecurityElement xml, string source)
    {
        var result = new Dictionary<Int32, SecurityElement>();

        var index = 0;
        foreach (SecurityElement subMap in xml.Children)
        {
            index++;
            if (subMap.Attributes == null || subMap.Attributes.Count == 0)
            {
                ALog.logWarning("empty row in row NO." + index + " of " + source);
                continue;
            }

            if (!subMap.Attributes.ContainsKey("id"))
            {
                ALog.logWarning("Invalid Record ID" + index + " of " + source);
                continue;
            }

            Int32 key = Int32.Parse(subMap.Attributes["id"] as string);
            if (result.ContainsKey(key))
            {
                ALog.logWarning(String.Format("Key {0} already exist, in {1}.", key, source));
                continue;
            }

            result.Add(key, subMap);
        }
        return result;
    }
    private static void ParseFromXML(SecurityElement node, Type type, out object obj)
    {
        object pval = Converter.GetValue(type, node.Text);
        if (pval != null)
        {
            obj = pval;
            return;
        }
        ConstructorInfo coninfo = type.GetConstructor(Type.EmptyTypes);
        if (coninfo == null)
        {
            ALog.logError("FormatData Error: " + type.Name + " doesn't have an empty param ctor!");
            obj = null;
            return;
        }

        var t = type.GetConstructor(Type.EmptyTypes).Invoke(null);

        FieldInfo[] props = type.GetFields();

        foreach (FieldInfo prop in props)
        {
            if (prop.IsStatic)
                continue;
            if (prop.MemberType == MemberTypes.Property || prop.MemberType == MemberTypes.Field)
            {
                Type proptype = prop.FieldType;

                if (proptype.IsGenericType && proptype.GetGenericTypeDefinition() == typeof(List<>))
                {
                    var propValue = proptype.GetConstructor(Type.EmptyTypes).Invoke(null);
                    Type listParamType = proptype.GetGenericArguments()[0];

                    if (node.Attributes != null)
                    {
                        string _tagname = GetTag(prop.Name);

                        if (node.Attributes.ContainsKey(_tagname))
                        {
                            string str = node.Attributes[_tagname] as string;

                            string[] items = str.Split(Token.ListKey);
                            foreach (var item in items)
                            {
                                object listobj = Converter.GetValue(listParamType, item);
                                if (listobj != null)
                                    proptype.GetMethod("Add").Invoke(propValue, new object[] { listobj });
                            }
                        }
                    }
                    if (node.Children != null)
                    {
                        foreach (var item in node.Children)
                        {
                            var child = (SecurityElement)item;
                            string tag = GetTag(child.Tag);
                            if (tag == prop.Name)
                            {
                                //ALog.Log("PropName:" + prop.Name);
                                if (child.Children != null)
                                {
                                    foreach (var cchild in child.Children)
                                    {
                                        object listobj;
                                        ParseFromXML((SecurityElement)cchild, listParamType, out listobj);
                                        if (listobj != null)
                                        {
                                            proptype.GetMethod("Add").Invoke(propValue, new object[] { listobj });
                                        }
                                    }
                                }
                            }
                        }
                    }
                    prop.SetValue(t, propValue);
                }
                else
                {
                    if (node.Attributes != null)
                    {
                        foreach (var key in node.Attributes.Keys)
                        {
                            string tag = GetTag((string)key);
                            if (tag == prop.Name)
                            {
                                object pattr = Converter.GetValue(proptype, (string)node.Attributes[tag]);
                                if (pattr != null)
                                    prop.SetValue(t, pattr);
                            }
                        }
                    }
                    if (node.Children != null)
                    {
                        foreach (var item in node.Children)
                        {
                            var child = (SecurityElement)item;
                            string tag = GetTag(child.Tag);
                            if (tag == prop.Name)
                            {
                                object baseobj;
                                ParseFromXML(child, proptype, out baseobj);
                                prop.SetValue(t, baseobj);
                            }
                        }
                    }
                }
            }
        }


        obj = t;
    }
}

