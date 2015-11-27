using NCalc;
using PayrollConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollConsole.Implementation
{
    public class NCalcFormulaParser : IFormulaParser
    {
        public object Evaluate(string formula)
        {
            Expression e = new Expression(formula);
            var returnValue = Convert.ToInt32(e.Evaluate());
            return returnValue;
        }
    }
}
