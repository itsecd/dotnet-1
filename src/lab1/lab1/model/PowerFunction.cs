using System;

namespace model
{
	[Serializable]
	public class PowerFunction : Function
	{
        private double Value { get; set; } = 1;

        public PowerFunction(double value) { Value = value; }
        public PowerFunction() { }


        public override PowerFunction getDerivative() { return new PowerFunction(0); }

        public override double getResult(double x) => Value;

        public override bool Equals(object obj)
        {
            if (obj is PowerFunction func)
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