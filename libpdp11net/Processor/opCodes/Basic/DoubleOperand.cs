using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libpdp11net.Processor.opCodes.Basic
{
    internal class ISDoubleOperand : InstructionSet
    {
        public void Install(ref Basic11Processor Processor)
        {
            Processor.InstallOpcode(new DoubleOperand.ADD());
            Processor.InstallOpcode(new DoubleOperand.BIC());
            Processor.InstallOpcode(new DoubleOperand.BICB());
            Processor.InstallOpcode(new DoubleOperand.BIS());
            Processor.InstallOpcode(new DoubleOperand.BISB());
            Processor.InstallOpcode(new DoubleOperand.BIT());
            Processor.InstallOpcode(new DoubleOperand.BITB());
            Processor.InstallOpcode(new DoubleOperand.CMP());
            Processor.InstallOpcode(new DoubleOperand.CMPB());
            Processor.InstallOpcode(new DoubleOperand.MOV());
            Processor.InstallOpcode(new DoubleOperand.MOVB());
            Processor.InstallOpcode(new DoubleOperand.SUB());
        }
    }
}