using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using libpdp11net.Processor.Exceptions;

namespace libpdp11net.Processor
{
    internal class Basic11Processor
    {
        ushort[] Register = new ushort[8];
        Thread RunningThread;
        List<opCode.opCode> opCodes = new List<opCode.opCode>();

        public Basic11Processor()
        {
            RunningThread = new Thread(Run);
        }

        public void InstallOpcode(opCode.opCode o)
        {
            opCodes.Add(o);
        }

        public void Step()
        {
            //Add interrupt request testing here
            //Add instruction decoding and execution here
            ushort opcode = readFromPhys16(Register[7]);
            foreach (opCode.opCode o in opCodes)
            {
                if ((opcode & o.Mask) == (o.Mask & o.Match))
                {
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