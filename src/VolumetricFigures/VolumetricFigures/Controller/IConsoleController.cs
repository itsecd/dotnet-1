using System.Collections.Generic;
using VolumetricFigures.Model;
using VolumetricFigures.Model.Figures;

namespace VolumetricFigures.Controller
{
    public interface IConsoleController
    {
        string StorageFileName { get; set; }
        List<Figure> Figures { get; set; }
        void AddRectangularCuboid(int index, Point p1, Point p2);
        void AddSphere(int index, Point p, double radius);
        void AddCylinder(int index, Point p, double radius, double height);
        void AddFigure(int index, Figure figure);
        int CompareSquare(int index1, int index2);  
        int ComparePerimeter(int index1, int index2);
        void DeleteFigure(int index);
        void DeleteAll();
        void OpenFile(string path);
        void SaveFile(string path);
        double SumManual();
        double SumSystemLinq();
        bool CheckIndex(int index);
    }
}
