using System;
using System.Collections.Generic;

namespace lab1.Model
{
    public class BufferedMatrix : IMatrix
    {
        private double[,] _matrix;

        public int Width { get; init; }

        public int Height { get; init; }

        public BufferedMatrix(int height, int width)
        {
            Height = height;
            Width = width;
            _matrix = new double[height,width];
        }

        public double GetAbsMax()
        {
            var tmp = _matrix[0, 0];
            foreach(var num in _matrix)
            {
                if (num > tmp)
                    tmp = num;
            }
            return tmp;

        }

        public double GetValue(int height, int width)
        {
            if (height >= Height)
                throw new ArgumentOutOfRangeException(nameof(height), $"Height must be not bigger than {Height}");
            if (width >= Width)
                throw new ArgumentOutOfRangeException(nameof(width), $"Width must be not bigger than {Width}");
            return _matrix[height, width];
        }

        public void SetValue(int height, int width, double value)
        {
            if (height >= Height)
                throw new ArgumentOutOfRangeException(nameof(height), $"Height must be not bigger than {Height}");
            if (width >= Width)
                throw new ArgumentOutOfRangeException(nameof(width), $"Width must be not bigger than {Width}");
            _matrix[Height, width] = value;
        }
    }
}