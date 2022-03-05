﻿using System;

namespace Lab1.Model
{
    public class DivRemainder: Operation
    {
        public override int Compute(int lhs, int rhs) => lhs % rhs;

        public override bool Equals(object obj)
        {
            if (obj is not DivRemainder)
                return false;
            else
                return true;
        }

        public override int GetHashCode() => GetType().GetHashCode();

        public override string ToString() => nameof(DivRemainder);
    }
}
