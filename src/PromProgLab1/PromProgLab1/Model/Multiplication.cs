namespace PromProgLab1.Model
{
    public class Multiplication : Operation
    {
        public override int Calculate(int lhs, int rhs) => lhs * rhs;

        public override bool Equals(object? obj) => obj is Multiplication;

        public override int GetHashCode() => GetType().GetHashCode();

        public override string ToString() => nameof(Multiplication);
    }
}