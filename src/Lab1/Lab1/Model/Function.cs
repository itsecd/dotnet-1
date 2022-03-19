using System.Xml.Serialization;

namespace Lab1.Model
{
    [XmlInclude(typeof(ConstFunc)), XmlInclude(typeof(PowerFunc)), XmlInclude(typeof(ExpoFunc)), XmlInclude(typeof(LogFunc))]
    public abstract class Function
    {
        public string Name{ get; init; }

        public double A { get; init; }

        public double Coef { get; init; }

        public abstract double GetValue(double x);

        public abstract Function GetDerivative();

        public override bool Equals(object? obj)
        {
            // если параметр метода представляет тип Function
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
