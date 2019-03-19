using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace QuantumAlgorithms.DataModels
{
    public class Vector : Matrix, IEquatable<Vector>
    {
        

        /// <summary>
        /// Creates an instance of <see cref="Vector"/>.
        /// </summary>
        /// <param name="complex">Components.</param>
        public Vector(IEnumerable<Complex> complex) : base(complex.ToArray())
        {          
        }

        public Vector(params Complex[] complex) : base(complex)
        {            
        }

        public Vector(Matrix matrix) : base(matrix.To2DArray())
        {
            
        }

        public Complex this[int row]
        {
            get { return this[row, 0]; }
            set { this[row, 0] = value; }
        }

        /// <summary>
        /// Adds two <see cref="Vector"/>s.
        /// </summary>
        public static Vector operator + (Vector a, Vector b)
        {
            if(a.N!= b.N)
                throw new Exception("Vectors must be the same size!");     

            var result = (a as Matrix) + (b as Matrix);

            return new Vector(result);
        }

        /// <summary>
        /// Subtract two <see cref="Vector"/>s.
        /// </summary>
        public static Vector operator - (Vector a, Vector b)
        {
            if (a.N != b.N)
                throw new Exception("Vectors must be the same size!");

            var result = (a as Matrix) - (b as Matrix);

            return new Vector(result);
        }

        /// <summary>
        /// Scalar multiplication of two <see cref="Vector"/>s.
        /// </summary>        
        public static Vector operator * (Complex scalar, Vector vector)
        {
            

            var result = scalar * (vector as Matrix);

            return new Vector(result);
        }



        /// <summary>
        /// Multiplies two <see cref="Vector"/>s.
        /// </summary>
        public static Complex operator | (Vector a, Vector b)
        {
            if (a.N != b.N)
                throw new Exception("Vectors must be the same size!");

            var result = new Complex(0,0);

            for (int i = 0; i < a.N; i++)
            {
                result += a[i,0] * b[i,0].Conjugate;
            }
            return result;
        }

        /// <summary>
        /// Checks if given <see cref="Vector"/>s are equal.
        /// </summary>
        public static bool operator == (Vector a, Vector b)
        {
            if (a.N != b.N)
                return false;

            

            return (Matrix)a == (Matrix)b;
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

        #region IEquatable

        public bool Equals(Vector other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Vector)obj);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
