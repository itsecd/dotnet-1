using System;
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
            Height = w;
            A = new double[Height, Width];
        }

        public double Get(int x, int y) => A[x, y];

        public void Set(int x, int y, double val)
        {
            A[x, y] = val;
        }

        public static bool operator == (BufferedMatrix lhs, BufferedMatrix rhs)
        {
            if (lhs.Width != rhs.Width || lhs.Height != rhs.Height)
                return false;
            for (int i=0;i<lhs.Height;i++)
                for (int j=0;j<lhs.Width;j++)
                    if (lhs.Get(i, j) != rhs.Get(i, j))
                        return false;
            return true;
        }

        public static bool operator != (BufferedMatrix lhs, BufferedMatrix rhs)
        {
            if (lhs.Width != rhs.Width || lhs.Height != rhs.Height)
                return true;
            for (int i=0;i<lhs.Height;i++)
                for (int j=0;j<lhs.Width;j++)
                    if (lhs.Get(i, j) != rhs.Get(i, j))
                        return true;
            return false;
        }

    }

    public class SparseMatrix
    {

    }
}