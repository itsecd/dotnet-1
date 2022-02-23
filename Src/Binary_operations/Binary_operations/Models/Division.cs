using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_operations.Models
{
    public class Division : Operation
    {
        public Numbers nums;

        public Division() { }
        public Division(int l, int r)
        {
            nums.lhs = l;
            nums.rhs = r;
        }
        public override int GetResult()
        {
            // навесить исключение 
            return nums.lhs / nums.rhs;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType().Name == GetType().Name)
            {
                Division add = obj as Division;
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
        public override string ToString()
        {
            return $"{nums.lhs} - {nums.rhs}";
        }
    }
}
