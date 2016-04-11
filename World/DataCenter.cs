using GameData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using World.TextProcessor;

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

            InitInnerExpressions();
            InitExternExpressions();
        }

        public static void Save()
        {
            {
                GameData.ExternWord.dataMap.Clear();
                int index = 0;
                foreach (var d in StoreWord.getStore)
                {
                    ExternWord ew = new ExternWord();
                    ew.id = ++index;
                    ew.content = d.Value.content;
                    ew.wordTypes.AddRange(d.Value.typeFunctions);
                    GameData.ExternWord.dataMap.Add(ew.id, ew);
                }

                GameData.ExternWord.SaveGameData();
            }


            {
                GameData.ExternWordType.dataMap.Clear();
                int index = 0;
                foreach (var d in StoreWordType.getStore)
                {
                    ExternWordType ewt = new ExternWordType();
                    ewt.id = ++index;
                    ewt.name = d.Value.name;
                    ewt.parent = d.Value.parent;
                    GameData.ExternWordType.dataMap.Add(ewt.id, ewt);
                }

                GameData.ExternWordType.SaveGameData();
            }

            {
                GameData.ExternExpressionData.dataMap.Clear();
                int index = 0;
                foreach (var d in StoreExpression.getStore)
                {
                    ExternExpressionData ewt = new ExternExpressionData();
                    ewt.id = ++index;
                    ewt.name = d.Value.name;
                    ewt.elements = new List<string>();
                    ewt.linkerParams = new List<LinkerParam>();

                    d.Value.elements.ForEach((item) => ewt.elements.Add(item.wordType));
                    ewt.linkerParams.AddRange(d.Value.LinkParams);
                    GameData.ExternExpressionData.dataMap.Add(ewt.id, ewt);
                }

                GameData.ExternExpressionData.SaveGameData();
            }
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
                w.content = Config.TokenBe;
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
                tf.typeName = Config.TokenQueryPronoun;
                tf.functionName = "Relative";
                w.typeFunctions.Add(tf);

                StoreWord.Add(w.content, w);
            }

            {
                Word w = new Word();
                w.content = Config.TokenSingletonWord;
                WordTypeFunction tf = new WordTypeFunction();
                tf.typeName = Config.TokenSingletonWord;
                tf.functionName = "Relative";
                w.typeFunctions.Add(tf);

                StoreWord.Add(w.content, w);
            }


            {
                Word w = new Word();
                w.content = Config.TokenNoun;
                WordTypeFunction tf = new WordTypeFunction();
                tf.typeName = Config.TokenWordType;
                tf.functionName = "Relative";
                w.typeFunctions.Add(tf);

                StoreWord.Add(w.content, w);
            }

            {
                Word w = new Word();
                w.content = Config.TokenVerb;
                WordTypeFunction tf = new WordTypeFunction();
                tf.typeName = Config.TokenWordType;
                tf.functionName = "Relative";
                w.typeFunctions.Add(tf);

                StoreWord.Add(w.content, w);
            }

            {
                Word w = new Word();
                w.content = Config.TokenCopula;
                WordTypeFunction tf = new WordTypeFunction();
                tf.typeName = Config.TokenWordType;
                tf.functionName = "Relative";
                w.typeFunctions.Add(tf);

                StoreWord.Add(w.content, w);
            }

            {
                Word w = new Word();
                w.content = Config.TokenAux;
                WordTypeFunction tf = new WordTypeFunction();
                tf.typeName = Config.TokenWordType;
                tf.functionName = "Relative";
                w.typeFunctions.Add(tf);

                StoreWord.Add(w.content, w);
            }

            {
                Word w = new Word();
                w.content = Config.TokenCommand;
                WordTypeFunction tf = new WordTypeFunction();
                tf.typeName = Config.TokenCommandType;
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
                try
                {
                    StoreWord.Add(wrod.content, wrod);
                }
                catch
                {

                }
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
                wt.parent = d.Value.parent;
                try
                {
                    StoreWordType.Add(wt.name, wt);
                }
                catch
                {

                }
            }
        }
        static void InitInnerExpressions()
        {
            Assembly asm = typeof(DataCenter).Assembly;
            Type[] types = asm.GetTypes();
            Type baseType = typeof(Expression);

            foreach (var tp in types)
            {
                if (tp.IsSubclassOf(baseType))
                {
                    Expression Expression = (Expression)(tp.GetConstructor(Type.EmptyTypes).Invoke(null));
                    var attrs = tp.GetCustomAttribute(typeof(ExpressionName));
                    if (attrs != null)
                    {
                        Expression.name = ((ExpressionName)attrs).Name;

                        StoreExpression.Add((StoreExpression.getStore.Count + 1).ToString(), Expression);
                    }
                }
            }
        }

        static void InitExternExpressions()
        {
            foreach(var d in GameData.ExternExpressionData.dataMap)
            {
                ExternExpression Expression = new ExternExpression();
                Expression.Init(d.Value);
                try
                {
                    StoreExpression.Add(d.Key.ToString(), Expression);
                }
                catch
                {

                }
            }

        }

        public static string LoadFile(string file)
        {
            string text = File.ReadAllText(file);
            return text;
        }
    }
}
