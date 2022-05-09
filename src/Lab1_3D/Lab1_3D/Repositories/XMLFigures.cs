using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Lab1_3D.Model;

namespace Lab1_3D.Repositories
{
    internal class XmlFigures3DRepository : IFigures
    {
        private const string StorageFileName = "3Dfigures.xml";
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
        public void AddFigure(Figure3D figure, int index)
        {
            if (figure == null)
                throw new ArgumentNullException(nameof(figure));
            ReadFromFile();
            _figures.Insert(index, figure);
            WriteToFile();
        }
        public void DeleteFigure(int index)
        {
            ReadFromFile();
            _figures.RemoveAt(index);
            WriteToFile();
        }
        public void DeleteAllFigures()
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
        public RectangularParallelepiped GetMinFrameParallelepiped(int index)
        {
            ReadFromFile();
            return _figures[index].GetMinParallelepiped();
        }
        public double TotalVolume()
        {
            ReadFromFile();
            double sumVolume = 0;
            foreach (var figure in _figures)
            {
                sumVolume += figure.GetVolume();
            }
            return sumVolume;
        }
        public double TotalVolumeWithLinq()
        {
            ReadFromFile();
            double sumVolumeLinq = _figures.Sum(figure => figure.GetVolume());
            return sumVolumeLinq;
        }
        public Figure3D GetFigure(int index)
        {
            ReadFromFile();
            return _figures[index];
        }
        public List<Figure3D> GetFigures()
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
