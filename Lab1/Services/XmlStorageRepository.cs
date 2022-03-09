using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Lab1.Model;

namespace Lab1.Services
{
    class XmlStorageRepository
    {
        private const string StorageFileName = "Repository.xml";

        private List<Function> ?functionsList;

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
            if (functionsList is not null)
                return functionsList;
            if (!File.Exists(StorageFileName))
            {
                return functionsList = new List<Function>();
                
            }
            var xmlSerializer = new XmlSerializer(typeof(List<Function>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Open);
            functionsList = (List<Function>)(xmlSerializer.Deserialize(fileStream) ?? throw new InvalidOperationException());
            return functionsList;
        }

        private void Write(List<Function> funcList)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Function>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Create);
            xmlSerializer.Serialize(fileStream, funcList);
        }

    }
}
