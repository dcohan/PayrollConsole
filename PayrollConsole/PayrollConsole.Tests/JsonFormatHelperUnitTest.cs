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
        public IEnumerable<InputFileParameter> UT_LoadInput()
        {
            try
            {
                var rows = 50;
                var fileName = UtilHelper.generateJsonFile(rows);
                IFormatHelper formatter = new JsonFormatHelper();
                var records = formatter.LoadFile<InputFileParameter>(fileName);
                Assert.IsTrue(records.Count() == 50);
                return records;
            }
            catch(Exception ex)
            {
                Assert.IsTrue(false);
                return null;
            }
        }

        [TestMethod]
        public void UT_WriteOutput()
        {
            try
            {
                var records = UT_LoadInput();
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
