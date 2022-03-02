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

    public class ConstFunc : Function
    {
        public override double getValue(double x = 0)
        {
            return Coef;
        }

        public override Function getDerivative()
        {
            return new ConstFunc(0);
        }

        public ConstFunc() : this(0)
        { }

        public ConstFunc(double _coef)
        {
            Coef = _coef;
            Name = "ConstFunc";
        }

        public override string ToString()
        {
            return $"f(x) = {Coef}";
        }
    }

    public class PowerFunc : Function // x^a
    {
        public override double getValue(double x = 0)
        {
            if (x == 0 && A < 0)
                return 0; // надо изменить на что-нибудь более говорящее

            return Coef * Math.Pow(x, A); // 0 нельзя возводить в отрицательные степени!
        }

        public override Function getDerivative()
        {
            return new PowerFunc(A - 1, A * Coef);
        }

        public PowerFunc() : this(0)
        { }

        public PowerFunc(double value, double _coef = 1)
        {
            A = value;
            Coef = _coef;
            Name = "PowerFunc";
        }

        public override string ToString()
        {
            return $"f(x) = x^({A})";
        }
    }

    public class ExpoFunc : Function // a^x, не готово
    {
        public override double getValue(double x = 0)
        {
            if (A == 0 && x < 0)
                return 0; // надо изменить на что-нибудь более говорящее

            return Coef * Math.Pow(A, x); // 0 нельзя возводить в отрицательные степени!
        }

        public override Function getDerivative()
        {
            return new ExpoFunc(A, Math.Log(A, Math.E));
        }

        public ExpoFunc() : this(1)
        { }

        public ExpoFunc(double value, double _coef = 1)
        {
            A = value;
            Coef = _coef;
            Name = "ExpoFunc";
        }

        public override string ToString()
        {
            return $"f(x) = ({A})^x";
        }
    }

    public class LogFunc : Function // не готово
    {
        public override double getValue(double x = 2)
        {
            if (A > 0 && A != 1 && x > 0) // ?? мб поменять условие
                return Coef * Math.Log(x, A);
            else return 0; // надо изменить на что-нибудь более говорящее
        }

        public override Function getDerivative()
        {
            return new LogFunc(A - 1, A * Coef);
        }

        public LogFunc() : this(1)
        { }

        public LogFunc(double value, double _coef = 1)
        {
            A = value; // должно быть больше нуля
            Coef = _coef;
            Name = "LogFunc";
        }

        public override string ToString()
        {
            return $"f(x) = log({A})_X";
        }
    }



    public class DerLog : Function // производная от логарифма, вспомогательная, недоделанная
    {
        public override double getValue(double x = 0)
        {
            return Coef / (Math.Log(A, Math.E) * x); // x должен быть больше нуля
        }

        public override Function getDerivative()
        {
            return null;
        }

        public DerLog() : this(1)
        { }

        public DerLog(double value, double _coef = 1)
        {
            A = value; // должно быть больше нуля
            Coef = _coef;
            Name = "DerLog";
        }
    }
}
