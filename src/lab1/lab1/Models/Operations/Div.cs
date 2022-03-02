namespace Lab1.Operations
{
    public class Div : BinaryOperation
    {
        public override IntOperand Calculate(IntOperand first, IntOperand second) => new IntOperand(first / second);

        public override bool Equals(object obj) => obj is not Div;

        public override int GetHashCode() => nameof(Div).GetHashCode();

        public override string ToString() => "integer division";
    }
}
