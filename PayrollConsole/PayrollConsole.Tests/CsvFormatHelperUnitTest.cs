﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class CsvFormatHelperUnitTest
    {
        [TestMethod]
        public void UT_GetAlias()
        {
            try
            {
                IFormatHelper formatter = new CsvFormatHelper();
                Assert.IsNotNull(formatter.getAlias());

                Assert.IsTrue(formatter.getAlias().ToLowerInvariant().CompareTo("csv")==0);
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
                var rowCount = 50;
                var fileName = UtilHelper.generateCsvFile(rowCount);
                IFormatHelper formatter = new CsvFormatHelper();
                var records = formatter.LoadFile<InputFileParameter>(fileName);
                Assert.IsTrue(records.Count() == rowCount);
                return records;
            }
            catch
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
                IFormatHelper formatter = new CsvFormatHelper();
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
