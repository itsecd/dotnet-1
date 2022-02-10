using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iProg1.Model
{
    public class BufferedMatrix : IMatrix
    {
        private double[,] _matrix;
        public BufferedMatrix(int a, int b)
        {
            _matrix = new double[a, b];
        }
        public BufferedMatrix(double[,] matrix)
        {
            _matrix = (double[,])matrix.Clone();
        }
        public int[] GetDimension()
        {
            return new int[2] { _matrix.GetLength(0), _matrix.GetLength(1) };
        }
        public int GetColumnCount()
        {
            return _matrix.GetLength(0);
        }
        public int GetRowCount()
        {
            return _matrix.GetLength(1);
        }
        public double GetValue(int indexC, int indexR)
        {
            if (!Valid.IsValidIndex(indexC, GetColumnCount()) ||
                !Valid.IsValidIndex(indexR, GetRowCount()))
            {
                throw new ArgumentOutOfRangeException("incorrect index");
            }
            return _matrix[indexC, indexR];
        }
        public void SetValue(int indexC, int indexR, int value)
        {
            if (!Valid.IsValidIndex(indexC, GetColumnCount()) ||
                !Valid.IsValidIndex(indexR, GetRowCount()))
            {
                throw new ArgumentOutOfRangeException("incorrect index");
            }
            _matrix[indexC,indexR] = value;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("BufferedMatrix: \n");
            for(int i = 0; i < _matrix.GetLength(0); i++)
            {
                for(int j = 0; j < _matrix.GetLength(1); j++)
                {
                    sb.Append(_matrix[i,j]);
                }
                sb.Append('\n');
            }
            return sb.ToString();
        }
        public override bool Equals(object obj)
        {
            if(this == obj)
            {
                return true;
            }
            if(obj == null || this.GetType() != obj.GetType()) 
            {
                return false; 
            }
            var matrix = (BufferedMatrix)obj;
            if(matrix.GetColumnCount() != GetColumnCount()) 
            { 
                return false; 
            }
            if(matrix.GetRowCount() != GetRowCount()) 
            {
                return false; 
            }
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    if (_matrix[i, j] != matrix._matrix[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
