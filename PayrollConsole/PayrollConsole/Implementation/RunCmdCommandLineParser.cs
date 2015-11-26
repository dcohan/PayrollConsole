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
        private ArgumentParser parser;

        /// <summary>
        /// Path to the input file
        /// </summary>
        private StringArgument inputFileArgument = new StringArgument("InputFile", "Path to the input file", "Path to the input file, could be relative or absolute.");
        /// <summary>
        /// File Input format
        /// </summary>
        private StringArgument formatInputFile = new StringArgument("FormatInputFile", "File format to process the input", "File format to process the input. Could be CSV or JSON");

        /// <summary>
        /// Path to the output file
        /// </summary>
        private StringArgument outputFileArgument = new StringArgument("OutputFile", "Path to the output file", "Path to the output file, could be relative or absolute.");
        /// <summary>
        /// File Output format
        /// </summary>
        private StringArgument formatOutputFile = new StringArgument("FormatOutputFile", "File format to generate the output", "File format to generate the output. Could be CSV or JSON");


        public RunCmdCommandLineParser()
        {
            parser = new ArgumentParser("payroll", "Path to the input file");
        }

        public string getParameter(CommandLineEnum parameter)
        {
            throw new NotImplementedException();
        }

        public T getParameter<T>(CommandLineEnum parameter)
        {
            throw new NotImplementedException();
        }

        public void setParameters(string[] args)
        {
            parser.Add("-", "i", "inputFile", inputFileArgument);
            parser.Add("-", "o", "outputFile", inputFileArgument);
            parser.Add("-", "if", "inFormat", inputFileArgument);
            parser.Add("-", "of", "outFormat", inputFileArgument);

            // parse arguemnts
            parser.Parse(args);

            parser.AboutText = "Payroll calculator is a tool to easy calculate your payroll!\\n If you have a custom provider, please attach your assembly with the implementataion of IFormatHelper, the program will load it automatically";
            parser.CreditsText = "David Cohan";
            parser.UsageText = "payrollConsole -i /path/to/input/file -o /path/to/output/file -if CSV - of JSON";

        }

        public void validate()
        {
            throw new NotImplementedException();
        }
    }
}
