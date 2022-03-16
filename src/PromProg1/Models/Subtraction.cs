﻿namespace PromProg1.Models
{
    public class Subtraction : Operation
    {
        public override double GetResult(double operand1, double operand2)
        {
            return operand1 - operand2;
        }
        public override string ToString()
        {
            return "Вычитание";
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            return (obj.GetType().Name == GetType().Name);
        }
    }
}
