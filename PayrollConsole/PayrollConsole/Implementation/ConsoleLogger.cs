using PayrollConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollConsole.Implementation
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void Log(Exception ex, string message)
        {
            Console.WriteLine("An Exception ocurred: "+message);
            Console.WriteLine("See Exception: " + ex.Message);
            Console.WriteLine("Stack Trace: " + ex.StackTrace);
        }
    }
}
