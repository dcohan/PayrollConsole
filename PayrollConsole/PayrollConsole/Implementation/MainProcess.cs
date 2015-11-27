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
        private IEnumerable<IFormatHelper> Formatters { get; set; }

        public MainProcess(IEnumerable<IFormatHelper> formatters)
        {
            Formatters = formatters;
        }

        public void Execute(string inputFormat, string outputFormat, string inputFile, string outputFile)
        {
            IFormatHelper inputFormatter = Formatters.Where(f => f.getAlias().ToLowerInvariant().Equals(inputFormat.ToLowerInvariant())).FirstOrDefault();
            if (inputFormatter == null)
            {
                Console.WriteLine("Invalid input formatter");
                return;
            }

            IFormatHelper outputFormatter = Formatters.Where(f => f.getAlias().ToLowerInvariant().Equals(outputFormat.ToLowerInvariant())).FirstOrDefault();
            if (outputFormatter == null)
            {
                Console.WriteLine("Invalid output formatter");
                return;
            }

            var inputRecords = inputFormatter.LoadFile(inputFile);
            var totalRecords = inputRecords.Count();
            var batchSize = 50;
            Console.WriteLine(string.Format( "About to process {0} records in {1} threads.", totalRecords, batchSize));

            //Parallel execution into threads
            List<OutputFileParameter> outputRecords = new List<OutputFileParameter>();
            var batches = this.Split<InputFileParameter>(inputRecords, batchSize);
            Parallel.ForEach<IEnumerable<InputFileParameter>>(batches, (batch) =>
            {
                if (batch != null)
                {
                    foreach (var record in batch)
                    {
                        if (record != null)
                        {
                            outputRecords.Add(new OutputFileParameter()
                            {
                                LastName = record.LastName,
                                Name = record.Name
                            });
                        }
                    }
                }
            });


            outputFormatter.WriteOutputFile<OutputFileParameter>(outputRecords, outputFile);
        }
    }
}
