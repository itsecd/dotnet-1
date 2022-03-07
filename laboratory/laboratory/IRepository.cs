using System.Collections.Generic;
using laboratory.model;

namespace laboratory
{
    public interface IRepository
    {
        List<Figure> GetAll();

        public int Count();

        void Insert(int index, Figure obj);

        void RemoveAt(int index);

        void Clear();

        void Serialize(string path);

        void Deserialize(string path);
    }
}
