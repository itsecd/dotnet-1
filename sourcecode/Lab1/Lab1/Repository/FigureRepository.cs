using Lab1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Lab1.Repository
{
    public class FigureRepository : IFigureRepository
    {
        private const string FileName = "figure.Xml";
        private List<Figure> _figures;

        private void ReadFileXml()
        {
            if (_figures != null) return;
            if (!File.Exists(FileName))
            {
                _figures = new List<Figure>();
                return;
            }
            var xmlSerializer = new XmlSerializer(typeof(List<Figure>));
            using var fileStream = new FileStream(FileName, FileMode.Open);
            _figures = (List<Figure>)xmlSerializer.Deserialize(fileStream);
        }

        private void WriteFileXml()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Figure>));
            using var fileStream = new FileStream(FileName, FileMode.Create);
            xmlSerializer.Serialize(fileStream, _figures);
        }

        public void Add(Figure figure)
        {
            if (NewFigure == null)
            {
                throw new ArgumentNullException(nameof(NewFigure));
            }
            ReadFileXml();
            _figures.Add(NewFigure);
            WriteFileXml();
        }

        public List<Figure> GetFigures()
        {
            ReadFileXml();
            return _figures;
        }

        public void RemoveAt(int index)
        {
            ReadFileXml();
            _figures.RemoveAt(index);
            WriteFileXml();
        }

        public void Clear()
        {
            ReadFileXml();
            _figures.Clear();
            WriteFileXml();
        }
    }
}
