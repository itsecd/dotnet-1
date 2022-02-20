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

        public List<Figure> Figures { get ; set; }

        public ConsoleController()
        {
            Figures = new List<Figure>();
        }

        public ConsoleController(List<Figure> figures)
        {
            Figures = figures;
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
            if (Figures.Count != index)
            {
                DeleteFigure(index);
            }
            Figures.Insert(index, figure);
        }

        public int CompareSquare(int index1, int index2)
        {
            if (Figures[index1].GetSquare() > Figures[index2].GetSquare())
            {
                return index1;
            }
            return index2;
        }

        public int ComparePerimeter(int index1, int index2)
        {
            if (Figures[index1].GetPerimeter() > Figures[index2].GetPerimeter())
            {
                return index1;
            }
            return index2;
        }

        public void DeleteFigure(int index)
        {
            if (CheckIndex(index))
            {
                Figures.RemoveAt(index);
            }
        }

        public void DeleteAll()
        {
            Figures.RemoveRange(0, Figures.Count);
        }

        public void OpenFile(string path)
        {
            try
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<Figure>));
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                Figures = (List<Figure>)formatter.Deserialize(fs);
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
                formatter.Serialize(fs, Figures);
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
            foreach (Figure figure in Figures)
            {
                sum += figure.GetSquare();
            }
            return sum;
        }

        public double SumSystemLinq()
        {
            return Figures.Sum(f => f.GetSquare());
        }

        public bool CheckIndex(int index)
        {
            if (Figures == null)
            {
                return false;
            }
            return (index < Figures.Count) && (index >= 0);
        }

       
    }
}
