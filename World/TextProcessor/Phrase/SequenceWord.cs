using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World.Processor
{
    public  class SequenceWord : IBool
    {
        public Word word;
        public SequenceWord left;
        public SequenceWord right;
    }
}
