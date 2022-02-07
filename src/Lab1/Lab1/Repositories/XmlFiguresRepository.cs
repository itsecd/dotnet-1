using Lab1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Lab1.Repositories
{
    public class XmlFiguresRepository : IFiguresRepository
    {
        private const string StorageFileName = "figures.xml";

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
            using var fileStream = new FileStream(StorageFileName, FileMode.Create);
            xmlSerializer.Serialize(fileStream, _figures);
        }

        public void AddFigure(Figure figure)
        {
            if (figure == null)
                throw new ArgumentNullException(nameof(figure));

            ReadFromFile();
            _figures.Add(figure);
            WriteToFile();
        }

        public void RemoveFigure(int index)
        {
            ReadFromFile();
            _figures.RemoveAt(index);
            WriteToFile();
        }

        public List<Figure> GetFigures()
        {
            ReadFromFile();
            return _figures;
        }
    }
}
