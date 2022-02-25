namespace Binary_operations.Models
{
    public class Multyplication : Operation
    {
        public Multyplication() { }

        public Multyplication(int l, int r)
        {
            Lhs = l;
            Rhs = r;
        }
        public override int GetResult(int left, int right)
        {
            return left * right;
        }

        public override int GetHashCode()
        {
            int hashcode = this.Lhs.GetHashCode();
            hashcode = 31 * hashcode + Rhs.GetHashCode();
            return hashcode;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType().Name == GetType().Name)
            {
                Multyplication mul = obj as Multyplication;
                return mul.Lhs == Lhs && mul.Rhs == Rhs;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{Lhs} * {Rhs}";
        }
    }
}
