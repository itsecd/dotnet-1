using System.Xml.Serialization;

namespace Lab1.Model
{
    [XmlInclude(typeof(ConstantFunction))]
    [XmlInclude(typeof(ExponentialFunction))]
    [XmlInclude(typeof(LogarithmFunction))]
    [XmlInclude(typeof(PowerFunction))]
    public abstract class Function
    {
        public abstract dynamic Calculate(double value);

        public abstract string Derivative();

    }
}
