﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollConsole.Interfaces
{
    public interface ILogger
    {
        void Log(string message);

        void Log(Exception ex, string message);
    }
}
