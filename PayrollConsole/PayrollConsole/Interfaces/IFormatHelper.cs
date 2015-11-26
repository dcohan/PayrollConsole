using PayrollConsole.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollConsole.Interfaces
{
    public interface IFormatHelper
    {
        IEnumerable<InputFileParameter> LoadFile(string inputFile);

        void WriteOutputFile(List<InputFileParameter> records, string outputFile);
    }
}
