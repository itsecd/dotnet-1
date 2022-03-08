using Lab1.Model;
using System.Collections.Generic;

namespace Lab1.Repository
{
    public interface IFigureRepository
    {
        void AddFigure(Figure _figure);
        void ClearAllFigure();
        void RemoveFigure(int index);
        List<Figure> getFigure();
    }
}