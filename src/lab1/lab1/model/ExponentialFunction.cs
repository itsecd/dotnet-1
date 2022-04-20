using System;

namespace model
{
    [Serializable]
    public class ExponentialFunction : Function
    {

        private double Value { get; set; } = 1;

        public ExponentialFunction(double value) { Value = value; }


        public override ExponentialFunction getDerivative() { return new ExponentialFunction(0); }

        public override double getResult(double x) => Value;

        public override bool Equals(object obj)
        {
            if (obj is ExponentialFunction func)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }

    }
}