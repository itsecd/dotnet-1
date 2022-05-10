namespace PromProgLab1.Model
{
    public class DivisionRemainder : Operation
    {
        public override int Calculate(int lhs, int rhs) => lhs % rhs;

        public override bool Equals(object? obj) => obj is DivisionRemainder;

        public override int GetHashCode() => GetType().GetHashCode();

        public override string ToString() => nameof(DivisionRemainder);
    }
}
