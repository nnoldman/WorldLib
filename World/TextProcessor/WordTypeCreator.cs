﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Processor
{
    public  enum AddWordTypeResult
    {
        Sucess,
        NoParent,
        Existed,
    }
    public  enum SetWordTypeParentResult
    {
        Sucess,
        NoThis,
        NoParent,
        YetHasSameChild,
    }

}