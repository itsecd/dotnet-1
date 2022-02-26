using System.Xml;

namespace iProg1.Model
{
    public interface IMatrix
    {
        int GetDimension();
        
        double GetValue(int indexR, int indexC);
        
        void SetValue(int indexR, int indexC,  double value);
        
        double GetAbsMaxElementWithLinq();
        
        double GetAbsMaxElement();
        
        void GetXml(XmlTextWriter writer);
        
        void LoadFromXml(XmlTextReader read);
    }
}
