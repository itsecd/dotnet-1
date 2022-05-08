using System.Xml.Serialization;

namespace Model
{

    [XmlInclude(typeof(Constant))]
    [XmlInclude(typeof(ExponentialFunction))]
    [XmlInclude(typeof(Log))]
    [XmlInclude(typeof(PowerFunction))]

    public abstract class Function
    {
        public abstract double GetResult(double x);
        public abstract Function GetDerivative();
        public abstract override string ToString();
        public abstract override bool Equals(object obj);

    }
}
