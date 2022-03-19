namespace Lab1.Model
{
    public class ConstFunc : Function
    {
        public override double GetValue(double x = 0)
        {
            return Coef;
        }

        public override Function GetDerivative()
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
}
