using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using libpdp11net.Processor.Exceptions;

namespace libpdp11net.Processor
{
    public class Basic11Processor
    {
        public ushort[] Register = new ushort[8];
        Thread RunningThread;
        List<opCodes.opCode> installedOpCodes = new List<opCodes.opCode>();

        public Basic11Processor()
        {
            RunningThread = new Thread(Run);
            ISInstallBasic();
        }

        #region Instruction-set installation

        #region Basic instruction-set installation

        private void ISInstallBasic()
        {
            ISInstallBasicDoubleOperands();
            ISInstallBasicSingleOperands();
            ISInstallBasicConditionalBranch();
            ISInstallBasicJumpAndSR();
            ISInstallBasicMisc();
            ISInstallBasicConditionCode();
        }

        private void ISInstallBasicConditionCode()
        {
            throw new NotImplementedException();
        }

        private void ISInstallBasicMisc()
        {
            throw new NotImplementedException();
        }

        private void ISInstallBasicJumpAndSR()
        {
            throw new NotImplementedException();
        }

        private void ISInstallBasicConditionalBranch()
        {
            throw new NotImplementedException();
        }

        private void ISInstallBasicSingleOperands()
        {
            throw new NotImplementedException();
        }

        private void ISInstallBasicDoubleOperands()
        {
            InstallOpcode(new opCodes.Basic.DoubleOperand.ADD());
            InstallOpcode(new opCodes.Basic.DoubleOperand.BIC());
            InstallOpcode(new opCodes.Basic.DoubleOperand.BICB());
            InstallOpcode(new opCodes.Basic.DoubleOperand.BIS());
            InstallOpcode(new opCodes.Basic.DoubleOperand.BISB());
            InstallOpcode(new opCodes.Basic.DoubleOperand.BIT());
            InstallOpcode(new opCodes.Basic.DoubleOperand.BITB());
            InstallOpcode(new opCodes.Basic.DoubleOperand.CMP());
            InstallOpcode(new opCodes.Basic.DoubleOperand.CMPB());
            InstallOpcode(new opCodes.Basic.DoubleOperand.MOV());
            InstallOpcode(new opCodes.Basic.DoubleOperand.MOVB());
            InstallOpcode(new opCodes.Basic.DoubleOperand.SUB());
        }

        #endregion Basic instruction-set installation

        public void InstallOpcode(opCodes.opCode o)
        {
            installedOpCodes.Add(o);
        }

        #endregion Instruction-set installation

        public void Step()
        {
            //Add interrupt request testing here
            //Add instruction decoding and execution here
            ushort opcode = readFromPhys16(Register[7]);
            foreach (opCodes.opCode o in installedOpCodes)
            {
                if ((opcode & o.Mask) == (o.Mask & o.Match))
                {
                    o.Exec(this);
                    return;
                }
            }
            throw new opCodeNotImplemented();
        }

        private ushort readFromPhys16(ushort p)
        {
            throw new NotImplementedException();
        }

        public void Run() //Worker - Run PDP 11 code
        {
            while (true) Step();
        }

        public void Start() //Start worker
        {
            if (!RunningThread.IsAlive) RunningThread.Start();
        }

        public void Stop() //Abort worker
        {
            if (RunningThread.IsAlive) RunningThread.Abort();
        }
    }
}