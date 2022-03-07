
namespace Lab1.Model
{
    public class Sub : Operation
    {
        public override int Compute(int lhs, int rhs) => lhs - rhs;

        public override bool Equals(object obj) => obj is Sub;

        public override int GetHashCode() => GetType().GetHashCode();

        public override string ToString() => nameof(Sub);
    }
}