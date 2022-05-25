using PromProgLab1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PromProgLab1.Repositories
{
    public class XmlOperationRepository : IOperationRepository
    {
        private const string StorageFileName = "operations.xml";
        private List<Operation> _operations;

        public XmlOperationRepository()
        {
            _operations = ReadFromFile();
        }

        private List<Operation> ReadFromFile()
        {
            if (_operations != null)
                return _operations;

            if (!File.Exists(StorageFileName))
            {
                return _operations = new List<Operation>();
            }

            var xmlSerializer = new XmlSerializer(typeof(List<Operation>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Open);
            var result = (List<Operation>?)xmlSerializer.Deserialize(fileStream);

            if (result is null)
                throw new InvalidOperationException();
            _operations = result;

            if (_operations == null)
                throw new ArgumentNullException(nameof(_operations));
            return _operations;
        }

        private void WriteToFile()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Operation>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Create);
            xmlSerializer.Serialize(fileStream, _operations);
        }

        public void Insert(int index, Operation operation)
        {
            if (operation == null)
                throw new ArgumentNullException(nameof(operation));

            if (index >= _operations.Count)
                _operations.Add(operation);
            else
                _operations.Insert(index, operation);
            WriteToFile();
        }

        public void RemoveAt(int index)
        {
            _operations = ReadFromFile();
            _operations.RemoveAt(index);
            WriteToFile();
        }

        public void Clear()
        {
            _operations = ReadFromFile();
            _operations.Clear();
            WriteToFile();
        }

        public List<Operation> GetOperations()
        {
            ReadFromFile();
            return _operations;
        }
    }
}
