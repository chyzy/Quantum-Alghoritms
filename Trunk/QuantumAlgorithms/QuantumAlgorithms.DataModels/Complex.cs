using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumAlgorithms.DataModels
{
    public class Complex
    {
        private double _real;
        private double _imaginary;

        public Complex(double real, double imaginary)
        {
            this._real = real;
            this._imaginary = imaginary;
        }

        public Complex(double module, double alpha, bool isTrigonometric)
        {
            _real = module * Math.Cos(alpha);
            _imaginary = module * Math.Sin(alpha);
        }

        public double Real
        {
            get { return _real; }
            set { _real = value; }
        }
        public double Imaginary
        {
            get { return _imaginary; }
            set { _imaginary = value; }
        }

        public double Alpha
        {
            get
            {
                return Math.Asin(_imaginary / Module);
            }
        }

        public double Module
        {
            get { return Math.Sqrt(Math.Pow(_real, 2) + Math.Pow(_imaginary, 2)); }
        }

        public Complex Coupling
        {
            get
            {
                return new Complex(_real, -_imaginary);
            }
        }

        public Complex Power(double power)
        {
            var module = Math.Pow(this.Module, power);
            var alpha = this.Alpha * power;
            return new Complex(module, alpha, true);
        }

        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
        }

        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
        }

        public static Complex operator *(Complex a, Complex b)
        {
            var real = a.Real * b.Real - a.Imaginary * b.Imaginary;
            var imaginary = a.Real * b.Imaginary + a.Imaginary * b.Real;
            return new Complex(real, imaginary);
        }

        public static Complex operator /(Complex a, Complex b)
        {
            var real = (a.Real * b.Real + a.Imaginary * b.Imaginary) / (b.Real * b.Real + b.Imaginary * b.Imaginary);
            var imaginary = (a.Imaginary * b.Real - a.Real * b.Imaginary) / (b.Real * b.Real + b.Imaginary * b.Imaginary);
            return new Complex(real, imaginary);
        }

        public static Complex operator ^(Complex a, double power)
        {
            return a.Power(power);
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
            return this.Alpha >=0?
                $"{this.Module}*(cos {this.Alpha} + isin {this.Alpha})":
                $"{this.Module}*(cos {this.Alpha} - isin {Math.Abs(this.Alpha)})";

        }
    }
}
