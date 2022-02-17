using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1
{
    public abstract class Matrix
    {
        public abstract int Width { get; }
        public abstract int Height { get; }

        public abstract double this[int x, int y] {get; set;}
        public abstract double Norm();
        public abstract double NormL();
        public override string ToString() => $"Matrix [[{Height}x{Width}]]";
        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();
    }
}