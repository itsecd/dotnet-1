using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Lab1.Model;

namespace Lab1.Repositories
{
    public class FiguresRepository: IFiguresRepository
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
            var xmlDeserializer = new XmlSerializer(typeof(List<Figure>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Open);
            _figures = (List<Figure>)xmlDeserializer.Deserialize(fileStream);
        }
        private void WriteToFile()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Figure>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Create);
            xmlSerializer.Serialize(fileStream, _figures);
        }
        public void AddFigure(Figure figure, int index)
        {
            if (figure == null)
                throw new ArgumentNullException(nameof(figure));
            ReadFromFile();
            _figures.Insert(index, figure);
            WriteToFile();
        }
        public void RemoveFigure(int index)
        {
            ReadFromFile();
            _figures.RemoveAt(index);
            WriteToFile();
        }
        public void RemoveAllFigures()
        {
            ReadFromFile();
            _figures.Clear();
            WriteToFile();
        }
        public bool CompareFigures(int firstIndex, int secondIndex)
        {
            ReadFromFile();
            return _figures[firstIndex].Equals(_figures[secondIndex]);
        }
        public Rectangle GetMinRectangle(int index)
        {
            ReadFromFile();
            return _figures[index].GetMinRectangle();
        }
        public double SumArea()
        {
            ReadFromFile();
            double sum = 0;
            foreach (var figure in _figures)
            {
                sum += figure.GetArea();
            }
            return sum;
        }
        public double SumAreaLinq()
        {
            ReadFromFile();
            double sum = _figures.Sum(figure => figure.GetArea());
            return sum;
        }
        public Figure GetFigure(int index)
        {
            ReadFromFile();
            return _figures[index];
        }
        public List<Figure> GetFigures()
        {
            ReadFromFile();
            return _figures;
        }
        public int GetCountFigures()
        {
            ReadFromFile();
            return _figures.Count;
        }
    }
}
