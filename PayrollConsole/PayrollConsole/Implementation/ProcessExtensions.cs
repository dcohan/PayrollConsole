using PayrollConsole.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollConsole.Implementation
{
    public static class ProcessExtensions
    {
        public static IEnumerable<IEnumerable<T>> Split<T>(this IProcess p, IEnumerable<T> wholeList, int parts)
        {
            int i = 0;
            var splits = from item in wholeList
                         group item by i++ % parts into part
                         select part.AsEnumerable();
            return splits;
        }
    }
}
