using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1
{
    public class BufferedMatrix
    {
        protected double[,] A;
        int Width { get; }
        int Height { get; }

        public BufferedMatrix(int w, int h)
        {
            Width = w;
            Height = h;
            A = new double[Height, Width];
        }

        public double Get(int x, int y) => A[x, y];

        public void Set(int x, int y, double val)
        {
            A[x, y] = val;
        }

        public double Norm
        {
            get
            {
                double maxval = Math.Abs(A[0, 0]);
                for (int i = 0; i < Height; i++)
                    for (int j = 0; j < Width; j++)
                        if (Math.Abs(A[i, j]) > maxval)
                            maxval = Math.Abs(A[i, j]);
                return maxval;
            }
        }

        public double NormL()
        {
            return 0;
        }

        public override string ToString()
        {
            return $"BufferedMatrix [[{Height} x {Width}]]";
        }

        public override bool Equals(object obj)
        {
            bool eq = obj.GetType() != this.GetType();
            if (eq)
                return false;
            BufferedMatrix tmp = obj as BufferedMatrix;
            return this == tmp;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(A, Width, Height);
        }

        public static bool operator ==(BufferedMatrix lhs, BufferedMatrix rhs)
        {
            if (lhs.Width != rhs.Width || lhs.Height != rhs.Height)
                return false;
            for (int i = 0; i < lhs.Height; i++)
                for (int j = 0; j < lhs.Width; j++)
                    if (lhs.Get(i, j) != rhs.Get(i, j))
                        return false;
            return true;
        }

        public static bool operator !=(BufferedMatrix lhs, BufferedMatrix rhs)
        {
            if (lhs.Width != rhs.Width || lhs.Height != rhs.Height)
                return true;
            for (int i = 0; i < lhs.Height; i++)
                for (int j = 0; j < lhs.Width; j++)
                    if (lhs.Get(i, j) != rhs.Get(i, j))
                        return true;
            return false;
        }

    }

    public class SparseMatrix
    {

    }
}