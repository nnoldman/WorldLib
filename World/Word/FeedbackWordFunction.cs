﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using World.Processor;

namespace World
{
    public class FeedbackWordFunction : WordFunction
    {
        public virtual Feedback GetFeedback()
        {
            return new Feedback();
        }
    }
}
