using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollConsole.Entities
{
    public class InputFileParameter
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public double AnnualIncome { get; set; }

        public double Super { get; set; }

        public string Month { get; set; }
    }
}
