using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PromProg1
{
    public class FigureRepository : IFigureRepository
    {
        private const string StorageFileName = "figures.xml";
        private List<Figure> _figures { set; get; }
        public FigureRepository(){}
        public FigureRepository(List<Figure> figures)
        {
            _figures = figures;
        }
        public bool CheckIndex(int index)
        {
            if (_figures == null)
            {
                return false;
            }
            return (index < _figures.Count) && (index >= 0);
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
        }
        private void WriteToFile()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Figure>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Create);
            xmlSerializer.Serialize(fileStream, _figures);
        }
        public void AddFigure(Figure figure)
        {
            ReadFromFile();
            _figures.Add(figure);
            WriteToFile();
        }

    }
}