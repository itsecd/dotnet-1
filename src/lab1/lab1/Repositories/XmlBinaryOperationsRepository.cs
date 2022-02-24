using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab1.Repositories
{
    class XmlBinaryOperationsRepository : IBinaryOperationsRepository
    {
        private const string _filePath = "database.xml";

        private List<BinaryOperation> _operations;

        private void ReadFile()
        {
            if (_operations != null)
                return;

            if (!File.Exists(_filePath))
            {
                _operations = new();
                return;
            }

            var xmlSerialazer = new XmlSerializer(typeof(List<BinaryOperation>));
            using var fileStream = new FileStream(_filePath, FileMode.Open);
            _operations = (List<BinaryOperation>)xmlSerialazer.Deserialize(fileStream);
        }

        private void WriteFile()
        {
            var xmlSerialazer = new XmlSerializer(typeof(List<BinaryOperation>));
            using var fileStream = new FileStream(_filePath, FileMode.Create);
            xmlSerialazer.Serialize(fileStream,_operations);
        }

        public void AddOperation(int index, BinaryOperation operation)
        {
            ReadFile();
            _operations.Insert(index,operation);
            WriteFile();
        }

        public void RemoveOperation(int index)
        {
            ReadFile();
            _operations.RemoveAt(index);
            WriteFile();
        }

        public void RemoveAll()
        {
            ReadFile();
            _operations.RemoveAll( _ =>  true );
            WriteFile();
        }

        public List<BinaryOperation> GetAll()
        {
            ReadFile();
            return _operations;
        }
    }
}
