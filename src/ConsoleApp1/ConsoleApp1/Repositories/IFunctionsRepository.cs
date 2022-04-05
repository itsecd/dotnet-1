using ConsoleApp1.Model;
using System.Collections.Generic;

namespace ConsoleApp1.Repositories
{
    public interface IFunctionsRepository
    {
        void Clear();
        List<Func> GetAll();
        void Insert(int index, Func newFunc);
        void RemoveAt(int index);
        string MinFunctionWithLINQ(double arg);
        string MinFunction(double arg);

    }
}
