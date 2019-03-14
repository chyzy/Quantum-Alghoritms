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

        public static Qubit Random(int? min = null, int? max = null)
        {
            if (min == null)
                min = 200;
            if (max == null)
                max = 200;            

            var random = new Random();
            var alpha = new Complex(random.Next(min.Value, max.Value), random.Next(min.Value, max.Value));
            var beta = new Complex(random.Next(min.Value, max.Value), random.Next(min.Value, max.Value));

            return new Qubit(alpha,beta);
        }

        public Complex Alpha
        {
            get { return this.Complex[0];}
            protected set { Complex[0] = value; }
        }

        public Complex Beta
        {
            get { return this.Complex[1]; }
            protected set { Complex[1] = value; }
        }

        public Qubit Rotate(double radians)
        {           
            var alpha = (Math.Cos(radians) + Math.Sin(radians)) * Alpha;
            var beta = (-Math.Sin(radians) + Math.Cos(radians)) * Beta;

            return new Qubit(alpha, beta);
        }

        public static Qubit operator | (Qubit qubit, QuantumGate gate)
        {
            var gateMatrix = gate.Matrix;
            var complexMatrix = new Complex[2,1];
            complexMatrix[0, 0] = qubit.Alpha;
            complexMatrix[1, 0] = qubit.Beta;

            var matrix = gateMatrix * new Matrix(complexMatrix);
            return new Qubit(matrix[0,0], matrix[1,0]);

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
