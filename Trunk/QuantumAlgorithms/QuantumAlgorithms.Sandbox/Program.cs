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
            var a = new Complex(0,1);

            var b = a ^ 3;

            Console.WriteLine(b);

            Console.ReadKey();
        }
    }
}
