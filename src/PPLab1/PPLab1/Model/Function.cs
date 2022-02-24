using System.Xml.Serialization;

namespace PPLab1.Model
{
    [XmlInclude(typeof(Const))]
    [XmlInclude(typeof(ExpFunct))]
    [XmlInclude(typeof(LogFunct))]
    [XmlInclude(typeof(PowerFunct))]
    
    public abstract class Function
    { 
        public abstract double? calc_funct(double value);
        public abstract string derivative();
    }
}
