using System.Xml;

namespace lab1.Model
{
    public interface IMatrix
    {
        public int Width { get; init; }
        public int Height { get; init; }
        public double GetValue(int i, int j);
        public void SetValue(int i, int j, double value);
        public double GetMaxNorm();
        public void GetXml(XmlTextWriter writer);
    }
}