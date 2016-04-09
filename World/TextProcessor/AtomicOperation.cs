using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using World;
using World.Object;
using World.TextProcessor;

public class AtomicOperation
{
    public delegate void AOper(ref AtomicOperationArgment args, int wordIndex = -1);
    static List<LinkerParam> mParams = new List<LinkerParam>();
    public static List<string> GetForwardProcesseres()
    {
        List<string> nameList = new List<string>();

        Type tp = typeof(AtomicOperation);
        MethodInfo[] methods = tp.GetMethods();
        foreach (var m in methods)
        {
            if (null != m.GetCustomAttribute(typeof(ForwardPropagation)))
                nameList.Add(m.Name);
        }
        return nameList;
    }
    public static List<string> GetBackwardProcesseres()
    {
        List<string> nameList = new List<string>();

        Type tp = typeof(AtomicOperation);
        MethodInfo[] methods = tp.GetMethods();
        foreach (var m in methods)
        {
            
            if (null != m.GetCustomAttribute(typeof(BackwardPropagation)))
                nameList.Add(m.Name);
        }
        return nameList;
    }
    public static void Clear()
    {
        mParams.Clear();
    }
    public static void Invoke(AOper p, ref AtomicOperationArgment args, int wordIndex = -1)
    {
        LinkerParam param = new LinkerParam();
        param.action = p.Method.Name;
        mParams.Add(param);
        if(p!=null)
            p(ref args, wordIndex);
    }
    public static void CreateTempWord(ref AtomicOperationArgment args)
    {
        throw new Exception();
    }
    [BackwardPropagation]
    public static void AddParam(ref AtomicOperationArgment args, int wordIndex)
    {
        args.AddParam(wordIndex);
    }
    [BackwardPropagation]
    public static void AddWordType(ref AtomicOperationArgment args, int wordIndex)
    {
        throw new Exception();
    }
    [BackwardPropagation]
    public static void RemoveWordType(ref AtomicOperationArgment args)
    {
        throw new Exception();
    }

    [BackwardPropagation]
    public static void AddWord(ref AtomicOperationArgment args,int index)
    {
        string content = args.GetParam();

        List<WordTypeFunction> oldWrodTypeFunctions = new List<WordTypeFunction>();
        Word old = StoreWord.Get(content);
        if (old)
            oldWrodTypeFunctions = old.typeFunctions;

        StoreWord.Remove(content);

        Word newword = new Word();
        newword.content = content;
        WordTypeFunction wtf = new WordTypeFunction();
        wtf.typeName = args.GetParam();
        newword.typeFunctions = new List<WordTypeFunction>();
        newword.typeFunctions.AddRange(oldWrodTypeFunctions);
        newword.typeFunctions.Add(wtf);

        StoreWord.Add(newword.content, newword);
    }

    [BackwardPropagation]
    public static void RemoveWord(ref AtomicOperationArgment args)
    {
        throw new Exception();
    }

    [ForwardPropagation]
    public static void LinkWord(ref AtomicOperationArgment args, int index = -1)
    {
        args.outputString.Append(args.words[index].content);
    }
    [ForwardPropagation]
    public static void LinkObjectByReplace(ref AtomicOperationArgment args, int index = -1)
    {
        string content = args.words[index].content;
        SceneObject obj = Scene.Instance.GetObjectByReplace(content);
        if (obj)
        {
            OutReplaceAttribute att = obj.GetAttributeByType<OutReplaceAttribute>();
            args.outputString.Append(att.name);
        }
    }
    [ForwardPropagation]
    public static void LinkObjectName(ref AtomicOperationArgment args, int index = -1)
    {
        string content = args.words[index].content;
        SceneObject obj = Scene.Instance.GetObjectByReplace(content);
        args.outputString.Append(obj.GetName());
    }
}
