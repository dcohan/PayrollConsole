using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PayrollConsole.Entities;
using PayrollConsole.Implementation;
using PayrollConsole.Interfaces;
using PayrollConsole.Tests.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollConsole.Tests
{
    [TestClass]
    public class MainProcessTest
    {
        private const string filePathInput = "/path/to/input";
        private const string filePathOutput = "/path/to/output";
        private const string  filePathTax = "/path/to/tax";

        private MainProcess ConfigureApp()
        {
            Mock<ILogger> log = new Mock<ILogger>(MockBehavior.Loose);

            Mock<IFormatHelper> csvFormatter = new Mock<IFormatHelper>(MockBehavior.Strict);
            csvFormatter.Setup(f => f.getAlias()).Returns("csv");
            csvFormatter.Setup(f => f.LoadFile<InputFileParameter>(filePathInput)).Returns(UtilHelper.getInputList(5));

            Mock<IFormatHelper> jsonFormatter = new Mock<IFormatHelper>(MockBehavior.Strict);
            jsonFormatter.Setup(f => f.getAlias()).Returns("json");
            jsonFormatter.Setup(f => f.LoadFile<InputFileParameter>(filePathInput)).Returns(UtilHelper.getInputList(5));


            List<IFormatHelper> formatters = new List<IFormatHelper>();
            formatters.Add(csvFormatter.Object);
            formatters.Add(jsonFormatter.Object);

            MainProcess p = new MainProcess(formatters, log.Object);

            return p;

        }

        [TestMethod]
        public void UT_TestInvalidInputFormatter()
        {
            try
            {
                var main = ConfigureApp();
                Assert.IsFalse(main.Execute("invalidformatter", "csv", "csv", filePathInput, filePathOutput, filePathTax));
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void UT_TestInvalidOutputFormatter()
        {
            try
            {
                var main = ConfigureApp();
                Assert.IsFalse(main.Execute("csv", "Invalidformatter", "csv", filePathInput, filePathOutput, filePathTax));
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void UT_TestInvalidTaxFormatter()
        {
            try
            {
                var main = ConfigureApp();
                Assert.IsFalse(main.Execute("csv", "json", "Invalidformatter", filePathInput, filePathOutput, filePathTax));
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void UT_ProcessFileCsvToJson()
        {
            try
            {
                var main = ConfigureApp();
                Assert.IsFalse(main.Execute("csv", "json", "csv", filePathInput, filePathOutput, filePathTax));
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void UT_ProcessFileJsonToCsv()
        {
            try
            {
                var main = ConfigureApp();
                Assert.IsFalse(main.Execute("json", "csv", "csv", filePathInput, filePathOutput, filePathTax));
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
    }
}
