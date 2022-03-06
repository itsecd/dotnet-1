using Lab1.Model;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Lab1.Reposity
{
    public class FigureRepository : IFigureRepository
    {
        private const string FileName = "Data.xml";
        private List<Figure> figure;
        private void ReadFileXml()
        {
            if (!File.Exists(FileName))
            {
                figure = new List<Figure>();
            }
            var xmlSelializer = new XmlSerializer(typeof(List<Figure>));
            using var fileStream = new FileStream(FileName, FileMode.Open);
            figure = (List<Figure>)xmlSelializer.Deserialize(fileStream);
        }
        private void WriteFileXml()
        {
            var xmlSelializer = new XmlSerializer(typeof(List<Figure>));
            using var fileStream = new FileStream(FileName, FileMode.Create);
            xmlSelializer.Serialize(fileStream, figure);
        }
        public void AddFigure(Figure _figure)
        {
            if (_figure == null)
            {
                throw new ArgumentNullException(nameof(_figure));
            }
            ReadFileXml();
            figure.Add(_figure);
            WriteFileXml();
        }
        public void RemoveFigure(int index)
        {
            ReadFileXml();
            figure.RemoveAt(index);
            WriteFileXml();
        }
        public void ClearAllFigure()
        {
            ReadFileXml();
            figure.Clear();
            WriteFileXml();
        }
        public bool CompareFigure(int x, int y)
        {
            ReadFileXml();
            for(var i = 0; i < figure.Count; i++)
            {
                if(figure[x].GetType() == typeof(Rectangular) && figure[y].GetType() == typeof(Rectangular))
                {
                    return figure[x].Equals(figure[y]);
                }
                if (figure[x].GetType() == typeof(Globular) && figure[y].GetType() == typeof(Globular))
                {
                    return figure[x].Equals(figure[y]);
                }
                if (figure[x].GetType() == typeof(Cylinder) && figure[y].GetType() == typeof(Cylinder))
                {
                    return figure[x].Equals(figure[y]);
                }
            }
            return false;
        }
        public void PrintScreen()
        {
            ReadFileXml();
            var table = new Table();
            table.AddColumn("Type Figure");
            table.AddColumn("Coords");
            table.AddColumn("Area");
            table.AddColumn("volume");
            foreach (var elem in figure)
            {
                table.AddRow(elem.GetType().Name, elem.ToString(), elem.acreage().ToString(), elem.volume().ToString());
            }
            AnsiConsole.Write(table);
        }
    }
}
