using Autofac;
using Autofac.Core;
using PayrollConsole.Implementation;
using PayrollConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PayrollConsole
{
    class Configurator
    {
        private static IContainer Container { get; set; }

        public static T getImplementation<T>()
        {
            return Container.Resolve<T>();
        }

        public static void Configure()
        {
            var builder = new ContainerBuilder();

            //Register command line parser
            builder.RegisterType<RunCmdCommandLineParser>().As<ICommandLineParser>();

            //Register Logging
            builder.RegisterType<ConsoleLogger>().As<ILogger>();

            //Register Formula Parser
            builder.RegisterType<NCalcFormulaParser>().As<IFormulaParser>();

            //Register all parsers!
            var type = typeof(IFormatHelper);
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                builder.RegisterAssemblyTypes(assembly)
                       .Where(t => type.IsAssignableFrom(t))
                       .AsImplementedInterfaces();
            }

            //Register main process helper
            builder.RegisterType<MainProcess>().As<IProcess>();

            Container = builder.Build();
        }
    }
}
