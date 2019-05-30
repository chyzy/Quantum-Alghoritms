using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumAlgorithms.DataModels
{

    public class Matrix
    {          
        public Matrix(Complex[,] matrix)
        {
            this._data = matrix;
        }

        public Matrix(Matrix matrix) : this(matrix.To2DArray())
        {
            
        }

        protected Matrix(params Complex[] complexSet)
        {
            this._data = new Complex[complexSet.Length,1];

            for (int i = 0; i < complexSet.Length; i++)
            {
                _data[i, 0] = complexSet[i];
            }
        }
        
        protected Complex[,] _data;

        public int N => _data.GetUpperBound(0) + 1;
        public int M => _data.GetUpperBound(1) + 1;

        public static implicit operator Matrix(Complex[,] matrix)
        {
            return new Matrix(matrix);
        }

        public static implicit operator Matrix(double[,] realMatrix)
        {
            var nSize = realMatrix.GetLength(0);
            var mSize = realMatrix.GetLength(1);
            var matrix = new Complex[nSize,mSize];

            for (int n = 0; n < nSize; n++)
            {
                for (int m = 0; m < mSize; m++)
                {
                    matrix[n, m] = realMatrix[n, m];
                }
            }
            return new Matrix(matrix);
        }

        public Complex this [int row, int column]
        {
            get
            {
                return _data[row,column]; 
            }
            set
            {
                _data[row,column] = value;
            }
        }

        public static Matrix operator * (Matrix a, Matrix b)
        {
            if (a.M != b.N)
            {
                return null;
            }

            var matrix = new Complex[a.N,b.M];
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.M; j++)
                {
                    Complex s = 0;
                    for (int m = 0; m < a.M; m++)
                    {
                        s += a[i, m] * b[m, j];
                    }
                    matrix[i, j] = s;
                }
            }
            return new Matrix(matrix);
        }

        public static Matrix operator * (Complex scalar, Matrix matrix)
        {
            var result = new Matrix(matrix.To2DArray());
            for (int n = 0; n < matrix.N; n++)
            {
                for (int m = 0; m < matrix.M; m++)
                {
                    result[n, m] = scalar * matrix[n, m];
                }
            }

            return result;
        }

        public static Matrix operator + (Matrix a, Matrix b)
        {
            if (a.M != b.M || a.N != b.N)
            {
                return null;
            }
            var matrix = new Complex[a.N,b.M];          
            for (int i = 0; i < a.N; i++)
            {
                for (int j = 0; j < b.M; j++)
                {
                    matrix[i, j] = a[i, j] + b[i, j];
                }
            }
            return new Matrix(matrix);
        }

        public static Matrix operator - (Matrix matix)
        {
            var nSize = matix.N - 1;
            var mSize = matix.M - 1;

            var matrix = new Complex[nSize,mSize];

            for (int n = 0; n < nSize; n++)
            {
                for (int m = 0; m < mSize; m++)
                {
                    matix[n, m] = -matix[m, n];
                }
            }
            return new Matrix(matrix);
        }

        public static Matrix operator - (Matrix a, Matrix b)
        {
            return (-1 * b) + a;
        }

        public static bool operator == (Matrix a, Matrix b)
        {
            if (a.N != b.N || a.M != b.M)
                return false;
            
            for (int n = 0; n < a.N; n++)
            {
                for (int m = 0; m < a.M; m++)
                {
                    if (a[n, m] != b[n, m])
                        return false;
                }
            }
            return true;
        }

        public static bool operator !=(Matrix a, Matrix b)
        {
            return !(a == b);
        }

        public virtual Complex[,] To2DArray()
        {
            var result = new Complex[N,M];
            for (int n = 0; n < N; n++)
            {
                for (int m = 0; m < M; m++)
                {
                    result[n, m] = this[n, m];
                }
            }

            return result;
        }

        public static Matrix Kroncker (Matrix m1, Matrix m2)
        {
            var result = new Complex[m1.N*m2.N,1];

            var counter = 0;

            for (int i = 0; i < m1.N; i++)
            {
                for (int j = 0; j < m2.N; j++)
                {
                    result[counter, 0] = m1[i, 0] * m2[j, 0];
                    counter++;
                }
            }
            return new Matrix(result);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    sb.Append($"{_data[i, j]:0.000}\t");
                }
                sb.Append("\n");
            }
            return sb.ToString();
        }

    }
}
