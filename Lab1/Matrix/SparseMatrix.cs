using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Lab1.Matrix
{
    public class SparseMatrix : AbstractMatrix
    {
        public Dictionary<Tuple<int, int>, double> A;
        public override double this[int y, int x]
        {
            get
            {
                var indGet = new Tuple<int, int>(y, x);
                if (A.ContainsKey(indGet))
                    return A[indGet];
                return 0;
            }

            set
            {
                var indSet = new Tuple<int, int>(y, x);
                if (A.ContainsKey(indSet) && value == 0)
                    A.Remove(indSet);
                if (A.ContainsKey(indSet) && value != 0)
                    A[indSet] = value;
                else
                    A.Add(indSet, value);
            }
        }
        public override int Width { get; }
        public override int Height { get; }

        public SparseMatrix()
        {
            Height = 1;
            Width = 1;
            A = new();
        }
        public SparseMatrix(int H, int W)
        {
            Height = H;
            Width = W;
            A = new();
        }

        public SparseMatrix(XElement elem)
        {
            Width = Int32.Parse(elem.Attribute("width").Value);
            Height = Int32.Parse(elem.Attribute("height").Value);
            A = new();
            foreach (XElement val in elem.Elements("value"))
            {
                var indVal = new Tuple<int, int>(Int32.Parse(val.Attribute("i").Value), Int32.Parse(val.Attribute("j").Value));
                A.Add(indVal, Double.Parse(val.Value));
            }
            
        }

        public override double Norm()
        {
            double res = Math.Abs(this[0, 0]);
            foreach (double i in A.Values)
                if (Math.Abs(i) > res)
                    res = Math.Abs(i);
            return res;
        }

        public override double NormL()
        {
            double[] n = new[] { Math.Abs(A.Values.Max()), Math.Abs(A.Values.Min()) };
            return n.Max();
        }

        public override string ToString() => $"SparseMatrix [[{Height}x{Width}]]";
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;
            var tmp = obj as SparseMatrix;
            if (tmp.Width != Width || tmp.Height != Height)
                return false;
            return A.SequenceEqual(tmp.A);
        }
        public override int GetHashCode() => HashCode.Combine(A, Height, Width);
        public override XElement ToXml()
        {
            XElement tmp = new XElement("SparseMatrix");
            tmp.Add(new XAttribute("width", Width));
            tmp.Add(new XAttribute("height", Height));
            foreach (Tuple<int, int> coord in A.Keys)
            {
                XElement tmp1 = new XElement("value");
                tmp1.Add(new XAttribute("i", coord.Item1));
                tmp1.Add(new XAttribute("j", coord.Item2));
                tmp1.Add(new XText($"{A[coord]}"));
                tmp.Add(tmp1);
            }
            return tmp;
        }
    }
}