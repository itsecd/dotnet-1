using Lab1.Model;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Lab1.Repositories
{
    public class XmlFiguresRepository : IXmlFiguresRepository
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

        public void AddFigure(Figure figure)
        {
            if (figure == null)
                throw new ArgumentNullException();

            ReadFromFile();
            _figures.Add(figure);
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

        public void PrintFigures()
        {
            var table = new Table();

            table.AddColumn("Type");
            table.AddColumn("Coords");
            table.AddColumn("Perimeter");
            table.AddColumn("Area");
            table.AddColumn("MinFramingRectangle");

            int count = 0;
            foreach (Figure figure in _figures)
            {
                if (count == 10)
                {
                    table.AddRow("...");
                    break;
                }

                table.AddRow(figure.GetType().Name, figure.ToString(), figure.GetPerimeter().ToString(),
                    figure.GetArea().ToString(), figure.GetMinFramingRectangle().ToString());
                ++count;
            }
            AnsiConsole.Write(table);
        }
    }
}
