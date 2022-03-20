using System;

namespace Lab1.Model
{
    public class DerLog : Function // производная от логарифма, вспомогательная, недоделанная
    {
        public override double GetValue(double x = 0)
        {
            return Coef / (Math.Log(A, Math.E) * x); // x должен быть больше нуля
        }

        public override Function GetDerivative()
        {
            return null;
        }

        public DerLog() : this(1)
        { }

        public DerLog(double value, double coefficient = 1)
        {
            A = value; // должно быть больше нуля
            Coef = coefficient;
            Name = "DerLog";
        }
    }
}
