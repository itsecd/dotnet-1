namespace PromProgLab1.Model
{
    public class Substraction : Operation
    {
        public override int Calculate(int lhs, int rhs) => lhs - rhs;

        public override bool Equals(object? obj) => obj is Substraction;

        public override int GetHashCode() => GetType().GetHashCode();

        public override string ToString() => nameof(Substraction);
    }
}
