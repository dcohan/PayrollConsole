using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayrollConsole.Implementation;
using PayrollConsole.Entities;
using System.IO;
using PayrollConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using PayrollConsole.Tests.Helper;

namespace PayrollConsole.Tests
{
  
    [TestClass]
    public class JsonFormatHelperUnitTest
    {
        public IEnumerable<InputFileParameter> LoadInput()
        {
            var rows = 50;
            var fileName = UtilHelper.generateJsonFile(rows);
            IFormatHelper formatter = new JsonFormatHelper();
            var records = formatter.LoadFile<InputFileParameter>(fileName);
            return records;
        }

        [TestMethod]
        public void UT_GetAlias()
        {
            try
            {
                IFormatHelper formatter = new JsonFormatHelper();
                Assert.IsNotNull(formatter.getAlias());

                Assert.IsTrue(formatter.getAlias().ToLowerInvariant().CompareTo("json")==0);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void UT_LoadInput()
        {
            try
            {
                var records = LoadInput();
                Assert.IsTrue(records.Count() == 50);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void UT_WriteOutput()
        {
            try
            {
                var records = LoadInput();
                Assert.IsNotNull(records);

                var outputFile = Path.GetTempFileName();
                IFormatHelper formatter = new JsonFormatHelper();
                formatter.WriteOutputFile<InputFileParameter>(records, outputFile);

                var records2 = formatter.LoadFile<InputFileParameter>(outputFile);
                Assert.IsTrue(records2.Count() == 50);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
    }
}
