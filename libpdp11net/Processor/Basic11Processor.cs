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
        }

        public void Run()
        {
            while (true) Step();
        }

        public void Start()
        {
            if (!RunningThread.IsAlive) RunningThread.Start();
        }

        public void Stop()
        {
            if (RunningThread.IsAlive) RunningThread.Abort();
        }
    }
}