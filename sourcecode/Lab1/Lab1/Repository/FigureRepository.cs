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
        private List<Figure> ListFigures;

        private void ReadFileXml()
        {
            if (ListFigures != null) return;
            if (!File.Exists(FileName))
            {
                ListFigures = new List<Figure>();
                return;
            }
            var XmlSelializer = new XmlSerializer(typeof(List<Figure>));
            using var fileStream = new FileStream(FileName, FileMode.Open);
            ListFigures = (List<Figure>)XmlSelializer.Deserialize(fileStream);
        }

        private void WriteFileXml()
        {
            var XmlSelializer = new XmlSerializer(typeof(List<Figure>));
            using var fileStream = new FileStream(FileName, FileMode.Create);
            XmlSelializer.Serialize(fileStream, ListFigures);
        }

        public void Add(Figure NewFigure)
        {
            if (NewFigure == null)
            {
                throw new ArgumentNullException(nameof(NewFigure));
            }
            ReadFileXml();
            ListFigures.Add(NewFigure);
            WriteFileXml();
        }

        public List<Figure> GetFigures()
        {
            ReadFileXml();
            return ListFigures;
        }

        public void RemoveAt(int indeX)
        {
            ReadFileXml();
            ListFigures.RemoveAt(indeX);
            WriteFileXml();
        }

        public void Clear()
        {
            ReadFileXml();
            ListFigures.Clear();
            WriteFileXml();
        }
    }
}
