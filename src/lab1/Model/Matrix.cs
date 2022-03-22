using System.Xml;

namespace lab1.Model
{
    public interface IMatrix
    {
        public double GetValue(int i, int j);
        public void SetValue(int i, int j, double value);
        public double GetAbsMax();
        public void GetXml(XmlTextWriter writer);
    }
}