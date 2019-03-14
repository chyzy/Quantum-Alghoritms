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
            var pauliX = new QuantumGate(new Matrix(new Complex[,]{{0,1},{1,0}}));

            var qubit = new Qubit(0,1);

            Console.WriteLine(qubit | pauliX);

            Console.ReadKey();
        }
    }
}
