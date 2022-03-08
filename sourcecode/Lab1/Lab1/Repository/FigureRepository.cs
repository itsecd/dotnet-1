using Lab1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Lab1.Repository
{
    public class FigureRepository : IFigureRepository
    {
        private const string FileName = "Data.xml";
        private List<Figure> figure;
        private void ReadFileXml()
        {
            if (!File.Exists(FileName))
            {
                figure = new List<Figure>();
            }
            var xmlSelializer = new XmlSerializer(typeof(List<Figure>));
            using var fileStream = new FileStream(FileName, FileMode.Open);
            figure = (List<Figure>)xmlSelializer.Deserialize(fileStream);
        }
        private void WriteFileXml()
        {
            var xmlSelializer = new XmlSerializer(typeof(List<Figure>));
            using var fileStream = new FileStream(FileName, FileMode.Create);
            xmlSelializer.Serialize(fileStream, figure);
        }
        public void AddFigure(Figure _figure)
        {
            if (_figure == null)
            {
                throw new ArgumentNullException(nameof(_figure));
            }
            ReadFileXml();
            figure.Add(_figure);
            WriteFileXml();
        }

        public List<Figure> getFigure()
        {
            ReadFileXml();
            return figure;
        }
        public void RemoveFigure(int index)
        {
            ReadFileXml();
            figure.RemoveAt(index);
            WriteFileXml();
        }
        public void ClearAllFigure()
        {
            ReadFileXml();
            figure.Clear();
            WriteFileXml();
        }
    }
}
