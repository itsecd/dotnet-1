using System;

namespace Lab1.Model
{
    public class LogFunc : Function 
    {
        public override double GetValue(double x = 2)
        {
            if (A > 0 && A != 1 && x > 0) 
                return Coef * Math.Log(x, A);
            else return 0; 
        }

        public override Function GetDerivative()
        {
            return new LogFunc(A - 1, A * Coef);
        }

        public LogFunc() : this(1)
        { }

        public LogFunc(double value, double coefficient = 1)
        {
            A = value; 
            Coef = coefficient;
            Name = "LogFunc";
        }

        public override string ToString()
        {
            return $"f(x) = log({A})_X";
        }
    }
}
