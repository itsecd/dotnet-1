using System;

namespace lab1.Model
{
    internal interface IMatrix
    {
        double GetValue(int height, int width);
        void SetValue(int height, int width, double value);
        double GetAbsMax();
    }
}