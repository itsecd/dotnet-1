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

        public bool CompareFunction(int index1, int index2)
        {
            DeserializeXml();
            if (_function[index1] != null && _function[index2] != null)
            {
                if (_function[index1].GetType() == _function[index2].GetType())
                {
                    return _function[index1].Equals(_function[index2]);
                }
                else
                    throw new ArgumentException("Mismatch of function types");
            }
            else
                throw new ArgumentException("Index is out of range");
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
