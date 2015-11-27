using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PayrollConsole.Interfaces;

namespace PayrollConsole.Tests
{
    [TestClass]
    public class ContainerTest
    {
        [TestMethod]
        public void UT_TestConfiguration()
        {
            Configurator.Configure();

            var log = Configurator.getImplementation<ILogger>();
            Assert .IsNotNull(log);

            var formula = Configurator.getImplementation<IFormulaParser>();
            Assert.IsNotNull(formula);

            var process = Configurator.getImplementation<IProcess>();
            Assert.IsNotNull(process);

            var atLeastOneHelper = Configurator.getImplementation<IFormatHelper> ();
            Assert.IsNotNull(atLeastOneHelper);
        }
    }
}
