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
        private static string toOctal(ushort u)
        {
            string s = "", s2 = "";
            ushort u_ = u;
            for (int i = 0; i < 8; i++)
            {
                s += (u_ % 8).ToString();
                u_ /= 8;
            }
            foreach (char c in s.Reverse())
            {
                s2 += c;
            }
            return s2;
        }

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
                if (splitConsoleInput[0] == "register")
                {
                    for (int i = 0; i < 8; i++)
                    {
                        Console.Write(i.ToString() + ": " + toOctal(Processor.Register[i]) + '\t'.ToString());
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}