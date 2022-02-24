using Binary_operations.Models;
using System.Collections.Generic;

namespace Binary_operations.Repositories
{
    public interface IOperationRepository
    {
        void AddOperation(int index, Operation operation);
        void RemoveCollection();
        void RemoveOperation(int index);
        void MinElement();
        public bool CompareOperations(int lhsIndex, int rhsIndex);
        public List<Operation> GetOperations();
    }
}