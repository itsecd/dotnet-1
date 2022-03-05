using Lab1.Model;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Lab1.Repositories
{
    public class XmlFigureRepository : IFigureRepository
    {
        private const string StorageFileName = "figure.xml";
        private List<Figure> _figures;
        private void ReadFromFile()
        {
            if (_figures != null) return;
            if (!File.Exists(StorageFileName))
            {
                _figures = new List<Figure>();
                return;
            }
            var xmlSerializer = new XmlSerializer(typeof(List<Figure>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Open);
            _figures = (List<Figure>)xmlSerializer.Deserialize(fileStream);
        }

        private void WriteToFile()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Figure>));
            using (var fileStream = new FileStream(StorageFileName, FileMode.Create))
            {
                xmlSerializer.Serialize(fileStream, _figures);
            }
        }

        public void Add(Figure figure)
        {
            if (figure == null)
                throw new ArgumentNullException(nameof(figure));
            else
            {
                ReadFromFile();
                _figures.Add(figure);
                WriteToFile();
            }

        }

        public void RemoveAt(int index)
        {
            ReadFromFile();
            if (index < 0 || index > _figures.Count - 1)
            {
                throw new IndexOutOfRangeException();
            }
            _figures.RemoveAt(index);
            WriteToFile();
        }

        public void RemoveAll()
        {
            ReadFromFile();

            for (int i = 0; i < _figures.Count; i++)
            {
                _figures.RemoveAt(i);
            }
            WriteToFile();
        }

        public List<Figure> GetList()
        {
            ReadFromFile();
            return _figures;
        }
    }
}
