using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace QuantumAlgorithms.DataModels
{
    public class Vector
    {
        public List<Complex> Complex;

        public Vector(IEnumerable<Complex> complex)
        {
            Complex = complex.ToList();
        }

        public static Vector operator + (Vector a, Vector b)
        {
            if(a.Complex.Count()!= b.Complex.Count())
                throw new Exception("Waktory muszą być tego samego wymiaru!");

            var args = new List<Complex>();

            for (int i = 0; i < a.Complex.Count(); i++)
            {
                args.Add(a.Complex[i]+b.Complex[i]);
            }

            return new Vector(args);
        }

        public static Vector operator - (Vector a, Vector b)
        {
            if (a.Complex.Count() != b.Complex.Count())
                throw new Exception("Waktory muszą być tego samego wymiaru!");

            var args = new List<Complex>();

            for (int i = 0; i < a.Complex.Count(); i++)
            {
                args.Add(a.Complex[i] - b.Complex[i]);
            }

            return new Vector(args);
        }

        public static Vector operator * (Vector a, Complex b)
        {        
            var args = new List<Complex>();

            for (int i = 0; i < a.Complex.Count(); i++)
            {
                args.Add(a.Complex[i] * b );
            }

            return new Vector(args);
        }

        public static Complex operator | (Vector a, Vector b)
        {
            if (a.Complex.Count() != b.Complex.Count())
                throw new Exception("Wektory muszą być tego samego wymiaru!");

            var result = new Complex(0,0);

            for (int i = 0; i < a.Complex.Count; i++)
            {
                result += a.Complex[i]* b.Complex[i].Conjugate;
            }
            return result;
        }

        public double Length()
        {
            var scalar = this | this;
            if(scalar.Imaginary!=0)
                throw new Exception("Cześć urojona jest różna od 0");
            return Math.Sqrt(scalar.Real);
        }


    }
}
