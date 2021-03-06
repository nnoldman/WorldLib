﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.TextProcessor;

namespace World.Object
{
    /// <summary>
    /// nature difference between man and robot
    /// </summary>
    public class Myself : SceneObject
    {
        public delegate void OutHandler(string text);

        public OutHandler outHandler;
        public static Myself Instance
        {
            get
            {
                if (!mInstance)
                {
                    mInstance = new Myself();
                }
                return mInstance;
            }
        }


        static Myself mInstance;

        protected string mContent = string.Empty;

        public Myself()
        {
            {
                var objname = new SceneObjectName();
                objname.name = Config.TokenXiaoLi;
                objname.canRemove = false;
                this.attributes.Add(objname);
            }
            var body = new Body();
            body.hp = 1000;
            body.canRemove = false;
            this.attributes.Add(body);

            var emotion = new Mood();
            emotion.value = 1000;
            emotion.canRemove = false;
            this.attributes.Add(emotion);

            var def = new ObjectDefine();
            def.name = Config.TokenDefineMyself;
            this.attributes.Add(def);

            {
                OutReplaceAttribute attr = new OutReplaceAttribute();
                attr.name = Config.TokenMe;
                attr.target = Config.TokenYou;
                this.attributes.Add(attr);
            }
        }
        public void Close()
        {

        }
        public void Input(string text)
        {
            Option.command.isCommand = text.StartsWith(Config.TokenCommand);
            Scanner scanner = new Scanner();
            var words = scanner.Scan(text);
            Parser parser = new Parser();
            Expression p = parser.Parse(words);
            if (p)
            {
                if (p.IsCmd())
                    p.ExecuteCmd(words);
                else
                    OutPut(p.GenerateAnswer(words));
            }
            else
            {
                //OutPut(Scene.Instance.OutPutObjects());
                OutPut(Scene.Instance.OutPutUnknown());
                //Scene.Instance.OutPut();
            }
        }
        public void Save()
        {
            DataCenter.Save();
        }
        void OutPutAll()
        {
            Scene.Instance.OutPutObjects();
        }
        public void OutPut(string text)
        {
            if (outHandler != null)
                outHandler(text);
        }
        void AddSpace()
        {
            mContent += Config.TokenSpace;
        }
        void AddContent(Nothing sth)
        {
            AddContent(sth.GetContent());
        }
        void AddContent(bool real)
        {
            AddContent(real ? Config.TokenTrue : Config.TokenFalse);
        }
        void AddContent(string text)
        {
            mContent += text;
            AddSpace();
        }

        bool IsDefine(Word target)
        {
            return true;
        }
        void Clear()
        {
            mContent = string.Empty;
        }
    }
}
