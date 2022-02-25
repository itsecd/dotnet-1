namespace Binary_operations.Models
{
    public class Division : Operation
    {
        public Division() { }

        public Division(int l, int r)
        {
            Lhs = l;
            Rhs = r;
        }

        public override int GetResult(int left, int right)
        {  
            return left / right;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType().Name == GetType().Name)
            {
                Division div = obj as Division;
                return div.Lhs == Lhs && div.Rhs == Rhs;
            }
            return false;
        }
        public override int GetHashCode()
        {
            int hashcode = this.Lhs.GetHashCode();
            hashcode = 31 * hashcode + Rhs.GetHashCode();
            return hashcode;
        }
        public override string ToString()
        {
            return $"{Lhs} - {Rhs}";
        }
    }
}
