using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_operations.Models
{
    public class Addition : Operation
    {
        public Numbers nums;

        public Addition() { }

        public Addition(int l, int r)
        {
            nums.lhs = l;
            nums.rhs = r;
        }

        public override int GetResult()
        {
            return nums.lhs + nums.rhs;
        }

        public override string ToString()
        {
            return $"{nums.lhs} + {nums.rhs}";
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType().Name == GetType().Name)
            {
                Addition add = obj as Addition;
                return add.nums.lhs == nums.lhs && add.nums.rhs == nums.rhs;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hashcode = this.nums.lhs.GetHashCode();
            hashcode = 31 * hashcode + nums.rhs.GetHashCode();
            return hashcode;
        }
    }
}
