using Microsoft.AspNetCore.Mvc;
using Xunit;
using Lab1.Repositories;
using Lab1.Operations;
using System.Collections.Generic;

namespace Lab1.Tests
{
    public class XmlBinaryOperationsRepositoryTests
    {
        [Fact]
        public void WriteReadOperations()
        {
            var rep = new XmlBinaryOperationsRepository();
            rep.RemoveAll();
            var operations = GetOperations();
            for (int i=0; i < operations.Count; ++i)
            {
                rep.AddOperation(i, operations[i]);
            }

            var result = rep.GetAll();

            Assert.Equal(operations,result);
        }

        private List<BinaryOperation> GetOperations()
        {
            List<BinaryOperation> list = new();
            list.Add(new Mul());
            list.Add(new Sum());
            list.Add(new Rem());
            list.Add(new Sum());
            list.Add(new Sub());
            list.Add(new Div());
            return list;            
        }

    }
}
