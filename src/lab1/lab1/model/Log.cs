using System;
namespace model
{
	[Serializable]
	public class Log : Function
	{

        private double Value { get; set; } = 1;

        public Log(double value) { Value = value; }


        public override Log getDerivative() { return new Log(0); }

        public override double getResult(double x) => Value;

        public override bool Equals(object obj)
        {
            if (obj is Log func)
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
