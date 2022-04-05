using ConsoleApp1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace ConsoleApp1.Repositories
{
    class XmlStorageRepository : IFunctionsRepository
    {
        private const string StorageFileName = "Repository.xml";

        private List<Func> _functionsList;

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

        public string MinFunction(double arg)
        {
            var functions = GetAll();
            var min = double.MaxValue;
            var function = "";
            foreach (Func elem in functions)
            {
                if (elem.GetDerivative().Compute(arg) < min)
                {
                    min = elem.GetDerivative().Compute(arg);
                    function = elem.ToString();

                }
            }
            return function;
        }


        public string MinFunctionWithLINQ(double arg)
        {
            var functions = GetAll();
            var minValue = functions.Min(x => x.GetDerivative().Compute(arg));
            var funcMinValue = functions.First(x => x.GetDerivative().Compute(arg) == minValue);

            return funcMinValue.ToString();
        }

        private List<Func> Read()
        {
            if (_functionsList is not null)
                return _functionsList;
            if (!File.Exists(StorageFileName))
            {
                return _functionsList = new List<Func>();

            }
            var xmlSerializer = new XmlSerializer(typeof(List<Func>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Open);
            _functionsList = (List<Func>)(xmlSerializer.Deserialize(fileStream) ?? throw new InvalidOperationException());
            return _functionsList;
        }

        private void Write(List<Func> funcList)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Func>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Create);
            xmlSerializer.Serialize(fileStream, funcList);
        }

    }
}