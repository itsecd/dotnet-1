namespace Binary_operations.Models
{
    public class Division : Operation
    {
        public Numbers nums;

        public Division(int l, int r)
        {
            nums.Lhs = l;
            nums.Rhs = r;
        }

        public override int GetResult()
        {  
            return nums.Lhs / nums.Rhs;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType().Name == GetType().Name)
            {
                Division add = obj as Division;
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
        public override string ToString()
        {
            return $"{nums.Lhs} - {nums.Rhs}";
        }
    }
}
