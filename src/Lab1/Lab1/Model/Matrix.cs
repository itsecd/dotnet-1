using System;
using System.Xml.Serialization;

namespace Lab1.Model
{
    [XmlInclude(typeof(BufferedMatrix))]
    [XmlInclude(typeof(SparseMatrix))]
    public abstract class Matrix
    {
        public abstract int GetMatrixSize();
        public abstract double GetValueByIndex(int i, int j);
        public abstract void SetValueByIndex(int i, int j, double value);
        public abstract void PrintMatrix();
        public abstract string ToString();
        public abstract int GetHashCode();
        public abstract double GetMaxElm();
        public abstract double GetMaxElmLinq();
    }
}