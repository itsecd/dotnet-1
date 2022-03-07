using Spectre.Console;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using laboratory.model;

namespace laboratory
{
    public class XmlFigureRepository : IRepository
    {
        private List<Figure> Figures = new();

        public XmlFigureRepository()
        {
            Deserialize("figure.xml");
        }

        public int Count() => Figures.Count();

        public void Insert(int index, Figure obj)
        {
            if (index >= Figures.Count)
            {
                Figures.Add(obj);
                return;
            }
            if (index >= 0)
                Figures.Insert(index, obj);

        }

        public void RemoveAt(int index)
        {
            Figures.RemoveAt(index);
        }

        public void Clear()
        {
            Figures.Clear();
        }

        public void Serialize(string path)
        {
            var xml = new XmlSerializer(typeof(List<Figure>));
            using (var filestream = new FileStream(path, FileMode.Create))
            {
                xml.Serialize(filestream, Figures);
            }
        }

        public void Deserialize(string path)
        {
            if (!File.Exists(path)) return;
            var xml = new XmlSerializer(typeof(List<Figure>));
            using var filestream = File.OpenRead(path);
            Figures = (List<Figure>)xml.Deserialize(filestream);
        }

        public List<Figure> GetAll()
        {
            return this.Figures;
        }
    }
}
