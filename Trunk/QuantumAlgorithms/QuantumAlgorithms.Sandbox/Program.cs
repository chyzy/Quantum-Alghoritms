using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuantumAlgorithms.DataModels;
using QuantumAlgorithms.Tools;

namespace QuantumAlgorithms.Sandbox
{
    class Program
    {                
        static void Main(string[] args)
        {
            var array = new Complex[,] {{0, 1}, {1, 0}};
            var mx = new Matrix(array);
            var gate = new QuantumGate(mx);

            var cx = new Complex(0,Math.E)^new Complex(0,0);

            var qubit = new Qubit(1,0);

            Console.WriteLine(qubit | Gates.Hadamard | Gates.Hadamard);

            Console.ReadKey();
        }
    }
}
