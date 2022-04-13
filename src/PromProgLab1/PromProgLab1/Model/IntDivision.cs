using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromProgLab1.Model
{
    public class IntDivision : Operation
    {

        public override int GetResult(int lhs, int rhs) => lhs / rhs;

        public override bool Equals(object? obj) => obj is IntDivision;

        public override int GetHashCode() => GetType().GetHashCode();

        public override string ToString() => nameof(IntDivision);
    }
}
