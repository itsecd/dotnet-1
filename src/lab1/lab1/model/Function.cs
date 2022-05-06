using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace model
{

    [XmlInclude(typeof(Constant))]
    [XmlInclude(typeof(ExponentialFunction))]
    [XmlInclude(typeof(Log))]
    [XmlInclude(typeof(PowerFunction))]

    public abstract class Function
    {

        public abstract double getResult(double x);

        public abstract Function getDerivative();

        public abstract override string ToString();

        public abstract override bool Equals(object obj);



        

    }
}
