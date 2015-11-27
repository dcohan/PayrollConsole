using PayrollConsole.Entities;
using PayrollConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Configurator.Configure();

            //Retrieve Parser
            var parser = Configurator.getImplementation<ICommandLineParser>();
            parser.setParameters();

            if (parser.validate(args))

            {
                //Retrieve & Execute Process
                var process = Configurator.getImplementation<IProcess>();
                process.Execute(parser.getParameter(CommandLineEnum.InputFormatFile),
                                parser.getParameter(CommandLineEnum.OutputFormatFile),
                                parser.getParameter(CommandLineEnum.TaxFileFormat),
                                parser.getParameter(CommandLineEnum.InputFile),
                                parser.getParameter(CommandLineEnum.OutputFile),
                                parser.getParameter(CommandLineEnum.TaxFile));
            }
        }
    }
}
