using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Laba1.Model;

namespace Laba1.Repositories
{
    public class XmlFigures3DRepository : IXmlFigures3DRepository
    {
        private const string StorageFileName = "figures.xml";
        private List<Figure3D> _figures;

        private void ReadFromFile()
        {
            if (_figures != null) return;
            if (!File.Exists(StorageFileName))
            {
                _figures = new List<Figure3D>();
                return;
            }
            var xmlDeserializer = new XmlSerializer(typeof(List<Figure3D>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Open);
            _figures = (List<Figure3D>)xmlDeserializer.Deserialize(fileStream);

        }
        private void WriteToFile()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Figure3D>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Create);
            xmlSerializer.Serialize(fileStream, _figures);
        }
        public void AddFigure(Figure3D figure)
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
    }
}
