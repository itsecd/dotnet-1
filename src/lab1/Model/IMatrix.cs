using System.Xml;

namespace Lab1.Model
{
    public interface IMatrix
    {
        public int Width { get; init; }
        public int Height { get; init; }
        public double this[int i, int j] { get; set;}
        public double GetMaxNorm();
        public void GetXml(XmlTextWriter writer);
    }
}