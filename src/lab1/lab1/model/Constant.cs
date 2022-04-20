using model;
using System;

namespace model
{
    [Serializable]
    public class Constant : Function
    {
        private double Value { get; set; } = 1;

        public Constant(double value) { Value = value; }  


        public override Constant getDerivative() { return new Constant(0); }

        public override double getResult(double x) => Value;

        public override bool Equals(object obj)
        {
            if (obj is Constant func) {
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