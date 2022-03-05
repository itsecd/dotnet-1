using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_Indust_Pr.Model
{
    class Sin : Function
    {
        //флаг для + и - для производной косинуса 
        //-sin(x) = sin(-x) по другому не придумал как
        public bool Sign { get; set; } = true;

        public override Function GetDerivative() => new Cos();

        public override double GetValueFunc(double arg)//радианы
        {
            var x = arg * Math.PI / 180;
            if (Sign) return Math.Sin(x);
            else return Math.Sin(-x);
        }

        public override string ToString()
        {
            if (Sign) return $"Sin(x)";
            else return $"-Sin(x)";
        }
 
    }
}
