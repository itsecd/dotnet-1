using Binary_operations.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Spectre.Console;

namespace Binary_operations.Repositories
{
    public class XmlOperationRepository : IOperationRepository
    {
        private const string StorageFileName = "operations.xml";
        private List<Operation> _operations;
        private void ReadFromFile()
        {
            if (_operations != null)
                return;

            if (!File.Exists(StorageFileName))
            {
                _operations = new List<Operation>();
                return;
            }

            var xmlSerializer = new XmlSerializer(typeof(List<Operation>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Open);
            _operations = (List<Operation>)xmlSerializer.Deserialize(fileStream);
        }

        private void WriteToFile()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Operation>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Create);
            xmlSerializer.Serialize(fileStream, _operations);
        }

        public void AddOperation(int index, Operation operation)
        {
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            ReadFromFile();
            _operations.Insert(index, operation);
            WriteToFile();

        }
        public void RemoveOperation(int index)
        {
            ReadFromFile();
            _operations.RemoveAt(index);
            WriteToFile();
        }

        public void RemoveCollection()
        {
            ReadFromFile();
            int counter = _operations.Count();
            while (counter != 0)
            {
                _operations.RemoveAt(counter - 1);
                --counter;
            }
            WriteToFile();
        }

        public void PrintCollection()
        {
            ReadFromFile();
            var table = new Table();
            table.AddColumn("Операция");
            table.AddColumn("Вид");
            table.AddColumn("Результат операции");
            foreach (var operation_type in _operations)
            {
                table.AddRow(operation_type.GetType().Name, operation_type.ToString(), operation_type.GetResult().ToString());
            }
            AnsiConsole.Write(table);
            WriteToFile();

        }

        public List<Operation> GetOperations()
        {
            ReadFromFile();
            return _operations;
        }
        public bool CompareOperations(int lhs_index, int rhs_index)
        {
            ReadFromFile();
            if (_operations[lhs_index].Equals(_operations[rhs_index]))
                return true;
            return false;
        }
       
        public void MinElement()
        {
            ReadFromFile();
            int min = int.MaxValue;
            foreach (var operation_element in _operations)
            {
                if (operation_element.GetResult() < min)
                    min = operation_element.GetResult();
                if (operation_element.GetResult() == min)
                    continue;
            }
            AnsiConsole.MarkupLine("[orange1]Минимальная операция, найденная циклом: [/]" + min.ToString()); // сделать покрасивее
            AnsiConsole.MarkupLine("[wheat1]Минимальная операция, найденная с помощью Linq: [/] " + _operations.Min(operation => operation.GetResult())); // сделать покрасивее
        }
    }
}
