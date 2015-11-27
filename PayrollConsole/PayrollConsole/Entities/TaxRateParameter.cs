using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollConsole.Entities
{
    public class TaxRateParameter
    {
        public double BaseIncome { get; set; }
        public double TopIncome { get; set; }
        public double TaxDiscountBase { get; set; }
        public double TaxRate { get; set; }
}
}
