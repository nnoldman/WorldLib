﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Parser;

namespace GameData
{
    public class ExternWordType : GameData<ExternWordType>
    {
        static public readonly string fileName = "xml/ExternWordType";
        public string content;
        public string function;

        public List<string> wordTypes = new List<string>();
    }
}
