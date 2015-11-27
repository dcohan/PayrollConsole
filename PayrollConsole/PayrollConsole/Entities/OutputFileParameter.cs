using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollConsole.Entities
{
    public class OutputFileParameter
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public string Month { get; set; }

        public int GrossIncomeFormula { get; set; }
        public int IncomeTaxFormula { get; set; }
        public int NetIncomeFormula { get; set; }
        public int SuperFormula { get; set; }
    }
}
