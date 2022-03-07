using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.Model
{
    class SparseMatrix : IMatrix
    {

        private readonly Dictionary<Tuple<int, int>, double> _matrix;
        public int Width { get; init; }
        public int Height { get; init; }

        public SparseMatrix(int height, int width)
        {
            Height = height;
            Width = width;
            _matrix = new Dictionary<Tuple<int, int>, double>();
        }

        public SparseMatrix(double[,] matrix)
        {
            Height = matrix.GetUpperBound(0) + 1;
            Width = matrix.GetUpperBound(1) + 1;
            _matrix = new Dictionary<Tuple<int, int>, double>();
            for(int i = 0;i<Height;++i)
                for(int j=0;j<Width;++j)
                {
                    if (matrix[i, j] != 0)
                        _matrix.Add(new Tuple<int, int>(i, j), matrix[i, j]);
                }
        }

        public double GetAbsMax()
        {
            var max = Double.NegativeInfinity;
            foreach (var num in _matrix)
            {
                if (Math.Abs(num.Value) > max)
                    max = Math.Abs(num.Value);
            }
            return max;
        }

        public double GetValue(int height, int width)
        {
            if (height >= Height)
                throw new ArgumentOutOfRangeException(nameof(height), $"Height must be not bigger than {Height}");
            if (width >= Width)
                throw new ArgumentOutOfRangeException(nameof(width), $"Width must be not bigger than {Width}");
            return _matrix.ContainsKey(new Tuple<int, int>(height, width)) ? _matrix[new Tuple<int, int>(height, width)] : 0;
        }

        public void SetValue(int height, int width, double value)
        {
            if (height >= Height)
                throw new ArgumentOutOfRangeException(nameof(height), $"Height must be not bigger than {Height}");
            if (width >= Width)
                throw new ArgumentOutOfRangeException(nameof(width), $"Width must be not bigger than {Width}");
            if (value == 0 && _matrix.ContainsKey(new Tuple<int, int>(height, width)))
                _matrix.Remove(new Tuple<int, int>(height, width));
            _matrix[new Tuple<int, int>(height, width)] = value;
        }

        public override bool Equals(object obj)
        {

            if (this == obj)
            {
                return true;
            }
            if (obj is not SparseMatrix)
            {
                return false;
            }
            var tmp = (SparseMatrix)obj;
            if (tmp.Height != Height || tmp.Width != Width)
            {
                return false;
            }
            foreach(var ((i,j), value) in _matrix)
            {
                if (tmp.GetValue(i, j) != value)
                    return false;
            }
            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (_matrix.ContainsKey(new Tuple<int, int>(i, j)))
                        sb.Append($"{_matrix[new Tuple<int, int>(i, j)]} ");
                    else
                        sb.Append("0 ");
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            int tmp = 1;
            double hash = Height + Width;
            foreach (var ((i, j), value) in _matrix)
            {
                hash += tmp * i + tmp * j + value;
                ++tmp;
            }
            return (int)Math.Round(hash);
        }
    }
}
