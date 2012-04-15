using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libpdp11net.Processor.opCodes
{
    internal interface InstructionSet
    {
        void Install(ref Basic11Processor Processor);
    }
}