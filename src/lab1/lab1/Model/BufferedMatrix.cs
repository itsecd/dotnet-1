﻿using System;
using System.Collections.Generic;
using System.Text;

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
            var tmp = Math.Abs(_matrix[0, 0]);
            foreach(var num in _matrix)
            {
                if (Math.Abs(num) > tmp)
                    tmp = Math.Abs(num);
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

        public override bool Equals(object obj)
        {

            if (this == obj)
            {
                return true;
            }
            if (obj is not BufferedMatrix)
            {
                return false;
            }
            var tmp = (BufferedMatrix)obj;
            if (tmp.Height!=Height || tmp.Width!=Width)
            {
                return false;
            }
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                    if (_matrix[i,j] != tmp.GetValue(i, j))
                        return false;
            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    sb.Append($"{_matrix[i, j]} ");
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}