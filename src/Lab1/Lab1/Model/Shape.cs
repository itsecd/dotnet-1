namespace Lab1.Model
{
    public abstract class Shape
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
        public abstract Rectangle GetMinFramingRectangle();
        public abstract override string ToString();
        public abstract override bool Equals(object obj);
    }
}