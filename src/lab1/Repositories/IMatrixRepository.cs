using lab1.Model;
using System.Collections.Generic;

namespace lab1.Repositories
{
    interface IMatrixRepository
    {
        public bool Compare(int lhs, int rhs);
        public void Insert(int index, IMatrix? matrix);
        public void RemoveAt(int index);
        public void Clear();
        public IMatrix GetMatrix(int index);
        public List<IMatrix> GetAll();
    }
}
