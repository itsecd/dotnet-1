using System;
using ConsoleApp1.Model;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApp1.Repositories
{
    class XmlStorageRepository : IFunctionsRepository
    {
        private const string StorageFileName = "Repository.xml";

        private List<Func>? functionsList;

        public void Insert(int index, Func newFunc)
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

        public List<Func> GetAll()
        {
            return Read();
        }

        public void Clear()
        {
            var list = Read();
            list.Clear();
            Write(list);
        }


        private List<Func> Read()
        {
            if (functionsList is not null)
                return functionsList;
            if (!File.Exists(StorageFileName))
            {
                return functionsList = new List<Func>();

            }
            var xmlSerializer = new XmlSerializer(typeof(List<Func>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Open);
            functionsList = (List<Func>)(xmlSerializer.Deserialize(fileStream) ?? throw new InvalidOperationException());
            return functionsList;
        }

        private void Write(List<Func> funcList)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Func>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Create);
            xmlSerializer.Serialize(fileStream, funcList);
        }

    }
}