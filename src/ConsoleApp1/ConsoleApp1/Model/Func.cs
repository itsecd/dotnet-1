using System.Xml.Serialization;

namespace ConsoleApp1.Model
{

[XmlInclude(typeof(Constanta))]
[XmlInclude(typeof(LinearFunc))]
[XmlInclude(typeof(QuadrFunc))]
[XmlInclude(typeof(Sin))]
[XmlInclude(typeof(Cos))]

public abstract class Func
 {
       public abstract double Compute(double arg);

       public abstract Func GetDerivative();

       public abstract override string ToString();

       public abstract override bool Equals(object obj);
       public abstract override int GetHashCode();
 }
}
