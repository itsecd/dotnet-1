using System.Xml;

namespace iProg1.Model
{
    public abstract class Matrix
    {
        public abstract int GetDimension();
        
        public abstract double GetValue(int indexR, int indexC);
        
        public abstract void SetValue(int indexR, int indexC,  double value);
        
        public abstract double GetAbsMaxElementWithLinq();
        
        public abstract double GetAbsMaxElement();
        
        public abstract void GetXml(XmlTextWriter writer);
        
        public abstract void LoadFromXml(XmlTextReader read);
    }
}
