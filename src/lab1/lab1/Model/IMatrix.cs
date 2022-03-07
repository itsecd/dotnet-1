using System;

namespace lab1.Model
{
    internal interface IMatrix
    {
        public int Width { get; init; }
        public int Height { get; init; }
        double GetValue(int height, int width);
        void SetValue(int height, int width, double value);
        double GetAbsMax();
    }
}