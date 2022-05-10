using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prProgLab1.Model
{
    public class Const : Function
    {
        public int Value { get; init; }

        public Const() { }

        public Const(int value)
        {
            Value = value;
        }

        public override Function GetDerivative() => new Const(0);

        public override double GetValue(int x) => Value;

        public override string ToString() => Value.ToString();

        public override bool Equals(object o) => o is Const @const && @const.Value == Value;

        public override int GetHashCode() => Value.GetHashCode();
    }
}
