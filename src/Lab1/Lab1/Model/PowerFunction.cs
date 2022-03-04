using System;

namespace Lab1.Model
{
    internal class PowerFunction
    {
        public double Сoefficient { get; set; }

        public double Degree { get; set; }

        public PowerFunction() 
        {
            Сoefficient = 0;
            Degree = 0; 
        }

        public PowerFunction(double coefficient, double degree) 
        {
            Сoefficient = coefficient;
            Degree = degree; 
        }

        public dynamic Calculation(double x)
        {
            return Сoefficient * Math.Pow(x, Degree);
        } 

        public string Derivative()
        {
            if (Degree == 0 || Сoefficient == 0) 
            { 
                return "y'= 0"; 
            }
            if (Degree == 1)
            {
                return $"y'= {Сoefficient * Degree}";
            }    
            return $"y'= {Сoefficient * Degree}x^{Degree - 1}";
        }

        public override string ToString()
        {       
            if (Сoefficient == 0)
            {
                return $"y= 0";
            }             
            if ((Сoefficient == 1) && (Degree != 0))
            {
                return $"y= x^{Degree}";
            }           
            if (Degree == 0)
            {
                return $"y= {Сoefficient}";
            }  
            return $"y= {Сoefficient}x^{Degree}";
        }

        public override bool Equals(Object obj)
        {
            if (obj is not PowerFunction other) 
            {
                return false;
            }
            return (Сoefficient == other.Сoefficient) && (Degree == other.Degree);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Сoefficient, Degree);
        }
    }
}
