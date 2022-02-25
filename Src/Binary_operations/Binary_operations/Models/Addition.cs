namespace Binary_operations.Models
{
    public class Addition : Operation
    {
        public Addition() { }
        public Addition(int l, int r)
        {
            Lhs = l;
            Rhs = r;
        }

        public override int GetResult(int left, int right)
        {
            return left + right;
        }

        public override string ToString()
        {
            return $"{Lhs} + {Rhs}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType().Name == GetType().Name)
            {
                Addition add = obj as Addition;
                return add.Lhs == Lhs && add.Rhs == Rhs;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashcode = this.Lhs.GetHashCode();
            hashcode = 31 * hashcode + Rhs.GetHashCode();
            return hashcode;
        }
    }
}
