using Lab1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Lab1.Services
{
    class XmlStorageRepository : IFunctionsRepository
    {
        private const string StorageFileName = "functions.xml";

        private List<Function>? _functions;

        public void Insert(int index, Function newFunc)
        {
            var list = Read();
            list.Insert(index, newFunc);
            Write(list);
        }

        public void RemoveAt(int index)
        {
            var list = Read();
            list.RemoveAt(index);
            Write(list);
        }

        public List<Function> GetAll()
        {
            return Read();
        }

        public void Clear()
        {
            var list = Read();
            list.Clear();
            Write(list);
        }


        private List<Function> Read()
        {
            if (_functions is not null)
                return _functions;
            if (!File.Exists(StorageFileName))
            {
                return _functions = new List<Function>();

            }
            var xmlSerializer = new XmlSerializer(typeof(List<Function>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Open);
            _functions = (List<Function>)(xmlSerializer.Deserialize(fileStream) ?? throw new InvalidOperationException());
            return _functions;
        }

        private void Write(List<Function> funcList)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Function>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Create);
            xmlSerializer.Serialize(fileStream, funcList);
        }

    }
}
