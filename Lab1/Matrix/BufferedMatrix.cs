using System;
using System.Linq;
using System.Xml.Linq;

namespace Lab1.Matrix
{
    public class BufferedMatrix : AbstractMatrix
    {
        public double[] A;
        public override double this[int y, int x]
        {
            get => A[y * Height + x];
            set {A[y * Height + x] = value;}
        }
        public override int Width { get; }
        public override int Height { get; }

        public BufferedMatrix()
        {
            Height = 1;
            Width = 1;
            A = new double[1];
        }
        public BufferedMatrix(int H, int W)
        {
            Height = H;
            Width = W;
            A = new double[H*W];
        }

        public BufferedMatrix(XElement elem)
        {
            Width = Int32.Parse(elem.Attribute("width").Value);
            Height = Int32.Parse(elem.Attribute("height").Value);
            A = new double[Height*Width];
            int index = 0;
            foreach (XElement val in elem.Elements("value"))
            {
                A[index] = Double.Parse(val.Value);
                index += 1;
            }
        }

        public override double Norm()
        {
            double res = Math.Abs(A[0]);
            foreach (double i in A)
                if (Math.Abs(i) > res)
                    res = Math.Abs(i);
            return res;
        }

        public override double NormL()
        {
            double[] n = new[] {Math.Abs(A.Max()), Math.Abs(A.Min())};
            return n.Max();
        }

        public override string ToString() => $"BufferedMatrix [[{Height}x{Width}]]";
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;
            var tmp = obj as BufferedMatrix;
            if (tmp.Width != Width || tmp.Height != Height)
                return false;
            return A.SequenceEqual(tmp.A);
        }
        public override int GetHashCode() => HashCode.Combine(A, Height, Width);
        public override XElement ToXml()
        {
            XElement tmp = new XElement("BufferedMatrix");
            tmp.Add(new XAttribute("width", Width));
            tmp.Add(new XAttribute("height", Height));
            foreach (double val in A)
            {
                var tmp1 = new XElement("value");
                tmp1.Add(new XText($"{val}"));
                tmp.Add(tmp1);
            }
            return tmp;
        }
    }
}