using Lab1.Model;
using System.Collections.Generic;

namespace Lab1.Repository
{
    public interface IMatricesRepository
    {
        void AddMatrix(Matrix matrix, int index);
        void RemoveMatrix(int index);
        List<Matrix> GetMatrices();
        void PrintMatrices();
        void ClearRepository();
        bool CompareMatrices(int index1, int index2);
    }
}