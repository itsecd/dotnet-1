﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;

namespace PromProg1
{
    public class FigureRepository : IFigureRepository
    {
        public string StorageFileName { get; set; } = "figures.xml";
        public List<Figure> Figures { set; get; }
        public FigureRepository(){}
        public FigureRepository(List<Figure> figures)
        {
            Figures = figures;
        }
        public void AddRectangle(int index, Point firstPoint, Point lastPoint)
        {
            AddFigure(index, new Rectangle(firstPoint, lastPoint));
        }

        public void AddCircle(int index, Point centr, double radius)
        {
            AddFigure(index, new Circle(centr, radius));
        }

        public void AddTriangle(int index, Point a, Point b, Point c)
        {
            AddFigure(index, new Triangle(a, b, c));
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
            if (Figures[index1].Square() > Figures[index2].Square())
            {
                return index1;
            }
            return index2;
        }

        public int ComparePerimeter(int index1, int index2)
        {
            if (Figures[index1].Perimeter() > Figures[index2].Perimeter())
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
            if (Figures != null) return;

            if (!File.Exists(StorageFileName))
            {
                Figures = new List<Figure>();
                return;
            }
            try
            {
                XmlSerializer formatter = new (typeof(List<Figure>));
                FileStream stream = new (path, FileMode.OpenOrCreate);
                Figures = (List<Figure>)formatter.Deserialize(stream);
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
                formatter.Serialize(stream, Figures);
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
            foreach (Figure figure in Figures)
            {
                sum += figure.Square();
            }
            return sum;
        }

        public double SumSystemLinq()
        {
            return Figures.Sum(f => f.Square());
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