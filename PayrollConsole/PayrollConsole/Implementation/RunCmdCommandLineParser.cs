using PayrollConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PayrollConsole.Entities;
using Rug.Cmd;

namespace PayrollConsole.Implementation
{
    public class RunCmdCommandLineParser : ICommandLineParser
    {
        /// <summary>
        /// Engine to process the parameters
        /// </summary>
        private ArgumentParser Parser;

        /// <summary>
        /// Path to the input file
        /// </summary>
        private StringArgument InputFileArgument = new StringArgument(CommandLineEnum.InputFile.ToString(), "Path to the input file", "Path to the input file, could be relative or absolute.");
        /// <summary>
        /// File Input format
        /// </summary>
        private StringArgument FormatInputFile = new StringArgument(CommandLineEnum.InputFormatFile.ToString(), "File format to process the input", "File format to process the input. Could be CSV or JSON");

        /// <summary>
        /// Path to the output file
        /// </summary>
        private StringArgument OutputFileArgument = new StringArgument(CommandLineEnum.OutputFile.ToString(), "Path to the output file", "Path to the output file, could be relative or absolute.");
        /// <summary>
        /// File Output format
        /// </summary>
        private StringArgument FormatOutputFile = new StringArgument(CommandLineEnum.OutputFormatFile.ToString(), "File format to generate the output", "File format to generate the output. Could be CSV or JSON");
        /// <summary>
        /// Tax file with the detail income scale rates
        /// </summary>
        private StringArgument TaxFileArgument = new StringArgument(CommandLineEnum.OutputFile.ToString(), "Path to the Tax file", "Path to the tax file, could be relative or absolute.");
        /// <summary>
        /// Tax file format
        /// </summary>
        private StringArgument FormatTaxFile = new StringArgument(CommandLineEnum.OutputFormatFile.ToString(), "File format to read the tax table", "File format to read the tax table. Could be CSV or JSON");

        private ILogger LogManager { get; set; }

        public RunCmdCommandLineParser(ILogger logManager)
        {
            Parser = new ArgumentParser("payroll", "Path to the input file");
            LogManager = logManager;
        }

        public string getParameter(CommandLineEnum parameter)
        {
            switch(parameter)
            {
                case CommandLineEnum.InputFile:
                    return InputFileArgument.Value;
                case CommandLineEnum.InputFormatFile:
                    return FormatInputFile.Value;
                case CommandLineEnum.OutputFile:
                    return OutputFileArgument.Value;
                case CommandLineEnum.OutputFormatFile:
                    return FormatOutputFile.Value;
                case CommandLineEnum.TaxFile:
                    return TaxFileArgument.Value;
                case CommandLineEnum.TaxFileFormat:
                    return FormatTaxFile.Value;
            }

            throw new NotImplementedException();
        }

        public void setParameters()
        {
            Parser.Add("-", "i", "i", InputFileArgument);
            Parser.Add("-", "o", "o", OutputFileArgument);
            Parser.Add("-", "t", "t", TaxFileArgument);
            Parser.Add("-", "if", "if", FormatInputFile);
            Parser.Add("-", "of", "of", FormatOutputFile);
            Parser.Add("-", "tf", "tf", FormatTaxFile);



            Parser.AboutText = "Payroll calculator is a tool to easy calculate your payroll!\\n If you have a custom provider, please attach your assembly with the implementataion of IFormatHelper, the program will load it automatically";
            Parser.CreditsText = "David Cohan";
            Parser.UsageText = "payrollConsole -i /path/to/input/file -o /path/to/output/file -if CSV - of JSON";

        }

        public bool validate(string []args)
        {
            try
            {
                // parse arguemnts
                Parser.Parse(args);

                if (Parser.HelpMode)
                {
                    return false;
                }

                foreach (CommandLineEnum param in Enum.GetValues(typeof(CommandLineEnum)))
                {
                    if (string.IsNullOrEmpty(getParameter(param)))
                    {
                        LogManager.Log("Missing parameter: " + param.ToString());
                        return false;
                    }
                }

                return true;
            }
            catch(Exception ex)
            {
                LogManager.Log(ex, "An Error ocurred with the parameters");
                return false;
            }
        }
    }
}
