using PromProg1.Models;
using System.Collections.Generic;

namespace PromProg1.Repository
{
    public interface IXMLOperationRepository
    {
        List<Operation> GetOperations();
        void InsertOperation(int index, Operation operation);
        void RemoveOperation(int index);
    }
}