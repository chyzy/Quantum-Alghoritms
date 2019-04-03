using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumAlgorithms.DataModels
{

    public class Qubit : Vector
    {
        public Qubit(Complex alpha, Complex beta) : base(alpha,beta)
        {        
            
        }

        public static Qubit Random()
        {
            var random  = new Random();

            var alpha = random.NextDouble();

            var beta = Math.Sqrt(1 - Math.Pow(alpha,2));

            return new Qubit(alpha,beta);
        }

        public Complex Alpha
        {
            get { return this[0,0];}
            protected set { this[0,1] = value; }
        }

        public Complex Beta
        {
            get { return this[1,0]; }
            protected set { this[1,0] = value; }
        }

        public Qubit Rotate(double radians)
        {           
            var alpha = (Math.Cos(radians) + Math.Sin(radians)) * Alpha;
            var beta = (-Math.Sin(radians) + Math.Cos(radians)) * Beta;

            return new Qubit(alpha, beta);
        }

        public bool Measure()
        {
            var random = new Random();
            var probablitity = this.Alpha * this.Alpha;

            return random.NextDouble() >= probablitity.Real;
        }

        public static Qubit operator | (Qubit qubit, QuantumGate gate)
        {                       
            var matrix = gate * new Matrix(qubit);
            return new Qubit(matrix[0,0], matrix[1,0]);

        }

        public static Vector operator * (Qubit first, Qubit second)
        {            
            var result = new List<Complex>();

            for (int a = 0; a < first.N; a++)
            {
                for (int b = 0; b < second.N; b++)
                {
                    result.Add(first[a,0] * second[b,0]);
                }
            }
            return new Vector(result);
        }

        public override string ToString()
        {
            var a = Alpha.ToString();
            var b = Beta.ToString();
            if (a.Contains('+') || a.Contains('-')) a = "(" + a + ")";
            if (b.Contains('+') || b.Contains('-')) b = "(" + b + ")";
            return a + "|0> + " + b + "|1>";

        }
    }
}
