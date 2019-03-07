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
            var a = new Complex(2,3);
            var b = new Complex(0,-2);
            var c = new Complex(5,0);
            var d = new Complex(0,1);
            var v = new Vector(new List<Complex>(){a,b,c,d});

            var e = new Complex(0,-1);
            var f = new Complex(-1,0);
            var g = new Complex(3,-1);
            var h = new Complex(-1,-1);

            var w = new Vector(new List<Complex>(){e,f,g,h});

            var result = v | w;

            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
