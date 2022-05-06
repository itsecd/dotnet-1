using Lab1.Functions;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Lab1.Repositories
{
    class XmlFunctionRepository : IFunctionRepository
    {
        private List<Function> _functions;
        private const string _filePath = "functions.xml";

        private void ReadFile()
        {
            if (_functions != null)
                return;

            if (!File.Exists(_filePath))
            {
                _functions = new();
                return;
            }

            var xmlSerializer = new XmlSerializer(typeof(List<Function>));
            using var fileStream = new FileStream(_filePath, FileMode.OpenOrCreate);
            _functions = (List<Function>)xmlSerializer.Deserialize(fileStream);
        }

        private void WriteFile()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Function>));
            using var fileStream = new FileStream(_filePath, FileMode.OpenOrCreate);
            xmlSerializer.Serialize(fileStream, _functions);
        }

        public List<Function> GetAll()
        {
            ReadFile();
            return _functions;
        }

        public void RemoveAll()
        {
            ReadFile();
            _functions.RemoveAll(_ => true);
            WriteFile();
        }


        public void RemoveFunction(int index)
        {
            ReadFile();
            _functions.RemoveAt(index);
            WriteFile();
        }

        public void AddFunction(int index, Function operation)
        {
            ReadFile();
            _functions.Insert(index, operation);
            WriteFile();
        }
    }
}
