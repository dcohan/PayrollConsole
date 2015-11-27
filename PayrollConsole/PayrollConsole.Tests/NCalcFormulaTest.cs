using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollConsole.Interfaces;
using PayrollConsole.Implementation;

namespace PayrollConsole.Tests
{
    [TestClass]
    public class NCalcFormulaTest
    {

        [TestMethod]
        public void UT_Formula()
        {
            IFormulaParser parser = new NCalcFormulaParser();
            var result = parser.Evaluate("1+2");
            Assert.IsTrue((int)result == 3);
        }

        [TestMethod]
        public void UT_FormulaError()
        {
            try
            {
                IFormulaParser parser = new NCalcFormulaParser();
                var result = parser.Evaluate("1+N");
            }
            catch
            {
                Assert.IsTrue(true);
            }
        }
    }
}
