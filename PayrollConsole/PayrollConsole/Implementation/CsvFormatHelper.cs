using PayrollConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollConsole.Entities;
using System.IO;
using CsvHelper;

namespace PayrollConsole.Implementation
{
    public class CsvFormatHelper : IFormatHelper
    {
        public string getAlias()
        {
            return "csv";
        }

        public IEnumerable<T> LoadFile<T>(string inputFile)
        {
            IEnumerable<T> records;
            using (var fileReader = File.OpenText(inputFile))
            {
                CsvHelper.CsvReader r = new CsvHelper.CsvReader(fileReader);
                records = r.GetRecords<T>().ToList();
            }

            return records;
        }

        public void WriteOutputFile<T>(IEnumerable<T> records, string outputFile)
        {
            using (var fileWritter = File.CreateText(outputFile))
            {
                CsvHelper.CsvWriter w = new CsvHelper.CsvWriter(fileWritter);
                w.WriteHeader<T>();
                w.WriteRecords(records);
            }
        }
    }
}
