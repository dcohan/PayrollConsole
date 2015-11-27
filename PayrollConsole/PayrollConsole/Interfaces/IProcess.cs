using PayrollConsole.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollConsole.Interfaces
{
    public interface IProcess
    {
        void Execute(string inputFormat, string outputFormat, string taxFormat, string inputFile, string outputFile, string taxFile);
    }
}
