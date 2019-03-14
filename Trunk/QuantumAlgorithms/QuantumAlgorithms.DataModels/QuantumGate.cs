using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumAlgorithms.DataModels
{
    public class QuantumGate
    {       
        public QuantumGate(Matrix matrix)
        {
            this.Matrix = matrix;
        }

        public Matrix Matrix { get; protected set; }
    }
}
