﻿using PayrollConsole.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollConsole.Interfaces
{
    public interface IFormatHelper
    {
        IEnumerable<T> LoadFile<T>(string inputFile);

        void WriteOutputFile<T>(IEnumerable<T> records, string outputFile);

        string getAlias();
    }
}
