using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromProg1.Models
{
    public class Summation : Operation
    {
        public override double GetResult(double operand1, double operand2)
        {
            return operand1 + operand2;
        }
        public override string ToString()
        {
            return "Сложение";
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType().Name == GetType().Name)
            {
                return true;
            }
            return false;
        }
    }
}
