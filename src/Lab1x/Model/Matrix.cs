using System;
using System.Text;
using System.Xml;

namespace Lab1.Model
{
    public abstract class Matrix : IMatrix
    {
        public abstract double this[int i, int j] { get; set; }

        public abstract int Width { get; init; }
        public abstract int Height { get; init; }

        public abstract double GetMaxNorm();
        public abstract void GetXml(XmlTextWriter writer);

        public override bool Equals(object? obj)
        {

            if (this == obj)
            {
                return true;
            }
            if (obj is not IMatrix)
            {
                return false;
            }
            var tmp = (IMatrix)obj;
            if (tmp.Height != Height || tmp.Width != Width)
            {
                return false;
            }
            for (var i = 0; i < Height; ++i)
                for (var j = 0; j < Width; ++j)
                    if (this[i, j] != tmp[i, j])
                        return false;
            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    sb.Append($"{this[i, j]} ");
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
        public override int GetHashCode()
        {
            int tmp = 1;
            double hash = Height + Width;
            for (int i = 0; i < Height; ++i)
                for (int j = 0; j < Width; ++j)
                {
                    hash += tmp * i + tmp * j + this[i, j];
                    ++tmp;
                }
            return (int)Math.Round(hash);
        }
    }
}
