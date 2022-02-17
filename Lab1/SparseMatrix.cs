using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1
{
    public class SparseMatrix : Matrix
    {
        Dictionary<Tuple<int, int>, double> A;
        public override double this[int y, int x]
        {
            get
            {
                if (A.ContainsKey(new Tuple<int, int>(y, x)))
                    return A[new Tuple<int, int>(y, x)];
                return 0;
            }

            set
            {
                var tmpCoord = new Tuple<int, int>(y, x);
                if (A.ContainsKey(tmpCoord) && value == 0)
                    A.Remove(tmpCoord);
                if (A.ContainsKey(tmpCoord) && value != 0)
                    A[tmpCoord] = value;
                else
                    A.Add(tmpCoord, value);
            }
        }
        public override int Width { get; }
        public override int Height { get; }

        public SparseMatrix(int H, int W)
        {
            Height = H;
            Width = W;
            A = new();
        }

        public override double Norm()
        {
            double res = Math.Abs(this[0,0]);
            foreach (double i in A.Values)
                if (Math.Abs(i) > res)
                    res = Math.Abs(i);
            return res;
        }

        public override double NormL()
        {
            double[] n = new[] {Math.Abs(A.Values.Max()), Math.Abs(A.Values.Min())};
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
    }
}