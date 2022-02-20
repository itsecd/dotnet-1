using System.Xml;

namespace iProg1.Model
{
    public abstract class Matrix
    {
        public abstract int GetColumnCount();
        public abstract int GetRowCount();
        public abstract double GetValue(int indexC, int indexR);
        public abstract void SetValue(int indexC, int indexR,  int value);
        public abstract void GetXml(XmlTextWriter writer);
        public abstract void LoadFromXml(XmlTextReader read);
    }
}
