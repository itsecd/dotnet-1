using Lab1.Functions;
using System.Collections.Generic;

namespace Lab1.Repositories
{
    interface IFunctionRepository
    {
        public void AddFunction(int index, Function operation);
        public void RemoveFunction(int index);
        public void RemoveAll();

        public List<Function> GetAll();
    }
}
