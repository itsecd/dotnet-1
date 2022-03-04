using System.Xml.Linq;

namespace Lab1.Matrix
{
    public abstract class AbstractMatrix
    {
        
        public abstract int Width { get; }
        public abstract int Height { get; }

        public abstract double this[int x, int y] {get; set;}
        public abstract double Norm();
        public abstract double NormL();
        public override string ToString() => $"Matrix [[{Height}x{Width}]]";
        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();
        public abstract XElement ToXml();
    }
}