using iProg1.Model;
using Spectre.Console;

namespace iProg1.Repositories
{
    public interface IMatrixRepository
    {
        int GetCount();
        void AddMatrix(Matrix matrix, int index);
        bool Compare(Matrix fst, Matrix sec);
        void Output();
        void RemoveAllMatrix();
        void RemoveMatrix(int index);
        ValidationResult IsIndexInRange(int index);
    }
}