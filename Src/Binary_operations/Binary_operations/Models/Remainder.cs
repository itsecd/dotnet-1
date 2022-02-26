namespace Binary_operations.Models
{
    public class Remainder : Operation
    {
        public Remainder() { }

        public override int GetResult(int left, int right)
        {
            return left % right;
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType().Name == GetType().Name)
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.GetType().GetHashCode();
        }
    }
}
