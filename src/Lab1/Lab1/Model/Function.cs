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
        public string Name{ get; init; }

        public double A { get; init; }

        public double Coef { get; init; }

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
