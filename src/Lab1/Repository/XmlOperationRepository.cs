﻿using System.IO;
using Lab1.Model;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System;
using Spectre.Console;

namespace Lab1.Repository
{
    public class XmlOperationRepository : IOperationRepository
    {
        private const string StorageFileName = "operations.xml";

        private List<Operation> _operations;

        private void ReadFromFile()
        {
            if (_operations != null) return;

            if (!File.Exists(StorageFileName))
            {
                _operations = new List<Operation>();
                return;
            }

            var xmlSerializer = new XmlSerializer(typeof(List<Operation>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Open);
            _operations = (List<Operation>)xmlSerializer.Deserialize(fileStream);
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

            ReadFromFile();
            _operations.Insert(index, operation);
            WriteToFile();

        }

        public void RemoveAt(int index)
        {
            ReadFromFile();
            _operations.RemoveAt(index);
            WriteToFile();
        }

        public void Clear()
        {
            ReadFromFile();
            _operations.Clear();
            WriteToFile();
        }

        public List<Operation> GetAll()
        {
            ReadFromFile();
            return _operations;
        }


    }
}
