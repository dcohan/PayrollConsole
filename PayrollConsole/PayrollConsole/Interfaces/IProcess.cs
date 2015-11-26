using PayrollConsole.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollConsole.Interfaces
{
    interface IProcess
    {
        void Execute(string inputFormat, string outputFormat);
    }
}
