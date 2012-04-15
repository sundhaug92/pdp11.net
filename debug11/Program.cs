using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libpdp11net;
using libpdp11net.Processor;

namespace debug11
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Basic11Processor Processor = new Basic11Processor();
            while (true)
            {
                Console.Write("DEBUG> ");
                string consoleInput = Console.ReadLine();
                string[] splitConsoleInput = consoleInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                splitConsoleInput[0] = splitConsoleInput[0].ToLower();

                if ((splitConsoleInput[0] == "exit") || (splitConsoleInput[0] == "quit")) break;
            }
        }
    }
}