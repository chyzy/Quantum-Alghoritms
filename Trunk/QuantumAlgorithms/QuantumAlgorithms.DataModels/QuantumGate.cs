using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumAlgorithms.DataModels
{
    public class QuantumGate : Matrix
    {       
        public QuantumGate(Matrix matrix) : base(matrix.To2DArray())
        {
           
        }
    }
}
