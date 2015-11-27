using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollConsole.Interfaces;
using PayrollConsole.Implementation;

namespace PayrollConsole.Tests
{
    [TestClass]
    public class RunCmdCommandLineParserTest
    {
        ICommandLineParser getParser()
        {
            Configurator.Configure();

            ICommandLineParser parser = Configurator.getImplementation<ICommandLineParser>();
            parser.setParameters();

            return parser; 
        }

        [TestMethod]
        public void UT_GetHelp()
        {
            var parser = getParser();

            parser.validate(new string[]
            {
                 "/help"
            });
        }

        [TestMethod]
        public void UT_InvalidParameter()
        {
            var parser = getParser();

            try
            {
                parser.validate(new string[]
                {
                 "/invalidswitch"
                });
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Invalid switch"));
            }
        }

        [TestMethod]
        public void UT_MissingParameter()
        {
            var parser = getParser();

            try
            {
                Assert.IsFalse(parser.validate(new string[]
                {
                 "-i",
                 "/path/to/input",
                 "-o"
                }));
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Invalid switch"));
            }
        }

        [TestMethod]
        public void UT_CompleteParameter()
        {
            var parser = getParser();
            try
            {
                Assert.IsTrue(parser.validate(new string[]
                {
                 "-i",
                 "/path/to/input",
                 "-o",
                 "/path/to/output",
                 "-if",
                 "csv",
                 "-of",
                 "json",
                 "-t",
                 "/path/to/tax",
                 "-tf",
                 "json",
                }));
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("Invalid switch"));
            }
        }
    }
}
