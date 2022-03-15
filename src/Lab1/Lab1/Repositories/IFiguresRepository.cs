using Lab1.Model;
using System.Collections.Generic;

namespace Lab1.Repositories
{
    internal interface IFiguresRepository
    {
        void AddFigure(Figure figure, int index);
        void RemoveFigure(int index);
        void RemoveAllFigures();
        bool CompareFigures(int firstIndex, int secondIndex);
        Rectangle GetMinRectangle(int index);
        double SumArea();
        double SumAreaLinq();
        Figure GetFigure(int index);
        List<Figure> GetFigures();
        int GetCountFigures();
    }
}
