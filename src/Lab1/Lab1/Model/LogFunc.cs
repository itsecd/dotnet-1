using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions
{
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
