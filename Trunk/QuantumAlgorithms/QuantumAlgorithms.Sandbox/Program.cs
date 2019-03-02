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
            var a = new Complex(1, Math.PI/2,true);

            Console.WriteLine(a^3);

            Console.ReadKey();
        }
    }
}
