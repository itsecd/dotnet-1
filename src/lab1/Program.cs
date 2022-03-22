using lab1.Model;
using lab1.Repositories;
using Spectre.Console;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {

            double[,] bma = { { 1, 2, 3, 8, 10 }, { 0, 4, 1, 2, 3 }, { 6, 2, 0, 5, 7 }, { 7, 15, 2, 5, 7 }, { 7, 15, 2, 5, 7 } };
            BufferedMatrix bm = new BufferedMatrix(bma);

            double[,] m = { { 1, 2, 3 }, { 0, 4, 1 }, { 6, 2, 0 }, { 7, 15, 2 } };

            SparseMatrix sm = new SparseMatrix(m);

            sm.SetValue(0, 1, 0);
            sm.SetValue(1, 0, 0);
            sm.SetValue(2, 2, 5);
            sm.SetValue(3, 1, 6);

            var matrixRepository = new XmlMatrixRepository();
            matrixRepository.Insert(0, bm);
            matrixRepository.Insert(0, sm);

            var tmp = matrixRepository.GetAll();
            foreach (var matrix in tmp)
                AnsiConsole.WriteLine(matrix.ToString()!);

            AnsiConsole.WriteLine(matrixRepository.Compare(0, 1));
            AnsiConsole.WriteLine(matrixRepository.Compare(1, 1));
            AnsiConsole.WriteLine(matrixRepository.Compare(0, 2));
        }
    }
}
