using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Model
{
    public class BufferedMatrix : IMatrix
    {
        private int n{ get; }
        private int m{ get; }
        private double[][] matrix;

        public BufferedMatrix(int n, int m)
        {
            this.n = n;
            this.m = m;
            matrix = new double[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new double[m];
            }

            Random rand = new Random();
            for(int i=0; i<n; i++)
            {
                for(int j=0; j<m; j++)
                    matrix[i][j] = rand.Next(0, +20);     
            }
        }

        public int GetMatrixSize()
        {
            return n * m;
        }

        public double GetValueByIndex(int i, int j)
        {
            if(m>0 && n>0)
                return matrix[i][j];
            else
                return 0;
        }

        public void SetValueByIndex(int i, int j, double value)
        {
            if(i<0 || i>=m)
                return;
            if(j<0 || j>=n)
                return;
            matrix[i][j] = value;
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(matrix[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public string ToString()
        {
            var sb = new StringBuilder();
            for(int i=0; i<n; i++)
            {
                for(int j=0; j<m; j++)
                {
                    sb.Append(matrix[i][j]);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
        public bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }

            var _matrix = (IMatrix)obj;
            if (_matrix.GetMatrixSize() != GetMatrixSize())
            {
                return false;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i][j] != _matrix.GetValueByIndex(i, j))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public int GetHashCode()
        {
            double hashCode = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    hashCode = hashCode * matrix.GetLength(0);
                }
            }
            
            return Math.Abs((int)hashCode);
        }
        public double GetMaxElm()
        {
            double maxElm = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if(Math.Abs(matrix[i][j]) > maxElm)
                        maxElm = Math.Abs(matrix[i][j]);
                }
            }
            return maxElm;
        }
        public double GetMaxElmLinq()
        {
            return matrix.Max(p => p.Max(Math.Abs));
        }
    }
}
