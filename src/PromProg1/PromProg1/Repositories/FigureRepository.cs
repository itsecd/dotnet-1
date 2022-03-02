using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace PromProg1
{
    public class FigureRepository : IFigureRepository
    {
        public string StorageFileName { get; set; } = "figures.xml";
        public List<Figure> _figures { set; get; }
        public FigureRepository(){}
        public FigureRepository(List<Figure> figures)
        {
            _figures = figures;
        }
        public void AddRectangle(int index, Point FirstPoint, Point LastPoint)
        {
            AddFigure(index, new Rectangle(FirstPoint, LastPoint));
        }

        public void AddCircle(int index, Point Center, double Radius)
        {
            AddFigure(index, new Circle(Center, Radius));
        }

        public void AddTriangle(int index, Point A, Point B, Point C)
        {
            AddFigure(index, new Triangle(A, B, C));
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
            if (_figures[index1].Square() > _figures[index2].Square())
            {
                return index1;
            }
            return index2;
        }

        public int ComparePerimeter(int index1, int index2)
        {
            if (_figures[index1].Perimeter() > _figures[index2].Perimeter())
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
            if (_figures != null) return;

            if (!File.Exists(StorageFileName))
            {
                _figures = new List<Figure>();
                return;
            }
            try
            {
                XmlSerializer formatter = new (typeof(List<Figure>));
                FileStream stream = new (path, FileMode.OpenOrCreate);
                _figures = (List<Figure>)formatter.Deserialize(stream);
                stream.Close();
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
                XmlSerializer formatter = new (typeof(List<Figure>));
                FileStream stream = new (path, FileMode.OpenOrCreate);
                formatter.Serialize(stream, _figures);
                stream.Close();
            }
            catch (Exception)
            {
                Console.Write("File don't save\n");
                Console.ReadLine();
            }

        }
        public double Summa()
        {
            double sum = 0;
            foreach (Figure figure in _figures)
            {
                sum += figure.Square();
            }
            return sum;
        }

        public double SumSystemLinq()
        {
            return _figures.Sum(f => f.Square());
        }

        public bool CheckIndex(int index)
        {
            if (_figures == null)
            {
                return false;
            }
            return (index < _figures.Count) && (index >= 0);
        }

    }
}