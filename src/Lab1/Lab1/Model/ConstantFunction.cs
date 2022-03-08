namespace Lab1.Model
{
    public class ConstantFunction : Function
    {
        private readonly double C;

        public ConstantFunction() 
        { 
            C = 0; 
        }

        public ConstantFunction(double c) 
        { 
            C = c; 
        }

        public override dynamic Calculate(double value) 
        { 
            return C; 
        }

        public override string Derivative() 
        { 
            return "y'= 0"; 
        }

        public override string ToString() 
        { 
            return $"y = {C}"; 
        }

        public override bool Equals(object obj)
        {
            if (obj is not ConstantFunction other)
            {
                return false;
            }
            return C == other.C;
        }

        public override int GetHashCode()
        {
            return C.GetHashCode();
        }
    }
}