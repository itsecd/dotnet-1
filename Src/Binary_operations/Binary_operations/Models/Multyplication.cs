namespace Binary_operations.Models
{
    public class Multyplication : Operation
    {
        public Numbers nums;

        public Multyplication() { }

        public Multyplication(int l, int r)
        {
            nums.Lhs = l;
            nums.Rhs = r;
        }
        public override int GetResult()
        {
            return nums.Lhs * nums.Rhs;
        }

        public override int GetHashCode()
        {
            int hashcode = this.nums.Lhs.GetHashCode();
            hashcode = 31 * hashcode + nums.Rhs.GetHashCode();
            return hashcode;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType().Name == GetType().Name)
            {
                Multyplication add = obj as Multyplication;
                return add.nums.Lhs == nums.Lhs && add.nums.Rhs == nums.Rhs;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{nums.Lhs} * {nums.Rhs}";
        }
    }
}
