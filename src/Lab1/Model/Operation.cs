using System;

namespace Lab1.Model
{
    public abstract class Operation
    {
        public abstract int Compute(int lhs, int rhs);

        public abstract override bool Equals(object obj);

        public abstract override int GetHashCode();

        public abstract override string ToString();

    }
}