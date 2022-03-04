using Lab1.Matrix;

namespace Lab1.Repository
{
    public interface IMatrixRepository
    {
        AbstractMatrix this[int index] {get;}
        int Count {get;}
        void Insert(AbstractMatrix mat, int index = 0);
        void Update(int index);
        void Delete(int index);
        void Clear();
        void Dump();
        void Load();
    }
}