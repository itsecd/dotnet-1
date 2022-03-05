using System;

namespace model
{
    public class ExponentialFunction : IFunctions
    {
        //private static double _E = 2.72;
        private int _power;

        ExponentialFunction() { }
        ExponentialFunction(int _power) { this._power = _power; }
        public void setPower(int _power) { this._power = _power; }
        public int getPower() { return this._power; }

        public double getResult()
        {
            return Math.Exp(this._power);
        }

        public void toString()
        {
            Console.WriteLine("y=e`" + _power);
        }

    }
}