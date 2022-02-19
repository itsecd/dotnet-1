using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class IntOperand
    {
        public int Value { get; }

        public IntOperand(int value) => Value = value;

        public IntOperand(IntOperand operand) => Value = operand.Value;

        public static IntOperand operator +(IntOperand lhs, IntOperand rhs) => new IntOperand(lhs.Value + rhs.Value);

        public static IntOperand operator -(IntOperand lhs, IntOperand rhs) => new IntOperand(lhs.Value - rhs.Value);

        public static IntOperand operator *(IntOperand lhs, IntOperand rhs) => new IntOperand(lhs.Value * rhs.Value);

        public static IntOperand operator /(IntOperand lhs, IntOperand rhs) => new IntOperand(lhs.Value / rhs.Value);

        public static IntOperand operator %(IntOperand lhs, IntOperand rhs) => new IntOperand(lhs.Value % rhs.Value);

    }
}
