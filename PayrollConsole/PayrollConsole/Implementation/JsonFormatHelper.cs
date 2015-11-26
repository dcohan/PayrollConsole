using PayrollConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollConsole.Entities;

namespace PayrollConsole.Implementation
{
    public class JsonFormatHelper : IFormatHelper
    {
        public IEnumerable<InputFileParameter> LoadFile(string inputFile)
        {
            throw new NotImplementedException();
        }

        public void WriteOutputFile(List<InputFileParameter> records, string outputFile)
        {
            throw new NotImplementedException();
        }
    }
}
