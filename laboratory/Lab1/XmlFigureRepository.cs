using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Lab1
{
    public class XmlFigureRepository : IRepository
    {
        private List<Figure>? _figures;

        private const string _fileName = "figure.xml";

        public void Insert(int index, Figure obj)
        {
            Deserialize();
            if (index >= _figures?.Count)
            {
                _figures.Add(obj);
            }
            else
                _figures?.Insert(index, obj);
            Serialize(_figures!);
        }

        public void RemoveAt(int index)
        {
            Deserialize();
            _figures?.RemoveAt(index);
            Serialize(_figures!);
        }

        public void Clear()
        {
            _figures = Deserialize();
            _figures?.Clear();
            Serialize(_figures!);
        }

        private void Serialize(List<Figure> figuresList)
        {
            var xml = new XmlSerializer(typeof(List<Figure>));
            using var fileStream = new FileStream(_fileName, FileMode.Create);
            xml.Serialize(fileStream, figuresList);
        }

        private List<Figure> Deserialize()
        {
            if (!File.Exists(_fileName))
            {
                _figures = new List<Figure>();
                return _figures;
            }
            var xml = new XmlSerializer(typeof(List<Figure>));
            using var fileStream = File.OpenRead(_fileName);
            _figures = (List<Figure>?)xml.Deserialize(fileStream);
            return _figures!;
        }

        public List<Figure> GetAll()
        {
            _figures = Deserialize();
            return _figures;
        }
    }
}
