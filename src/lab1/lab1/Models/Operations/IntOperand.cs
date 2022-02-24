using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class IntOperand :  IComparable
    {
        private int _value;
        private bool MaxValue { get; set; }
        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                MaxValue = false;
            }
        }

        public override string ToString() => Value.ToString();

        public IntOperand(int value) => Value = value;

        public IntOperand(IntOperand operand) => Value = operand.Value;

        public static IntOperand operator +(IntOperand lhs, IntOperand rhs) => new IntOperand(lhs.Value + rhs.Value);

        public static IntOperand operator -(IntOperand lhs, IntOperand rhs) => new IntOperand(lhs.Value - rhs.Value);

        public static IntOperand operator *(IntOperand lhs, IntOperand rhs) => new IntOperand(lhs.Value * rhs.Value);

        public static IntOperand operator /(IntOperand lhs, IntOperand rhs) => new IntOperand(lhs.Value / rhs.Value);

        public static IntOperand operator %(IntOperand lhs, IntOperand rhs) => new IntOperand(lhs.Value % rhs.Value);

        public static bool operator <(IntOperand lhs, IntOperand rhs)
        {
            if (lhs.MaxValue)
                return false;
            if (rhs.MaxValue)
                return true;
            return lhs.Value < rhs.Value;
        }

        public static bool operator ==(IntOperand lhs, IntOperand rhs)
            => lhs.Value == rhs.Value;
        public static bool operator !=(IntOperand lhs, IntOperand rhs)
          => !(lhs == rhs);

        public static bool operator >(IntOperand lhs, IntOperand rhs)
            => !(lhs < rhs);

        public static bool operator <=(IntOperand lhs, IntOperand rhs)
            => lhs < rhs || lhs == rhs;

        public static bool operator >=(IntOperand lhs, IntOperand rhs)
            => lhs > rhs || lhs == rhs;

        public static IntOperand GetMaxValue()
        {
            var op = new IntOperand(int.MaxValue);
            op.MaxValue = true;
            return op;
        }

    
        public override bool Equals(object obj)
        {
            if (obj is not IntOperand op)
                return false;
            else
                return this == op ;
        }

        public override int GetHashCode() => Value.GetHashCode();

        public int CompareTo(object obj)
        {
            return _value.CompareTo(obj);
        }
    }
}
