using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using World.Processor;

namespace World
{
    public class DataCenter
    {
        public static void Initialize()
        {
            ALog.setInfoHandler(Logger.Log);
            ALog.setWarningHandler(Logger.Log);
            ALog.setErrorHandler(Logger.Log);

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
            {
                Word w = new Word();
                w.content = Config.TokenYou;
                WordTypeFunction tf = new WordTypeFunction();
                tf.typeName = Config.TokenPronoun;
                tf.functionName = "Relative";
                w.typeFunctions.Add(tf);

                StoreWord.Add(w.content, w);
            }
            {
                Word w = new Word();
                w.content = Config.TokenBe1;
                WordTypeFunction tf = new WordTypeFunction();
                tf.typeName = Config.TokenCopula;
                tf.functionName = "Is";
                w.typeFunctions.Add(tf);

                StoreWord.Add(w.content, w);
            }
            {
                Word w = new Word();
                w.content = Config.TokenMe;
                WordTypeFunction tf = new WordTypeFunction();
                tf.typeName = Config.TokenPronoun;
                tf.functionName = "Relative";
                w.typeFunctions.Add(tf);

                StoreWord.Add(w.content, w);
            }

            {
                Word w = new Word();
                w.content = Config.TokenWho;
                WordTypeFunction tf = new WordTypeFunction();
                tf.typeName = Config.TokenPronoun;
                tf.functionName = "Relative";
                w.typeFunctions.Add(tf);

                StoreWord.Add(w.content, w);
            }
        }
        static void InitExternWords()
        {
            foreach (var d in GameData.ExternWord.dataMap)
            {
                Word wrod = new Word();
                wrod.content = d.Value.content;
                wrod.typeFunctions.AddRange(d.Value.wordTypes);
                StoreWord.Add(wrod.content, wrod);
            }
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
                        WordType wordtype =(WordType) (tp.GetConstructor(Type.EmptyTypes).Invoke(null));
                        wordtype.name = typename.Name;
                        wordtype.parent = typename.ParentName;
                        StoreWordType.Add(typename.Name, (WordType)wordtype);
                    }
                }
            }
        }
        static void InitExternWordTypes()
        {
            foreach (var d in GameData.ExternWordType.dataMap)
            {
                WordType wt = new WordType();
                wt.name = d.Value.name;
                StoreWordType.Add(wt.name, wt);
            }
        }
        static void InitInnerPhrases()
        {
            Assembly asm = typeof(DataCenter).Assembly;
            Type[] types = asm.GetTypes();
            Type baseType = typeof(Phrase);

            foreach (var tp in types)
            {
                if (tp.IsSubclassOf(baseType))
                {
                    Phrase phrase = (Phrase)(tp.GetConstructor(Type.EmptyTypes).Invoke(null));
                    var attrs = tp.GetCustomAttribute(typeof(PhraseName));
                    if (attrs != null)
                    {
                        phrase.name = ((PhraseName)attrs).Name;
                        StorePhrase.Add(phrase.name, phrase);
                    }
                }
            }
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
