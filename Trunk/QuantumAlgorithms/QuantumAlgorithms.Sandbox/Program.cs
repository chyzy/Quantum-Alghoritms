using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuantumAlgorithms.DataModels;
using QuantumAlgorithms.Tools;

namespace QuantumAlgorithms.Sandbox
{
    class Program
    {                
        //static void Main(string[] args)
        //{
        //    //Step 0
        //    var Step0Qubit1 = Qubit.Random();
        //    var Step0Qubit2 = Qubit.Random();
        //    var Step0Qubit3 = Qubit.Random();

        //    Console.WriteLine(Step0Qubit3);

        //    //Step 1
        //    var Step1Qubit1 = Step0Qubit1 | Gates.Hadamard;
        //    var Step1Qubit2 = Step0Qubit2;
        //    var Step1Qubit3 = Step0Qubit3;

        //    //Step 2
        //    var Step2Qubit1 = Step1Qubit1;
        //    var Step2Qubit2 = Gates.CNOT.To2DArray() * (Step1Qubit1*Step1Qubit2); //CNOT
        //    var Step2Qubit3 = Step1Qubit3;

        //    //Step 3
        //    var Step3Qubit1Result = Step2Qubit1.Measure(); //Pomiar pierwszego qubitu
        //    var Step3Qubit2Result = new Qubit(Step2Qubit2[2,0],Step2Qubit2[3,0]).Measure(); //Pomiar drugiego qubitu.
        //    var Step3Qubit3 = Step2Qubit3;

        //    //Step 4
        //    var Step4  = Step3Qubit2Result?
        //        Step3Qubit3 | Gates.PauliX:
        //        Step3Qubit3;

        //    //Step 5
        //    var result = Step3Qubit2Result?
        //        Step4 | Gates.PauliZ:
        //        Step4;

        //    Console.WriteLine(result);
        //    Console.ReadKey();
        //}

        static void Main(string[] args)
        {
            //Step 0
            var Step0Qubit1 = Qubit.Random();
            var Step0Qubit2 = new Qubit(1,0);
            var Step0Qubit3 = new Qubit(1,0);

            //Step 1
            var Step1Qubit1 = Step0Qubit1;
            var Step1Qubit2 = Step0Qubit2 | Gates.Hadamard;
            var Step1Qubit3 = Step0Qubit3;

            //Step 2
            var Step2Qubit1 = Step1Qubit1;
            var Entanglement1 = Gates.CNOT * (Step1Qubit2 * Step1Qubit3);

            //Step 3
            var Entaglement2 = Matrix.Kroncker(Step2Qubit1,Entanglement1);

            //Step 4
            var Cnot = new Matrix(new Complex[,]
            {
                {new Complex(1,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0)},
                {new Complex(0,0),new Complex(1,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0)},
                {new Complex(0,0),new Complex(0,0),new Complex(1,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0) },
                {new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(1,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0)},
                {new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(1,0),new Complex(0,0) },
                {new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(1,0) },
                {new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(1,0),new Complex(0,0),new Complex(0,0),new Complex(0,0) },
                {new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(1,0),new Complex(0,0),new Complex(0,0)}
            });

            var Entaglement3 = Cnot * Entaglement2;

            var Hadamard = new Matrix(new Complex[,]
            {
                {new Complex(1/Math.Sqrt(2),0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(1/Math.Sqrt(2),0),new Complex(0,0),new Complex(0,0),new Complex(0,0)},
                {new Complex(0,0),new Complex(1/Math.Sqrt(2),0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(1/Math.Sqrt(2),0),new Complex(0,0),new Complex(0,0)},
                {new Complex(0,0),new Complex(0,0),new Complex(1/Math.Sqrt(2),0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(1/Math.Sqrt(2),0),new Complex(0,0) },
                {new Complex(0,0),new Complex(0,0),new Complex(1/Math.Sqrt(2),0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(1/Math.Sqrt(2),0)},
                {new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0) },
                {new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(1,0) },
                {new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(1,0),new Complex(0,0),new Complex(0,0),new Complex(0,0) },
                {new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(0,0),new Complex(1,0),new Complex(0,0),new Complex(0,0)}
            });




            Console.ReadKey();
        }
    }
}
