using PayrollConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayrollConsole.Entities;
using System.Configuration;

namespace PayrollConsole.Implementation
{
    public class MainProcess : IProcess
    {
        private IEnumerable<IFormatHelper> Formatters { get; set; }
        private ILogger LogManager { get; set; }

        public MainProcess(IEnumerable<IFormatHelper> formatters, ILogger logManager)
        {
            Formatters = formatters;
            LogManager = logManager;
        }

        public void Execute(string inputFormat, string outputFormat, string taxFormat, string inputFile, string outputFile, string taxFile)
        {
            try
            {
                IFormatHelper inputFormatter = Formatters.Where(f => f.getAlias().ToLowerInvariant().Equals(inputFormat.ToLowerInvariant())).FirstOrDefault();
                if (inputFormatter == null)
                {
                    LogManager.Log("Invalid input formatter");
                    return;
                }

                IFormatHelper outputFormatter = Formatters.Where(f => f.getAlias().ToLowerInvariant().Equals(outputFormat.ToLowerInvariant())).FirstOrDefault();
                if (outputFormatter == null)
                {
                    LogManager.Log("Invalid output formatter");
                    return;
                }

                IFormatHelper taxFormatter = Formatters.Where(f => f.getAlias().ToLowerInvariant().Equals(taxFormat.ToLowerInvariant())).FirstOrDefault();
                if (outputFormatter == null)
                {
                    LogManager.Log("Invalid tax formatter");
                    return;
                }

                //Load tax table
                var taxTable = taxFormatter.LoadFile<TaxRateParameter>(taxFile);

                //Load input records
                var inputRecords = inputFormatter.LoadFile<InputFileParameter>(inputFile);
                var totalRecords = inputRecords.Count();
                var batchSize = Convert.ToInt32(ConfigurationManager.AppSettings.Get("ThreadCount").ToLowerInvariant());
                LogManager.Log(string.Format("About to process {0} records in {1} threads.", totalRecords, batchSize));

                //Parallel execution into threads
                var grossIncomeFormula = ConfigurationManager.AppSettings.Get("GrossIncomeFormula").ToLowerInvariant();
                var incomeTaxFormula = ConfigurationManager.AppSettings.Get("IncomeTaxFormula").ToLowerInvariant();
                var netIncomeFormula = ConfigurationManager.AppSettings.Get("NetIncomeFormula").ToLowerInvariant();
                var superFormula = ConfigurationManager.AppSettings.Get("SuperFormula").ToLowerInvariant();

                List<OutputFileParameter> outputRecords = new List<OutputFileParameter>();
                var batches = this.Split<InputFileParameter>(inputRecords, batchSize);
                Parallel.ForEach<IEnumerable<InputFileParameter>>(batches, (batch) =>
                {
                    if (batch != null)
                    {
                        foreach (var record in batch)
                        {
                            var taxIncomeSelected = taxTable.Where(t => record.AnnualIncome >= t.BaseIncome && record.AnnualIncome <= t.TopIncome).FirstOrDefault();
                            if (record != null)
                            {
                                outputRecords.Add(new OutputFileParameter()
                                {
                                    LastName = record.LastName,
                                    Name = record.Name,
                                    Month = record.Month,
                                    GrossIncomeFormula = record.EvaulateFormula(grossIncomeFormula, taxIncomeSelected),
                                    IncomeTaxFormula = record.EvaulateFormula(incomeTaxFormula, taxIncomeSelected),
                                    NetIncomeFormula = record.EvaulateFormula(netIncomeFormula, taxIncomeSelected),
                                    SuperFormula = record.EvaulateFormula(superFormula, taxIncomeSelected)
                                });

                            //Log  every 50 records processed   
                            var processedRecords = outputRecords.Count();
                                if (processedRecords > 50 && processedRecords % 50 == 0)
                                {
                                    LogManager.Log(string.Format("Processed {0} records", processedRecords));
                                }
                            }
                        }
                    }
                });


                outputFormatter.WriteOutputFile<OutputFileParameter>(outputRecords, outputFile);
            }
            catch(Exception ex)
            {
                LogManager.Log(ex, "An error occured procesing the input");
            }
        }
    }
}
