using System.Collections.Generic;

namespace PromLab01
{
    public interface IXmlFigureRepository
    {
        string StorageFileName { get; set; }
        List<Figure> Figures { get; set; }
        void AddRectangle(int index, Point firstPoint, Point lastPoint);
        void AddCircle(int index, Point centr, double radius);
        void AddTriangle(int index, Point a, Point b, Point c);
        void AddFigure(int index, Figure figure);
        int CompareArea(int index1, int index2);
        int ComparePerimeter(int index1, int index2);
        void DeleteFigure(int index);
        void DeleteAll();
        void OpenFile(string path);
        void SaveFile(string path);
        double TotalSum();
        double SumSystemLinq();
        bool CheckIndex(int index);
    }
}