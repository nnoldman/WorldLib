using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
namespace GameData
{
    public class Converter
    {
        static Dictionary<Type, MethodInfo> mValueParsers = new Dictionary<Type, MethodInfo>();
        static Dictionary<Type, MethodInfo> mStringParsers = new Dictionary<Type, MethodInfo>();

        static Type converterAttribute = typeof(ConverterAttribute);


        public static void OnScanType(Type tp)
        {
            if (tp.Namespace == "GameData")
            {
                object[] attributes = tp.GetCustomAttributes(converterAttribute, true);
                if (attributes != null)
                {
                    foreach (var attr in attributes)
                    {
                        Type convertype = ((ConverterAttribute)attr).converType;
                        MethodInfo getValueFunc = tp.GetMethod("GetValue");
                        MethodInfo getStringFunc = tp.GetMethod("GetStirng");
                        mValueParsers.Add(convertype, getValueFunc);
                        mStringParsers.Add(convertype, getStringFunc);
                    }
                }
            }
        }

        public static MethodInfo GetStringParser(Type type)
        {
            if (type.BaseType == typeof(Enum))
                return Converter_Enum.getEnumString;
            MethodInfo func;
            mStringParsers.TryGetValue(type, out func);
            return func;
        }

        public static MethodInfo GetValueParser(Type type)
        {
            if (type.BaseType == typeof(Enum))
                return Converter_Enum.getEnumValue;
            MethodInfo func;
            mValueParsers.TryGetValue(type, out func);
            return func;
        }
        public static object GetValue(Type type, String value)
        {
            //Log.Info("GetValue.String : =>" + value);

            MethodInfo parser = GetValueParser(type);

            if (parser != null)
            {
                object[] paras = new object[2];
                paras[0] = type;
                paras[1] = value;
                //Log.Info("GetValue.Invoke : =>" + parser.Name);
                try
                {
                    return parser.Invoke(null, paras);
                }
                catch (Exception ex)
                {
                    ALog.logError(ex.Message);
                    return null;
                }
            }
            return null;
        }


        public static String GetString(Type type, object value)
        {
            //Log.Info("GetString.String : =>" + value);
            MethodInfo parser = GetStringParser(type);

            if (parser != null)
            {
                object[] paras = new object[2];
                paras[0] = type;
                paras[1] = value;
                //Log.Info("GetString.Invoke : =>" + parser.Name);
                return (string)parser.Invoke(null, paras);
            }
            return string.Empty;
        }

    }

    [ConverterAttribute(typeof(Enum))]
    public class Converter_Enum
    {
        public static string GetString(Type type, object value)
        {
            return (string)value.ToString();
        }

        public static object GetValue(Type type, string value)
        {
            if (value == string.Empty)
                return null;
            return Enum.Parse(type, value);
        }

        public static MethodInfo getEnumValue
        {
            get
            {
                return typeof(Converter_Enum).GetMethod("GetValue");
            }
        }
        public static MethodInfo getEnumString
        {
            get
            {
                return typeof(Converter_Enum).GetMethod("GetString");
            }
        }
    }

    [ConverterAttribute(typeof(String))]
    public class Converter_String
    {
        public static string GetString(Type type, object value)
        {
            return (string)value;
        }

        public static object GetValue(Type type, string value)
        {
            return value;
        }
    }

    [ConverterAttribute(typeof(Byte))]
    public class Converter_Byte
    {
        public static string GetString(Type type, object value)
        {
            return value.ToString();
        }

        public static object GetValue(Type type, string value)
        {
            if (value == string.Empty)
                return 0;
            return Byte.Parse(value);
        }
    }

    [ConverterAttribute(typeof(Int16))]
    public class Converter_Int16
    {
        public static string GetString(Type type, object value)
        {
            return value.ToString();
        }

        public static object GetValue(Type type, string value)
        {
            if (value == string.Empty)
                return 0;
            return Int16.Parse(value);
        }
    }

    [ConverterAttribute(typeof(Int32))]
    public class Converter_Int32
    {
        public static string GetString(Type type, object value)
        {
            return value.ToString();
        }

        public static object GetValue(Type type, string value)
        {
            if (value == string.Empty)
                return 0;
            return Int32.Parse(value);
        }
    }
    [ConverterAttribute(typeof(Int64))]
    public class Converter_Int64
    {
        public static string GetString(Type type, object value)
        {
            return value.ToString();
        }

        public static object GetValue(Type type, string value)
        {
            if (value == string.Empty)
                return 0;
            return Int64.Parse(value);
        }
    }

    [ConverterAttribute(typeof(SByte))]
    public class Converter_SByte
    {
        public static string GetString(Type type, object value)
        {
            return value.ToString();
        }

        public static object GetValue(Type type, string value)
        {
            if (value == string.Empty)
                return 0;
            return SByte.Parse(value);
        }
    }

    [ConverterAttribute(typeof(UInt16))]
    public class Converter_UInt16
    {
        public static string GetString(Type type, object value)
        {
            return value.ToString();
        }

        public static object GetValue(Type type, string value)
        {
            if (value == string.Empty)
                return 0;
            return UInt16.Parse(value);
        }
    }

    [ConverterAttribute(typeof(UInt32))]
    public class Converter_UInt32
    {
        public static string GetString(Type type, object value)
        {
            return value.ToString();
        }

        public static object GetValue(Type type, string value)
        {
            if (value == string.Empty)
                return 0;
            return UInt32.Parse(value);
        }
    }
    [ConverterAttribute(typeof(UInt64))]
    public class Converter_UInt64
    {
        public static string GetString(Type type, object value)
        {
            return value.ToString();
        }

        public static object GetValue(Type type, string value)
        {
            if (value == string.Empty)
                return 0;
            return UInt64.Parse(value);
        }
    }

    [ConverterAttribute(typeof(Single))]
    public class Converter_Single
    {
        public static string GetString(Type type, object value)
        {
            return value.ToString();
        }

        public static object GetValue(Type type, string value)
        {
            if (value == string.Empty)
                return 0;
            return Single.Parse(value);
        }
    }
    [ConverterAttribute(typeof(Double))]
    public class Converter_Double
    {
        public static string GetString(Type type, object value)
        {
            return value.ToString();
        }

        public static object GetValue(Type type, string value)
        {
            if (value == string.Empty)
                return 0;
            return Double.Parse(value);
        }
    }

    [ConverterAttribute(typeof(Boolean))]
    public class Converter_Boolean
    {
        public static string GetString(Type type, object value)
        {
            return value.ToString();
        }

        public static object GetValue(Type type, string value)
        {
            if (value == string.Empty)
                return false;
            if (value == "True")
                return true;
            if (value == "TRUE")
                return true;
            if (value == "0")
                return false;
            if (value == "1")
                return true;
            return Boolean.Parse(value);
        }
    }
}

