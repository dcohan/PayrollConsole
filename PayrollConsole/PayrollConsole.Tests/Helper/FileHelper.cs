using PayrollConsole.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollConsole.Tests.Helper
{
    class FileHelper
    {
        public static string generateCsvFile(int rowCount)
        {
            var fileName = Path.GetTempFileName();
            using (var fileWriter = File.CreateText(fileName))
            {
                fileWriter.WriteLine("LastName,Name,AnnualIncome,Month,Super");
                for (int i = 0; i < rowCount; i++)
                {
                    fileWriter.WriteLine(string.Format("LastName{0},Name{0},60000,March,0.1", i));
                }
            }

            return fileName;
        }

        public static string generateJsonFile(int rowCount)
        {
            List<InputFileParameter> list = new List<InputFileParameter>();
            for (int i = 0; i < rowCount; i++)
            {
                list.Add(new InputFileParameter()
                {
                    AnnualIncome = 60000,
                    LastName = string.Format("LastName", i),
                    Name = string.Format("Name", i),
                    Month = "June",
                    Super = 0.2
                });
            }

            var fileName = Path.GetTempFileName();
            using (var fileWriter = File.CreateText(fileName))
            {
                fileWriter.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(list));
            }

            return fileName;
        }
    }
}
