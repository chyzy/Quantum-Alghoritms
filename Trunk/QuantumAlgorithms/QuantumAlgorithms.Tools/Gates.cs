using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuantumAlgorithms.DataModels;

namespace QuantumAlgorithms.Tools
{
    public static class Gates
    {
        public static QuantumGate Hadamard
        {
            get
            {
                var matrix = new Complex[,]
                {
                    {1/Math.Sqrt(2), 1/Math.Sqrt(2)},
                    {1/Math.Sqrt(2), -1/Math.Sqrt(2) }
                };
                return new QuantumGate(matrix);
            }
        }

        public static QuantumGate PauliX
        {
            get
            {
                var matrix = new Complex[,]
                {
                    {0, 1},
                    {1, 0 }
                };
                return new QuantumGate(matrix);
            }
        }

        public static QuantumGate PauliY
        {
            get
            {
                var matrix = new Complex[,]
                {
                    {0, new Complex(0,-1), },
                    {new Complex(0,1), 0 }
                };
                return new QuantumGate(matrix);
            }
        }

        public static QuantumGate PauliZ
        {
            get
            {
                var matrix = new Complex[,]
                {
                    {1, 0 },
                    {0, -1 }
                };
                return new QuantumGate(matrix);
            }
        }

        public static QuantumGate CNOT
        {
            get
            {
                var matrix = new Complex[,]
                {
                    {1, 0,0, 0},
                    {0, 1, 0, 0},
                    {0, 0, 0, 1},
                    {0, 0, 1, 0},
                };
                return new QuantumGate(matrix);
            }
        }

        //public static QuantumGate T
        //{
        //    get
        //    {
        //        var matrix = new Complex[,]
        //        {
        //            {1, 0 },
        //            {0, new Complex(Math.E,0)^new Complex(0,Math.PI/4),  }
        //        };
        //        return new QuantumGate(matrix);
        //    }
        //}
    }
}
