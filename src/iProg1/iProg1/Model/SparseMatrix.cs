using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iProg1.Model
{
    public class SparseMatrix : IMatrix
    {
        private readonly int ColumnCount;
        private readonly int RowCount;
        private readonly Dictionary<Tuple<int, int>, double> _matrix;
        public SparseMatrix(int cCount, int rCount)
        {
            _matrix = new Dictionary<Tuple<int, int>, double>();
            ColumnCount = cCount;
            RowCount = rCount;
        }
        public SparseMatrix(Dictionary<Tuple<int, int>, double> matrix, int cCount, int rCount)
        {
            _matrix = new Dictionary<Tuple<int, int>, double>();
            foreach(var pair in matrix)
            {
                _matrix.Add(pair.Key, pair.Value);
            }
            ColumnCount = cCount;
            RowCount = rCount;
        }
        public int[] GetDimension()
        {
            return new int[2] { RowCount, ColumnCount };
        }
        public int GetColumnCount()
        {
            return ColumnCount;
        }
        public int GetRowCount()
        {
            return RowCount;
        }
        public double GetValue(int indexC, int indexR)
        {
            if (!Valid.IsValidIndex(indexC, GetColumnCount()) ||
                !Valid.IsValidIndex(indexR, GetRowCount()))
            {
                throw new ArgumentOutOfRangeException("incorrect index");
            }
            return _matrix.ContainsKey(new Tuple<int, int>(indexC, indexR))
                ? _matrix[new Tuple<int, int>(indexC, indexR)]
                : 0;
        }
        public void SetValue(int indexC, int indexR, int value)
        {
            if (!Valid.IsValidIndex(indexC, GetColumnCount()) ||
                 !Valid.IsValidIndex(indexR, GetRowCount()))
            {
                throw new ArgumentOutOfRangeException("incorrect index");
            }
            if (value == 0)
            {
                _matrix.Remove(new Tuple<int, int>(indexC, indexR));
            }
            else
            {
                _matrix[new Tuple<int, int>(indexC, indexR)] = value;
            }
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("SparseMatrix: \n");
            for (int i = 0; i < ColumnCount; i++)
            {
                for (int j = 0; j < RowCount; j++)
                {
                    var tuple = new Tuple<int, int>(i, j);
                    if(_matrix.ContainsKey(tuple))
                    {
                        sb.Append(_matrix[tuple]);
                    }
                    else
                    {
                        sb.Append('0');
                    }
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }
            if (obj == null || this.GetType() != obj.GetType())
            {
                return false;
            }
            var matrix = (SparseMatrix)obj;
            if (matrix.GetColumnCount() != ColumnCount)
            {
                return false;
            }
            if (matrix.GetRowCount() != RowCount)
            {
                return false;
            }
            for (int i = 0; i < ColumnCount; i++)
            {
                for (int j = 0; j < RowCount; j++)
                {
                    var tuple = new Tuple<int, int>(i, j);
                    bool isExist = _matrix.ContainsKey(tuple);
                    if (isExist == matrix._matrix.ContainsKey(tuple) && isExist)
                    {
                        if (_matrix[tuple] != matrix._matrix[tuple])
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
