using Lab1.Model;
using System.Collections.Generic;

namespace Lab1.Services
{
    public interface IXmlStorageRepository
    {
        void Clear();
        List<Function> GetAll();
        void Insert(int index, Function newFunc);
        void RemoveAt(int index);
    }
}