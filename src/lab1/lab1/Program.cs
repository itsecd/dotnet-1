using System;
using lab1.Model;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            BufferedMatrix a = new BufferedMatrix(5, 5);
            Console.WriteLine(a.GetValue(0, 0));
            Console.WriteLine(a.Height);
            Console.WriteLine(a.Width);
            Console.WriteLine(a.ToString());

            double[,] m = { { 1, 2, 3 }, { 0, 4, 1 }, { 6, 2, 0 }, { 7, 15, 2 } };

            SparseMatrix sm = new SparseMatrix(m);
            Console.WriteLine(sm.GetValue(0, 0));
            Console.WriteLine(sm.Height);
            Console.WriteLine(sm.Width);
            Console.WriteLine(sm.ToString());

            sm.SetValue(0, 1, 0);
            sm.SetValue(1, 0, 0);
            sm.SetValue(2, 2, 5);
            sm.SetValue(3, 1, 6);

            Console.WriteLine(sm.ToString());
        }
    }
}
