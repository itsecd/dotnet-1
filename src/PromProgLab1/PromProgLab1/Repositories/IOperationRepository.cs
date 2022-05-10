using PromProgLab1.Model;
using System.Collections.Generic;

namespace PromProgLab1.Repositories
{
    public interface IOperationRepository
    {
        void Insert(int index, Operation operation);
        List<Operation> GetOperations();
        void Clear();
        void RemoveAt(int index);
    }
}