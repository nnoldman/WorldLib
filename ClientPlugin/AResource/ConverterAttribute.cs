using System.Collections;
using System;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public class ConverterAttribute : Attribute
{
    public ConverterAttribute(Type type)
    {
        converType = type;
    }
    public Type converType;
}
