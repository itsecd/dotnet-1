using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_operations.Models
{
    public class Multyplication : Operation
    {
        public Numbers nums;

        public Multyplication() { }

        public Multyplication(int l, int r)
        {
            nums.lhs = l;
            nums.rhs = r;
        }
        public override int GetResult()
        {
            return nums.lhs * nums.rhs;
        }
        public override int GetHashCode()
        {
            int hashcode = this.nums.lhs.GetHashCode();
            hashcode = 31 * hashcode + nums.rhs.GetHashCode();
            return hashcode;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType().Name == GetType().Name)
            {
                Multyplication add = obj as Multyplication;
                return add.nums.lhs == nums.lhs && add.nums.rhs == nums.rhs;
            }
            return false;
        }
        public override string ToString()
        {
            return $"{nums.lhs} * {nums.rhs}";
        }
    }
}
