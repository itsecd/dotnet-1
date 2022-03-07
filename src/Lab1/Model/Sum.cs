
namespace Lab1.Model
{
    public class Sum : Operation
    {

        public override int Compute(int lhs, int rhs) => lhs + rhs;

        public override bool Equals(object? obj) => obj is Sum;

        public override int GetHashCode() => GetType().GetHashCode();
       
        public override string ToString() => nameof(Sum);


    }
}