using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollConsole.Interfaces
{
    public interface IFormulaParser
    {
        object Evaluate(string formula);
    }
}
