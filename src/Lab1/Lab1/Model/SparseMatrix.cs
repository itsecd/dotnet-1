using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Model
{
    public class SparseMatrix : Matrix
    {
        private int n { get; }
        private int m { get; }

        private Dictionary<Tuple<int, int>, double> _matrix;
        public SparseMatrix() { }

        //public SparseMatrix(double[][] matrix)
        //{
        //    _matrix = new Dictionary<Tuple<int, int>, double>();
        //    if (matrix == null)
        //        return;

        //    n = matrix.Length;
        //    m = matrix[0].Length;
        //    for (int i = 0; i < n; i++)
        //    {
        //        for (int j = 0; j < m; j++)
        //        {
        //            if (matrix[i][j] != 0)
        //                _matrix.Add(new Tuple<int, int>(i, j), matrix[i][j]);
        //        }
        //    }
        //}

        public SparseMatrix(int n, int m)
        {
            _matrix = new Dictionary<Tuple<int, int>, double>();
            var matrix = new int[n][];

            for (int i = 0; i < n; i++)
            {
                matrix[i] = new int[m];
            }

            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    matrix[i][j] = rand.Next(0, +20);
            }

            this.n = matrix.Length;
            this.m = matrix[0].Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i][j] != 0)
                        _matrix.Add(new Tuple<int, int>(i, j), matrix[i][j]);
                }
            }
        }

        public override int GetMatrixSize()
        {
            return n * m;
        }

        public override void PrintMatrix()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    var ind = Tuple.Create(i, j);
                    if (_matrix.ContainsKey(ind))
                        Console.Write(_matrix[ind] + "\t");
                    else
                        Console.Write("0 \t");

                }
                Console.WriteLine();
            }
        }

        public override double GetValueByIndex(int i, int j)
        {
            if (_matrix.ContainsKey(new Tuple<int, int>(i, j)))
                return _matrix[new Tuple<int, int>(i, j)];
            else
                return 0;
        }

        public override void SetValueByIndex(int i, int j, double value)
        {
            if (i < 0 || i >= m)
                return;
            if (j < 0 || j >= n)
                return;
            if (value == 0)
                _matrix.Remove(new Tuple<int, int>(i, j));
            else
                _matrix [new Tuple<int, int>(i, j)] = value;
        }

        public override string ToString()
        {
            string str = "";
            foreach(Tuple<int, int> key in _matrix.Keys)
            {
                str += key + "=" + _matrix[key];
            }
            return str;
            //var sb = new StringBuilder();
            //for (int i = 0; i < n; i++)
            //{
            //    for (int j = 0; j < m; j++)
            //    {
            //        var tuple = new Tuple<int, int>(i, j);
            //        if (_matrix.ContainsKey(tuple))
            //        {
            //            sb.Append($"{_matrix[tuple],10}");
            //        }
            //        else
            //            sb.Append($"{0,10}");
            //        sb.Append(' ');
            //    }
            //    sb.AppendLine();
            //}
            //return sb.ToString();
        }

        public override int GetHashCode()
        {
            double hashCode = 0;
            foreach (var ((i, j), elem) in _matrix)
            {
                hashCode = hashCode * elem.GetHashCode();
            }
            return Math.Abs((int)hashCode);
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
                    if (GetValueByIndex(i,j) != matrix.GetValueByIndex(i, j))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public override double GetMaxElm()
        {
            double maxElm = 0;
            foreach (var elem in _matrix.Values)
            {
                if(maxElm < Math.Abs(elem))
                    maxElm = elem;
            }
            return maxElm;
        }
        public override double GetMaxElmLinq()
        {
            return _matrix.Values.Max();
        }

    }
}
