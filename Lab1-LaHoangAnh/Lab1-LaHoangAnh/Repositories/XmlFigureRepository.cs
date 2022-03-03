using Lab1.Mode;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab1.Repositories
{
    public class XmlFigureRepository : IXmlFigureRepository
    {
        private const string StorageFileName = "figure.xml";
        private List<Figure> _figures;
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
            using (var fileStream = new FileStream(StorageFileName, FileMode.Create))
            {
                xmlSerializer.Serialize(fileStream, _figures);
            }
        }

        public void AddFigure(Figure figure)
        {
            if (figure == null)
                throw new ArgumentNullException(nameof(figure));
            else
            {
                ReadFromFile();
                _figures.Add(figure);
                WriteToFile();
            }

        }

        public void RemoveFigure(int index)
        {
            ReadFromFile();
            if (index < 0 || index > _figures.Count - 1)
            {
                throw new IndexOutOfRangeException();
            }
            _figures.RemoveAt(index);
            WriteToFile();
        }

        public void RemoveAllFigure()
        {
            ReadFromFile();

            for (int i = 0; i < _figures.Count; i++)
            {
                _figures.RemoveAt(i);
            }
            WriteToFile();
        }

        public bool CompareFigures(int index1, int index2)
        {
            ReadFromFile();
            if (index1 < 0 || index2 < 0 || index1 >= _figures.Count || index2 >= _figures.Count)
            {
                throw new IndexOutOfRangeException();
            }
            else return _figures[index1].Equals(_figures[index2]);
        }

        public void OuputList()
        {
            ReadFromFile();
            foreach (var p in _figures)
            {
                AnsiConsole.WriteLine(p.ToString());
            }
        }

        public List<Figure> GetList()
        {
            ReadFromFile();
            return _figures;
        }
    }
}
