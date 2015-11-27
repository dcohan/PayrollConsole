using NCalc;
using PayrollConsole.Entities;
using PayrollConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollConsole.Implementation
{
    public static class ProcessExtensions
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this IProcess p, IEnumerable<T> wholeList, int parts)
        {
            int i = 0;
            var splits = from item in wholeList
                         group item by i++ % parts into part
                         select part.AsEnumerable();
            return splits;
        }

        public static int EvaulateFormula(this InputFileParameter p, string formula, TaxRateParameter rate)
        {
            var finalFormula = formula;
            foreach (var propName in typeof(InputFileParameter).GetProperties())
            {
                finalFormula = finalFormula.Replace(string.Format("[{0}]", propName.Name.ToLowerInvariant()), propName.GetValue(p).ToString());
            }

            foreach (var propName in typeof(TaxRateParameter).GetProperties())
            {
                finalFormula = finalFormula.Replace(string.Format("[{0}]", propName.Name.ToLowerInvariant()), propName.GetValue(rate).ToString());
            }

            var formularParser = Configurator.getImplementation<IFormulaParser>();
            var returnValue = Convert.ToInt32(formularParser.Evaluate(finalFormula));
            return returnValue;
        }
    }
}
