using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using VolumetricFigures.Model;
using VolumetricFigures.Model.Figures;

namespace VolumetricFigures.Controller
{
    public class ConsoleController : IConsoleController
    {

        private List<Figure> _figures;

        public List<Figure> Figures { get => _figures; set => _figures = value; }

        public ConsoleController()
        {
            _figures = new List<Figure>();
        }

        public ConsoleController(List<Figure> figures)
        {
            _figures = figures;
        }

        public void AddRectangularCuboid(int index, Point p1, Point p2)
        {
            AddFigure(index, new RectangularCuboid(p1, p2));
        }

        public void AddSphere(int index, Point p, double radius)
        {
            AddFigure(index, new Sphere(p, radius));
        }

        public void AddCylinder(int index, Point p, double radius, double height)
        {
            AddFigure(index, new Cylinder(p, radius, height));
        }

        public void AddFigure(int index, Figure figure)
        {
            if (_figures.Count != index)
            {
                DeleteFigure(index);
            }
            _figures.Insert(index, figure);
        }

        public int CompareSquare(int index1, int index2)
        {
            if (_figures[index1].GetSquare() > _figures[index2].GetSquare())
            {
                return index1;
            }
            return index2;
        }

        public int ComparePerimeter(int index1, int index2)
        {
            if (_figures[index1].GetPerimeter() > _figures[index2].GetPerimeter())
            {
                return index1;
            }
            return index2;
        }

        public void DeleteFigure(int index)
        {
            if (CheckIndex(index))
            {
                _figures.RemoveAt(index);
            }
        }

        public void DeleteAll()
        {
            _figures.RemoveRange(0, _figures.Count);
        }

        public void OpenFile(string path)
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Figure>));
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                _figures = (List<Figure>)formatter.Deserialize(fs);
            }
            catch (Exception)
            {
                Console.Write("File don't open\n");
                Console.ReadLine();
            }
        }

        public void SaveFile(string path)
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Figure>));
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                formatter.Serialize(fs, _figures);
            }
            catch (Exception)
            {
                Console.Write("File don't save\n");
                Console.ReadLine();
            }

        }

        public double SumManual()
        {
            double sum = 0;
            foreach (Figure figure in _figures)
            {
                sum += figure.GetSquare();
            }
            return sum;
        }

        public double SumSystemLinq()
        {
            return _figures.Sum(f => f.GetSquare());
        }

        public bool CheckIndex(int index)
        {
            return (index < _figures.Count) && (index >= 0);
        }

       
    }
}
