using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumAlgorithms.DataModels
{
    /// <summary>
    /// Represents the complex number.
    /// </summary>
    public class Complex : IEquatable<Complex>
    {
        private readonly double _real;
        private readonly double _imaginary;
        private static readonly int _precision = 3;

        /// <summary>
        /// Creates an instance of <see cref="Complex"/>.
        /// </summary>
        /// <param name="real">Real part.</param>
        /// <param name="imaginary">Imaginary part.</param>
        public Complex(double real, double imaginary)
        {
            _real = real;
            _imaginary = imaginary;
        }

        /// <summary>
        /// Creates an instance of <see cref="Complex"/>.
        /// </summary>
        /// <param name="module">Complex number's module.</param>
        /// <param name="alpha">Complex number's alpha angle.</param>
        /// <param name="isTrigonometric"></param>
        public Complex(double module, double alpha, bool isTrigonometric)
        {
            _real = Math.Round(module * Math.Cos(alpha), _precision);
            _imaginary = Math.Round(module * Math.Sin(alpha), _precision);
        }

        /// <summary>
        /// Gets the real part value.
        /// </summary>
        public double Real
        {
            get { return _real;}
        }

        /// <summary>
        ///  Gets the imaginary part value.
        /// </summary>
        public double Imaginary
        {
            get { return _imaginary; }
        }

        /// <summary>
        /// Returns the alpha angle.
        /// </summary>
        public double Alpha
        {
            get
            {
                var result = Math.Atan2(_imaginary, _real);
                return result >= 0 ?
                    result :
                    Math.PI * 2 + result;
            } 
        }

        /// <summary>
        /// Returns the module. 
        /// </summary>
        public double Module
        {
            get { return Math.Sqrt(Math.Pow(_real, 2) + Math.Pow(_imaginary, 2)); }
        }

        /// <summary>
        /// Returns the conjugate.
        /// </summary>
        public Complex Conjugate
        {
            get
            {
                return new Complex(_real, -_imaginary);
            }
        }

        /// <summary>
        /// Adds two <see cref="Complex"/> numbers.
        /// </summary>
        /// <param name="a">Term.</param>
        /// <param name="b">Term.</param>
        /// <returns>Sum.</returns>
        public static Complex operator + (Complex a, Complex b)
        {
            return new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
        }

        /// <summary>
        /// Subtracts two <see cref="Complex"/> numbers.
        /// </summary>
        /// <param name="a">Term.</param>
        /// <param name="b">Term.</param>
        /// <returns>Difference</returns>
        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
        }

        /// <summary>
        /// Multiplies two <see cref="Complex"/> numbers.
        /// </summary>
        /// <param name="a">Factor.</param>
        /// <param name="b">Factor.</param>
        /// <returns>Product.</returns>
        public static Complex operator * (Complex a, Complex b)
        {
            var real = a.Real * b.Real - a.Imaginary * b.Imaginary;
            var imaginary = a.Real * b.Imaginary + a.Imaginary * b.Real;
            return new Complex(real, imaginary);
        }

        /// <summary>
        /// Divides two <see cref="Complex"/> numbers.
        /// </summary>
        /// <param name="a">Dividend.</param>
        /// <param name="b">Divisor.</param>
        /// <returns>Quotient.</returns>
        public static Complex operator /(Complex a, Complex b)
        {
            var real = (a.Real * b.Real + a.Imaginary * b.Imaginary) / (b.Real * b.Real + b.Imaginary * b.Imaginary);
            var imaginary = (a.Imaginary * b.Real - a.Real * b.Imaginary) / (b.Real * b.Real + b.Imaginary * b.Imaginary);
            return new Complex(real, imaginary);
        }

        /// <summary>
        /// Raises the <see cref="Complex"/> number to given power.
        /// </summary>
        /// <param name="a">Base.</param>
        /// <param name="power">Power.</param>
        /// <returns>Power of <param name="a"></param></returns>
        public static Complex operator ^ (Complex a, double power)
        {
            var module = Math.Pow(a.Module, power);
            var alpha = a.Alpha * power;
            return new Complex(module, alpha, true);
        }

        /// <summary>
        /// Checks if given <see cref="Complex"/> numbers are equal.
        /// </summary>
        /// <returns>True if numbers are equal.</returns>
        public static bool operator == (Complex a, Complex b)
        {
            return a.Equals(b);
        }

        /// <summary>
        /// Checks if given <see cref="Complex"/> numbers are different.
        /// </summary>
        /// <returns>True if given numbers are different.</returns>
        public static bool operator != (Complex a, Complex b)
        {
            return !a.Equals(b);
        }

        public override string ToString()
        {
            return _imaginary >= 0 ?
                $"{_real}+{_imaginary}i" :
                $"{_real}{_imaginary}i";
        }

        public string ToString(bool inTrigonometric)
        {
            if (!inTrigonometric)
                return this.ToString();
            return this.Alpha >= 0
                ? $"{this.Module}*(cos {this.Alpha} + isin {this.Alpha})"
                : $"{this.Module}*(cos {this.Alpha} - isin {Math.Abs(this.Alpha)})";

        }

        public bool Equals(Complex other)
        {
            return this.Real == other.Real && this.Imaginary == other.Imaginary;
        }

        public override bool Equals(object obj)
        {
            var complex = obj as Complex;
            return complex != null && Equals(complex);
        }

        public override int GetHashCode()
        {
            var hashCode = -837395861;
            hashCode = hashCode * -1521134295 + Real.GetHashCode();
            hashCode = hashCode * -1521134295 + Imaginary.GetHashCode();
            return hashCode;
        }
    }
}
