using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using World.Parser;

namespace World
{
    public class DataCenter
    {
        public static void Initialize()
        {
            ALog.setInfoHandler(Logger.Log);
            ALog.setWarningHandler(Logger.Log);
            ALog.setErrorHandler(Logger.Log);

            TypeScaner.InitTypes(typeof(TypeScaner).Assembly);

            TypeScaner.OnProcess.Add(GameData.Converter.OnScanType);
            TypeScaner.InitTypes(typeof(TypeScaner).Assembly);

            GameDataLoader.textLoader = LoadFile;
            GameDataLoader.Instance.Init(typeof(DataCenter).Assembly);

            InitInnerWordTypes();
            InitExternWordTypes();

            InitInnerWords();
            InitExternWords();

            InitInnerPhrases();
            InitExternPhrases();
        }
        static void InitInnerWords()
        {

        }
        static void InitExternWords()
        {

        }
        static void InitInnerWordTypes()
        {
            Assembly asm = typeof(DataCenter).Assembly;
            Type[] types = asm.GetTypes();
            Type baseType = typeof(WordType);

            foreach (var tp in types)
            {
                if (tp.IsSubclassOf(baseType))
                {
                    Attribute attr = tp.GetCustomAttribute(typeof(WordTypeName));
                    if (attr != null)
                    {
                        WordTypeName typename = (WordTypeName)attr;
                        object wordtype = (tp.GetConstructor(Type.EmptyTypes).Invoke(null));
                        StoreWordType.Add(typename.Name, (WordType)wordtype);
                    }
                }
            }
        }
        static void InitExternWordTypes()
        {

        }
        static void InitInnerPhrases()
        {

        }

        static void InitExternPhrases()
        {

        }

        public static string LoadFile(string file)
        {
            string text = File.ReadAllText(file);
            return text;
        }
    }
}
