using System;
using System.Linq;

namespace dotnet_1.Matrix
{
    public class BufferedMatrix
    {
        public double[,] A;
        public int[] size;
        public BufferedMatrix(int h, int w)
        {
            A = new double[h, w];
            size = new int[2];
            size[0] = h;
            size[1] = w;
        }
        public override string ToString()
        {
            return $"Matrix, size = [{this.size[0]}, {this.size[1]}]";
        }

        public void Set(int x, int y, double val)
        {
            A[x, y] = val;
        }

        public double Get(int x, int y) => A[x, y];

    }

    public class SparseMatrix
    {

    }
}