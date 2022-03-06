using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Model
{
    public class BufferedMatrix : Matrix
    {
        private int n{ get; }
        private int m{ get; }
        private double[][] _matrix;
        public BufferedMatrix() { }

        public BufferedMatrix(int n, int m)
        {
            this.n = n;
            this.m = m;
            _matrix = new double[n][];

            for (int i = 0; i < n; i++)
            {
                _matrix[i] = new double[m];
            }

            Random rand = new Random();
            for(int i=0; i<n; i++)
            {
                for(int j=0; j<m; j++)
                    _matrix[i][j] = rand.Next(0, +20);     
            }
        }

        public override int GetMatrixSize()
        {
            return n * m;
        }

        public override double GetValueByIndex(int i, int j)
        {
            if(m>0 && n>0)
                return _matrix[i][j];
            else
                return 0;
        }

        public override void SetValueByIndex(int i, int j, double value)
        {
            if(i<0 || i>=m)
                return;
            if(j<0 || j>=n)
                return;
            _matrix[i][j] = value;
        }

        public override void PrintMatrix()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(_matrix[i][j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for(int i=0; i<n; i++)
            {
                for(int j=0; j<m; j++)
                {
                    sb.Append(_matrix[i][j]);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }

            var matrix = (Matrix)obj;
            if (matrix.GetMatrixSize() != GetMatrixSize())
            {
                return false;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (_matrix[i][j] != matrix.GetValueByIndex(i, j))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            double hashCode = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    hashCode = hashCode * _matrix.GetLength(0);
                }
            }
            
            return Math.Abs((int)hashCode);
        }
        public override double GetMaxElm()
        {
            double maxElm = 0;
            for (int i = 0; i < _matrix.Length; i++)
            {
                for (int j = 0; j < _matrix[i].Length; j++)
                {
                    if(Math.Abs(_matrix[i][j]) > maxElm)
                        maxElm = Math.Abs(_matrix[i][j]);
                }
            }
            return maxElm;
        }
        public override double GetMaxElmLinq()
        {
            return _matrix.Max(p => p.Max(Math.Abs));
        }
    }
}
