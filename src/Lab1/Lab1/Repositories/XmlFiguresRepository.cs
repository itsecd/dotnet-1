using Lab1.Model;
using Lab1.Shapes;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Lab1.Repositories
{
    public class XmlFiguresRepository : IFiguresRepository
    {

        private string StorageFileName { get; set; } = "figure.xml";

        public List<Figure> _figuresList { get; set; }

        public  void ReadFile()
        {
            if (_figuresList != null) return;

            if (!File.Exists(StorageFileName))
            {
                _figuresList = new List<Figure>();
                return;
            }

            var xmlSerializer = new XmlSerializer(typeof(List<Figure>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Open);
            _figuresList = (List<Figure>)xmlSerializer.Deserialize(fileStream);
        }



        public void WriteFile()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Figure>));
            using var fileStream = new FileStream(StorageFileName, FileMode.Create);
            xmlSerializer.Serialize(fileStream, _figuresList);

        }
        public void AddFigure(Figure figure)
        {
            if (figure == null)
                throw new ArgumentNullException(nameof(figure));
            ReadFile();
            _figuresList.Add(figure);
            WriteFile();
        }
        public void RemoveFigure(int index)
        {

            ReadFile();
            _figuresList.RemoveAt(index);
            WriteFile();
        }

        public void DeleteAllFigure()
        {
            ReadFile();
            _figuresList.Clear();
            WriteFile();
        }

        public bool CompareFigure(int x, int y)
        {
            ReadFile();

            for (var i = 0; i < _figuresList.Count; i++)
            {
                if (_figuresList[x].GetType() == typeof(RectangularParallelepiped) && _figuresList[y].GetType() == typeof(RectangularParallelepiped))
                {
                    return _figuresList[x].Equals(_figuresList[y]);
                }
                if (_figuresList[x].GetType() == typeof(Ball) && _figuresList[y].GetType() == typeof(Ball))
                {
                    return _figuresList[x].Equals(_figuresList[y]);
                }
                if (_figuresList[x].GetType() == typeof(Cylinder) && _figuresList[y].GetType() == typeof(Cylinder))
                {
                    return _figuresList[x].Equals(_figuresList[y]);
                }
            }
            return false;
        }

        public double Sum()
        {
            ReadFile();
            double sum = 0;
            foreach (Figure figure in _figuresList)
            {
                sum += figure.GetVolume();
            }
            return sum;
        }

        public double SumSystemLinq()
        {
            ReadFile();
            return _figuresList.Sum(f => f.GetVolume());
        }

    }
}
