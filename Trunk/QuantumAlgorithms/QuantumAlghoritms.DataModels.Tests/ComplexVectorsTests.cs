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
    public class ComplexVectorsTests
    {
        [TestMethod]
        public void ComparingVectors()
        {
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                var c1 = new Complex(random.Next(-200,200),random.Next(-200,200));
                var c2 = new Complex(random.Next(-200,200),random.Next(-200,200));

                var v1 = new Vector(new List<Complex>(){c1,c2});
                var v2 = new Vector(new List<Complex>(){c1,c2});

                Assert.IsTrue(v1==v2);
            }
        }

        [TestMethod]
        public void SumTwoVectors()
        {
            var c1 = new Complex(3, 4);
            var c2 = new Complex(-7, 2);
            var c3 = new Complex(-11, -3);
            var c4 = new Complex(20, -6);

            var v1 = new Vector(new List<Complex>(){c1,c2});
            var v2 = new Vector(new List<Complex>(){c3,c4});

           
            var toCompare = new Vector(new List<Complex>() {c1 + c3, c2 + c4});

            var sum = v1 + v2;

            Assert.IsTrue(toCompare == sum);
        }

        [TestMethod]
        public void SubtractTwoVectors()
        {
            var c1 = new Complex(3, 4);
            var c2 = new Complex(-7, 2);
            var c3 = new Complex(-11, -3);
            var c4 = new Complex(20, -6);

            var v1 = new Vector(new List<Complex>() { c1, c2 });
            var v2 = new Vector(new List<Complex>() { c3, c4 });

            var toCompare = new Vector(new List<Complex>() { c1 - c3, c2 - c4 });

            var diff = v1 - v2;

            Assert.IsTrue(toCompare == diff);
        }
    }
}
