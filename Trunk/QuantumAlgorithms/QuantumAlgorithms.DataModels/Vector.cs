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
        public List<Complex> Complex { get; protected set; }

        /// <summary>
        /// Creates an instance of <see cref="Vector"/>.
        /// </summary>
        /// <param name="complex">Components.</param>
        public Vector(IEnumerable<Complex> complex)
        {
            Complex = complex.ToList();
        }

        public Vector(params Complex[] complex)
        {
            this.Complex = complex.ToList();
        }

        /// <summary>
        /// Adds two <see cref="Vector"/>s.
        /// </summary>
        public static Vector operator + (Vector a, Vector b)
        {
            if(a.Complex.Count()!= b.Complex.Count())
                throw new Exception("Vectors must be the same size!");

            var args = new List<Complex>();

            for (int i = 0; i < a.Complex.Count(); i++)
            {
                args.Add(a.Complex[i]+b.Complex[i]);
            }

            return new Vector(args);
        }

        /// <summary>
        /// Subtract two <see cref="Vector"/>s.
        /// </summary>
        public static Vector operator - (Vector a, Vector b)
        {
            if (a.Complex.Count() != b.Complex.Count())
                throw new Exception("Vectors must be the same size!");

            var args = new List<Complex>();

            for (int i = 0; i < a.Complex.Count(); i++)
            {
                args.Add(a.Complex[i] - b.Complex[i]);
            }

            return new Vector(args);
        }

        /// <summary>
        /// Multiplies two <see cref="Vector"/>s.
        /// </summary>
        public static Vector operator * (Vector a, Complex b)
        {        
            var args = new List<Complex>();

            for (int i = 0; i < a.Complex.Count(); i++)
            {
                args.Add(a.Complex[i] * b );
            }

            return new Vector(args);
        }

        /// <summary>
        /// Scalar multiplication of two <see cref="Vector"/>s.
        /// </summary>
        public static Complex operator | (Vector a, Vector b)
        {
            if (a.Complex.Count != b.Complex.Count)
                throw new Exception("Vectors must be the same size!");

            var result = new Complex(0,0);

            for (int i = 0; i < a.Complex.Count; i++)
            {
                result += a.Complex[i]* b.Complex[i].Conjugate;
            }
            return result;
        }

        /// <summary>
        /// Checks if given <see cref="Vector"/>s are equal.
        /// </summary>
        public static bool operator == (Vector a, Vector b)
        {
            if (a.Complex.Count != b.Complex.Count)
                return false;

            var result = true;

            for (int i = 0; i < a.Complex.Count; i++)
            {
                result &= a.Complex[i] == b.Complex[i];
            }

            return result;
        }

        /// <summary>
        /// Checks if given <see cref="Vector"/>s are equal.
        /// </summary>
        public static bool operator != (Vector a, Vector b)
        {
            return !(a == b);
        }

        /// <summary>
        /// An absolute length of the <see cref="Vector"/>.
        /// </summary>       
        public double Length
        {
            get
            {
                var scalar = this | this;
                if (Math.Abs(scalar.Imaginary) > Constants.PrecisionTolerance)
                    throw new Exception("An imaginary part is not equal 0");
                return Math.Sqrt(scalar.Real);
            }
        }      
    }
}
