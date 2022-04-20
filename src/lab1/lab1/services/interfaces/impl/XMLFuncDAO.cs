using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using model;

namespace lab1.services.interfaces.impl
{
    internal class XMLFuncDAO : IFunctionRepo
    {

        private const string StorageFileName = "functions.xml";
        private List<Function>? function;

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public List<Function> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, Function newFunc)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        private List<Function> DeserializeXml()
        {
            if (function is not null)
                return function;
            if (!File.Exists(StorageFileName))
            {
                return function = new List<Function>();

            }
            var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(List<Function>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Open);
            function = (List<Function>)(xmlSerializer.Deserialize(fileStream) ?? throw new InvalidOperationException());
            return function;
        }

        private void SerializeXml(List<Function> funcList)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Function>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Create);
            xmlSerializer.Serialize(fileStream, funcList);
        }

    }
}
