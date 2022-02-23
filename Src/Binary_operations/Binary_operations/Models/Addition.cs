namespace Binary_operations.Models
{
    public class Addition : Operation
    {
        public Numbers nums;

        public Addition(int l, int r)
        {
            nums.Lhs = l;
            nums.Rhs = r;
        }

        public override int GetResult()
        {
            return nums.Lhs + nums.Rhs;
        }

        public override string ToString()
        {
            return $"{nums.Lhs} + {nums.Rhs}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType().Name == GetType().Name)
            {
                Addition add = obj as Addition;
                return add.nums.Lhs == nums.Lhs && add.nums.Rhs == nums.Rhs;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashcode = this.nums.Lhs.GetHashCode();
            hashcode = 31 * hashcode + nums.Rhs.GetHashCode();
            return hashcode;
        }
    }
}
