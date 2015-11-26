using PayrollConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollConsole.Entities;
using System.IO;

namespace PayrollConsole.Implementation
{
    public class CsvFormatHelper : IFormatHelper
    {
        public IEnumerable<InputFileParameter> LoadFile(string inputFile)
        {
            using (var fileReader = File.OpenText(inputFile))
            {
                CsvHelper.CsvReader r = new CsvHelper.CsvReader(fileReader);
                return r.GetRecords<InputFileParameter>();
            }
        }

        public void WriteOutputFile(List<InputFileParameter> records, string outputFile)
        {
            throw new NotImplementedException();
        }
    }
}
