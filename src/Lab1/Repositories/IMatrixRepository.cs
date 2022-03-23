using Lab1.Model;
using System.Collections.Generic;

namespace Lab1.Repositories
{
    public interface IMatrixRepository
    {
        public void Insert(int index, IMatrix matrix);
        public void Update();
        public void RemoveAt(int index);
        public void Clear();
        public IMatrix GetMatrix(int index);
        public List<IMatrix> GetAll();
    }
}
