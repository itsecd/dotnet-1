using prProgLab1.Model;
using System.Collections.Generic;

namespace prProgLab1.Repository
{
    public interface IFunctionsRepository
    {
        void Insert(int index, Function func);
        void RemoveAt(int index);
        List<Function> GetAll();
        void Clear();
        string MinFunc(int x);
        string MinFuncLINQ(int x);
    }
}