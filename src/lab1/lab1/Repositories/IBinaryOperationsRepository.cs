using Lab1.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
