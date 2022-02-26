using System;
namespace Lab1.Model
{
    public interface IMatrix
    {
        public int GetMatrixSize();
        public double GetValueByIndex(int i, int j);
        public void SetValueByIndex(int i, int j, double value);
        public void PrintMatrix();
        public string ToString();
        public int GetHashCode();
        public double GetMaxElm();
        public double GetMaxElmLinq();
    }
}