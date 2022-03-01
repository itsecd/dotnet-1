using System;
using System.Linq;

namespace Lab1
{
    public class BufferedMatrix : Matrix
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
    }
}