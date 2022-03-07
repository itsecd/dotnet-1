using System;
using lab1.Model;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            //BufferedMatrix a = new BufferedMatrix(5, 5);
            //Console.WriteLine(a.GetValue(0, 0));
            //Console.WriteLine(a.Height);
            //Console.WriteLine(a.Width);
            //Console.WriteLine(a.ToString());

            double[,] m = { { 0, 5, 3 }, { 1, 4, 7 }, { 0, 6, 0 }, { 1, 0, 3 } };
            SparseMatrix mat = new SparseMatrix(m);
            Console.WriteLine(mat.GetValue(0, 0));
            Console.WriteLine(mat.Height);
            Console.WriteLine(mat.Width);
            Console.WriteLine(mat.ToString());
            Console.WriteLine(mat.GetHashCode());
            mat.SetValue(1, 1, 0);
            mat.SetValue(0, 0, 8);
            mat.SetValue(2, 0, 0);
            Console.WriteLine(mat.ToString());
            Console.WriteLine(mat.GetAbsMax());
            Console.WriteLine(mat.GetHashCode());
        }
    }
}
