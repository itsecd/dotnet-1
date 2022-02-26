namespace Binary_operations.Models
{
    public class Substraction : Operation
    {
        public Substraction() { }

        public override int GetResult(int left, int right) => left - right;
        
        public override string ToString() => GetType().Name;

        public override bool Equals(object obj) => obj.GetType().Name == GetType().Name;

        public override int GetHashCode() => GetType().GetHashCode();
       
    }
}
