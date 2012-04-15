using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libpdp11net.Processor.opCode
{
    internal class opCode
    {
        ushort _Mask = 0, _Match = 1; //Set match, so that it won't match with the mask by default

        public void Exec(ref Basic11Processor Processor)
        {
            throw new NotImplementedException();
        }

        public ushort Mask
        {
            get
            {
                return _Mask;
            }
        }

        public ushort Match
        {
            get
            {
                return _Match;
            }
        }
    }
}