using Lab1.Models;

namespace Lab1.Repositories
{
    public interface IFunctionsRepository
    {
        void AddFunction(Function function);
        void Clear();
        void RemoveFunction(int index);
        List<Function> GetFunctions();

    }
}