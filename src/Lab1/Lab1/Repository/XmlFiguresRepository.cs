using Lab1.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace Lab1.Repository
{
    public class XmlFiguresRepository : IFiguresRepository
    {
        private const string StorageFileName = "figures.xml";

        private List<Figure> _figures;

        public XmlFiguresRepository()
        {
            ReadFromFile();
        }

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
            fileStream.Close();
        }

        private void WriteToFile()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Figure>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Create);
            xmlSerializer.Serialize(fileStream, _figures);
        }

        public List<Figure> GetFigures()
        {
            return _figures;
        }

        public void AddFigure(int index, Figure figure)
        {
            if (figure == null)
                throw new ArgumentNullException();

            ReadFromFile();
            if (_figures.Count <= index)
            {
                _figures.Add(figure);
            }
            else
            {
                RemoveFigure(index);
                _figures.Insert(index, figure);
            }
            WriteToFile();
        }

        public void RemoveFigure(int index)
        {
            ReadFromFile();
            _figures.RemoveAt(index);
            WriteToFile();
        }

        public void DeleteFigures()
        {
            if (_figures.Count > 0)
                _figures.Clear();

            WriteToFile();
        }

        public double GetTotalAreaManually()
        {
            double area = 0;
            foreach (var figure in _figures)
            {
                area += figure.GetArea();
            }
            return area;
        }

        public double GetTotalAreaLinq()
        {
            return _figures.Sum(figure => figure.GetArea());
        }
    }
}
