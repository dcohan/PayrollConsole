using PayrollConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollConsole.Entities;
using Newtonsoft.Json;
using System.IO;

namespace PayrollConsole.Implementation
{
    public class JsonFormatHelper : IFormatHelper
    {
        public JsonFormatHelper()
        {
            
        }

        public string getAlias()
        {
            return "json";
        }

        public IEnumerable<InputFileParameter> LoadFile(string inputFile)
        {
            using (var fileReader = File.OpenText(inputFile))
            {
                return JsonConvert.DeserializeObject<IEnumerable<InputFileParameter>>(fileReader.ReadToEnd());
            }
        }

        public void WriteOutputFile<T>(IEnumerable<T> records, string outputFile)
        {
            using (var fileWriter = File.CreateText(outputFile))
            {
                fileWriter.WriteLine(JsonConvert.SerializeObject(records));
            }
        }
    }
}
