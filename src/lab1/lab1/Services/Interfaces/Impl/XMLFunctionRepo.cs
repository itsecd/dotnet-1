using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Model;

namespace Lab1.Services.Interfaces.Impl
{
    internal class XMLFunctionRepo : IFunctionRepo
    {

        private const string StorageFileName = "f.xml";
        private List<Function>? _function;

        public void Clear()
        {
            var list = DeserializeXml();
            list.Clear();
            SerializeXml(list);
        }

        public List<Function> GetAll()
        {
            return DeserializeXml();
        }

        public void Insert(int index, Function newFunc)
        {
            var list = DeserializeXml();
            list.Insert(index, newFunc);
            SerializeXml(list);
        }

        public void AddFunction(Function function)
        {
            /*if (_function == null)
                throw new ArgumentNullException(nameof(function));*/
            DeserializeXml();
            _function.Add(function);
            SerializeXml(_function);
        }

        public void Delete(int index)
        {
            var list = DeserializeXml();
            list.RemoveAt(index);
            SerializeXml(list);
        }

        private List<Function> DeserializeXml()
        {
            if (_function is not null)
                return _function;
            if (!File.Exists(StorageFileName))
            {
                return _function = new List<Function>();

            }
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Function>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Open);
            _function = (List<Function>)(xmlSerializer.Deserialize(fileStream) ?? throw new InvalidOperationException());
            return _function;
        }

        private void SerializeXml(List<Function> funcList)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Function>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Create);
            xmlSerializer.Serialize(fileStream, funcList);
        }

    }
}
