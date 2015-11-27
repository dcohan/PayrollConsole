using PayrollConsole.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollConsole.Interfaces
{
    interface ICommandLineParser
    {
        bool validate(string[] args);

        void setParameters();
        string getParameter(CommandLineEnum parameter);
    }
}
