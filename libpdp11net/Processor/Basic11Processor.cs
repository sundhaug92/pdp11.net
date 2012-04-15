using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace libpdp11net.Processor
{
    internal class Basic11Processor
    {
        ushort[] Register = new ushort[8];
        Thread RunningThread;

        public Basic11Processor()
        {
            RunningThread = new Thread(Run);
        }

        public void Step()
        {
            //Add interrupt request testing here
            //Add instruction decoding and execution here
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