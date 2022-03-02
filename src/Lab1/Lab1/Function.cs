using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Functions
{
    [XmlInclude(typeof(ConstFunc)), XmlInclude(typeof(PowerFunc)), XmlInclude(typeof(ExpoFunc)), XmlInclude(typeof(LogFunc))]
    public abstract class Function
    {
        public string Name{ get; set; }

        public double A { get; set; }

        public double Coef { get; set; }

        public abstract double getValue(double x);

        public abstract Function getDerivative();

        public override bool Equals(object? obj)
        {
            // если параметр метода представляет тип Person
            // то возвращаем true, если имена совпадают
            if (obj is Function func)
            {
                if (Name == func.Name)
                {
                    if (A == func.A && Coef == func.Coef)
                        return true;
                }
            }
            return false;
        }
    }
}
