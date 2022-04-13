using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromProgLab1.Model
{
    public class Addition : Operation
    {
        public Addition() { }

        public override int GetResult(int left, int right) => left + right;

        public override string ToString() => nameof(Addition);

        public override bool Equals(object? obj) => obj is Addition;

        public override int GetHashCode() => GetType().GetHashCode();

    }
}