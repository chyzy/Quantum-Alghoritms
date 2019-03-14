using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantumAlgorithms.DataModels;

namespace QuantumAlghoritms.DataModels.Tests
{
    [TestClass]
    public class CompexNumbersTests
    {        
        [TestMethod]
        public void CreatingComplexNumberByValue()
        {
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                var re = random.Next(-200, 200);
                var im = random.Next(-200, 200);

                var complex = new Complex(re, im);

                Assert.IsTrue(Math.Abs(complex.Real - re) < Constants.PrecisionTolerance && Math.Abs(complex.Imaginary - im) < Constants.PrecisionTolerance);
            }
        }

        [TestMethod]
        public void CreatingComplexNumberByAngleAndModule()
        {
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                var module = random.Next(1, 32);
                var angle = 2 * Math.PI / random.Next(0, 360);

                var complex = new Complex(module, angle, true);

                Assert.IsTrue(Math.Abs(complex.Module - module) < Constants.PrecisionTolerance &&
                              Math.Abs(complex.Alpha - angle) < Constants.PrecisionTolerance);
            }
        }

        [TestMethod]
        public void ComparingComplexNumberCreatedBasedOnOthersModuleAndAngle()
        {
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                var re = random.Next(-200, 200);
                var im = random.Next(-200, 200);

                var a = new Complex(re, im);
                var b = new Complex(a.Module, a.Alpha, true);

                Assert.IsTrue(a == b);
            }
        }

        [TestMethod]
        public void ComparingTwoComplexNumbersByEqual()
        {
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                var re = random.Next(-200, 200);
                var im = random.Next(-200, 200);

                var a = new Complex(re, im);
                var b = new Complex(re, im);

                Assert.IsTrue(a.Equals(b));
                Assert.IsTrue(b.Equals(a));
                Assert.IsTrue(a.Equals(a));
            }
        }

        [TestMethod]
        public void SumOfTwoComplexNumberCreatedByValues()
        {

            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                var re1 = random.Next(-200, 200);
                var im1 = random.Next(-200, 200);

                var re2 = random.Next(-200, 200);
                var im2 = random.Next(-200, 200);

                var a = new Complex(re1, im1);
                var b = new Complex(re2, im2);

                var sum = a + b;

                Assert.IsTrue(Math.Abs(re1 + re2 - sum.Real) <= Constants.PrecisionTolerance &&
                              Math.Abs(im1 + im2 - sum.Imaginary) <= Constants.PrecisionTolerance);
            }
        }

        [TestMethod]
        public void SumOfTwoComplexNumberCreatedByAngleAndModule()
        {
            var a = new Complex(Math.Sqrt(2), Math.PI / 4d, true);
            var b = new Complex(Math.Sqrt(2), 3 * Math.PI / 4d, true);

            var sum = a + b;

            Assert.IsTrue(sum.Real == 0 && sum.Imaginary == 2);
        }

        [TestMethod]
        public void SubtractTwoComplexNumbers()
        {
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                var re1 = random.Next(-200, 200);
                var im1 = random.Next(-200, 200);

                var re2 = random.Next(-200, 200);
                var im2 = random.Next(-200, 200);

                var a = new Complex(re1, im1);
                var b = new Complex(re2, im2);

                var diff = a - b;

                Assert.IsTrue(Math.Abs(re1 - re2 - diff.Real) <= Constants.PrecisionTolerance &&
                              Math.Abs(im1 - im2 - diff.Imaginary) <= Constants.PrecisionTolerance);
            }
        }

        [TestMethod]
        public void ComplexConjugateTest()
        {
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                var re = random.Next(-200, 200);
                var im = random.Next(-200, 200);

                var a = new Complex(re,im);              
                var b = a + a.Conjugate;

                Assert.IsTrue(Math.Abs(b.Real - re*2) < Constants.PrecisionTolerance && Math.Abs(b.Imaginary) < Constants.PrecisionTolerance);
            }
        }
    }
}
