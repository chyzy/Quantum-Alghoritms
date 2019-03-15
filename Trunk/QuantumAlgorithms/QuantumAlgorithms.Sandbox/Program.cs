using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuantumAlgorithms.DataModels;

namespace QuantumAlgorithms.Sandbox
{
    class Program
    {                
        static void Main(string[] args)
        {
            var array = new Complex[,] {{0, 1}, {1, 0}};
            var mx = new Matrix(array);

            var qubit = Qubit.Random();

            Console.WriteLine(qubit | mx);

            Console.ReadKey();
        }
    }
}
