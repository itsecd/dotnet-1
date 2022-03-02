using System.Collections.Generic;

namespace PromProg1
{
    public interface IFigureRepository
    {
        string StorageFileName { get; set; }
        List<Figure> _figures { get; set; }
        void AddRectangle(int index, Point FirstPoint, Point LastPoint);
        void AddCircle(int index, Point Center, double Radius);
        void AddTriangle(int index, Point A, Point B, Point C);
        void AddFigure(int index, Figure figure);
        int CompareSquare(int index1, int index2);
        int ComparePerimeter(int index1, int index2);
        void DeleteFigure(int index);
        void DeleteAll();
        void OpenFile(string path);
        void SaveFile(string path);
        double Summa();
        double SumSystemLinq();
        bool CheckIndex(int index);
    }
}