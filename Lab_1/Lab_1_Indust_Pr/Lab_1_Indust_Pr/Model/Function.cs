using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1_Indust_Pr.Model
{
    abstract class Function
    {
        public abstract double GetValueFunc(double arg);

        public abstract Function GetDerivative();
    }
}
