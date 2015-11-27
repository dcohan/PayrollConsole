using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PayrollConsole.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollConsole.Tests
{
    [TestClass]
    public class ConsoleLogTest
    {
        [TestMethod]
        public void UT_LogToConsole()
        {
            try
            {
                var log = new ConsoleLogger();
                log.Log("this is a test mesage");
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }

        }

        [TestMethod]
        public void UT_LogExceptionToConsole()
        {
            try
            {
                var log = new ConsoleLogger();
                log.Log(new Exception("this is a test exception"), "this is a test mesage");
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }

        }
    }
}
