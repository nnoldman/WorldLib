using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;

public class TypeScaner 
{
    public static List<Action<Type>> OnProcess = new List<Action<Type>>();

    public static void InitTypes(Assembly assembly)
    {
        Type[] types = assembly.GetTypes();
        foreach (var tp in types)
        {
            foreach (var act in OnProcess)
                act(tp);
        }
    }
}
