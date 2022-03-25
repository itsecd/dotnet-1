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
        private List<Figure> _listFigures;

        private void ReadFileXml()
        {
            if (_listFigures != null) return;
            if (!File.Exists(FileName))
            {
                _listFigures = new List<Figure>();
                return;
            }
            var xmlSerializer = new XmlSerializer(typeof(List<Figure>));
            using var fileStream = new FileStream(FileName, FileMode.Open);
            _listFigures = (List<Figure>)xmlSerializer.Deserialize(fileStream);
        }

        private void WriteFileXml()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Figure>));
            using var fileStream = new FileStream(FileName, FileMode.Create);
            xmlSerializer.Serialize(fileStream, _listFigures);
        }

        public void Add(Figure NewFigure)
        {
            if (NewFigure == null)
            {
                throw new ArgumentNullException(nameof(NewFigure));
            }
            ReadFileXml();
            _listFigures.Add(NewFigure);
            WriteFileXml();
        }

        public List<Figure> GetFigures()
        {
            ReadFileXml();
            return _listFigures;
        }

        public void RemoveAt(int index)
        {
            ReadFileXml();
            _listFigures.RemoveAt(index);
            WriteFileXml();
        }

        public void Clear()
        {
            ReadFileXml();
            _listFigures.Clear();
            WriteFileXml();
        }
    }
}
