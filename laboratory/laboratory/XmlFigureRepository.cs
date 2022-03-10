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

        private string FileName = "figure.xml";

        public XmlFigureRepository()
        {
            Deserialize();
        }

        public int Count() => Figures.Count();

        public void Insert(int index, Figure obj)
        {
            if (index >= Figures.Count)
            {
                Figures.Add(obj);
            }
            else
                Figures.Insert(index, obj);
            Serialize();
        }

        public void RemoveAt(int index)
        {
            Figures.RemoveAt(index);
            Serialize();
        }

        public void Clear()
        {
            Figures.Clear();
            Serialize();
        }

        private void Serialize()
        {
            var xml = new XmlSerializer(typeof(List<Figure>));
            using (var filestream = new FileStream(FileName, FileMode.Create))
            {
                xml.Serialize(filestream, Figures);
            }
        }

        private void Deserialize()
        {
            if (!File.Exists(FileName)) return;
            var xml = new XmlSerializer(typeof(List<Figure>));
            using var filestream = File.OpenRead(FileName);
            Figures = (List<Figure>)xml.Deserialize(filestream);
        }

        public List<Figure> GetAll()
        {
            return this.Figures;
        }
    }
}
