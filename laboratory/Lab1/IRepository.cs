using System.Collections.Generic;

namespace Lab1
{
    public interface IRepository
    {
        List<Figure>? GetAll();

        void Insert(int index, Figure obj);

        void RemoveAt(int index);

        void Clear();
    }
}
