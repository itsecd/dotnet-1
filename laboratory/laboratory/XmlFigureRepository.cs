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
            if (index >= _figures!.Count)
            {
                _figures!.Add(obj);
            }
            else
                _figures!.Insert(index, obj);
            Serialize();
        }

        public void RemoveAt(int index)
        {
            Deserialize();
            _figures!.RemoveAt(index);
            Serialize();
        }

        public void Clear()
        {
            Deserialize();
            _figures!.Clear();
            Serialize();
        }

        private void Serialize()
        {
            var xml = new XmlSerializer(typeof(List<Figure>));
            using var fileStream = new FileStream(_fileName, FileMode.Create);
            xml.Serialize(fileStream, _figures);
        }

        private void Deserialize()
        {
            if (_figures != null) return;

            if (!File.Exists(_fileName))
            {
                _figures = new List<Figure>();
                return;
            }
            var xml = new XmlSerializer(typeof(List<Figure>));
            using var fileStream = File.OpenRead(_fileName);
            _figures = (List<Figure>?)xml.Deserialize(fileStream);
        }

        public List<Figure> GetAll()
        {
            Deserialize();
            return _figures!;
        }
    }
}
