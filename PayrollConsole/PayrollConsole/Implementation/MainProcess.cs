using PayrollConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollConsole.Entities;

namespace PayrollConsole.Implementation
{
    public class MainProcess : IProcess
    {
        private List<IFormatHelper> Formatters { get; set; }

        public MainProcess(IEnumerable<IFormatHelper> formatters)
        {
            Formatters = formatters.ToList();
            return;
        }

        public void Execute(string inputFormat, string outputFormat)
        {
            
        }
    }
}
