using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumAlgorithms.DataModels
{
    public static class Constants
    {
        public static readonly int PrecisonDigits = 10;

        public static double PrecisionTolerance = Math.Pow(10, -PrecisonDigits);
    }
}
