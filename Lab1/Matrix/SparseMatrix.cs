using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Spectre.Console;

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
        public SparseMatrix(int newHeight, int newWidth)
        {
            Height = newHeight;
            Width = newWidth;
            A = new();
        }

        public SparseMatrix(XElement elem)
        {
            Width = int.Parse(elem.Attribute("width").Value);
            Height = int.Parse(elem.Attribute("height").Value);
            A = new();
            foreach (XElement val in elem.Elements("value"))
            {
                var indVal = new Tuple<int, int>(int.Parse(val.Attribute("i").Value), int.Parse(val.Attribute("j").Value));
                A.Add(indVal, double.Parse(val.Value));
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
            XElement elem = new XElement("SparseMatrix");
            elem.Add(new XAttribute("width", Width));
            elem.Add(new XAttribute("height", Height));
            foreach (Tuple<int, int> coord in A.Keys)
            {
                XElement valElem = new XElement("value");
                valElem.Add(new XAttribute("i", coord.Item1));
                valElem.Add(new XAttribute("j", coord.Item2));
                valElem.Add(new XText($"{A[coord]}"));
                elem.Add(valElem);
            }
            return elem;
        }
        public override Table ToTable()
        {
            var tempTable = new Table();
            for (int i = 0; i < Width; i++)
                tempTable.AddColumn("");
            for (int i = 0; i < Height; i++)
            {
                string[] newrow = new string[Width];
                for (int j = 0; j < Width; j++)
                    newrow[j] = this[i,j].ToString();
                tempTable.AddRow(newrow);
            }
            return tempTable;
        }
    }
}