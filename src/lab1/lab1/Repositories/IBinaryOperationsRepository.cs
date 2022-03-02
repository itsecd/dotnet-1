using Lab1.Operations;
using System.Collections.Generic;

namespace Lab1.Repositories
{
    interface IBinaryOperationsRepository
    {
        public void AddOperation(int index, BinaryOperation operation);
        public void RemoveOperation(int index);
        public void RemoveAll();

        public List<BinaryOperation> GetAll();
    }
}
