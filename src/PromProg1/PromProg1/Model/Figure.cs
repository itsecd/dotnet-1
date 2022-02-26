using System;

namespace PromProg1
{
    public abstract class Figure
    {
        public abstract double Square();
        public abstract double Perimeter();
        public abstract override string ToString();
        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();
        public abstract Rectangle FramingRectangle();


    }
}