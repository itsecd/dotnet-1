using System;

namespace Model
{
    public class Log : Function
    {
        private double Value { get; set; } = 1;
        public Log(double value) { Value = value; }
        public Log() { }
        public override Log GetDerivative() { return new Log(0); }
        public override double GetResult(double x) => Value;
        public override bool Equals(object obj)
        {
            if ((obj is Log func) && (obj as Log).Value == this.Value)
            {
                return true;
            }
            return false;
        }
        public override string ToString() => $"{Value}";

    }
}
