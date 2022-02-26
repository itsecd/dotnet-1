using System;
using System.Linq;
using Lab1.Model;
using System.Collections.Generic;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mat = new double[3][];
            for (int i = 0; i < 3; i++) { mat[i] = new double[3]; };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    mat[i][j] = Math.Pow(i, 2);
                }
            }
            var matrix1 = new SparseMatrix(mat);
            int size1 = matrix1.GetMatrixSize();
            var value = matrix1.GetValueByIndex(1,2);
            Console.WriteLine(value);
            Console.WriteLine(size1);
            matrix1.PrintMatrix();
            Console.WriteLine(matrix1.ToString());
            Console.WriteLine(matrix1.GetHashCode());
            Console.WriteLine(matrix1.GetMaxElm());
            Console.WriteLine(matrix1.GetMaxElmLinq());

            var matrix2 = new BufferedMatrix(5, 5);

            var matrix3 = new BufferedMatrix(2, 3);

            var matrix4 = new BufferedMatrix(5, 5);

            var matrices = new List<IMatrix> { matrix1, matrix2, matrix3, matrix4 }; //контейнер с матрицами, нужен для нормы

            //foreach (IMatrix matrix in matrices)
            //{
            //   matrix.PrintMatrix();
            //    Console.WriteLine("--------");
            //}
        }
    }
}
