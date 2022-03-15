using Lab1.Model;
using System.Collections.Generic;

namespace Lab1.Repositories
{
    public interface IFiguresRepository
    {
        void AddFigure(int index, Figure figure);
        void DeleteFigures();
        List<Figure> GetFigures();
        void RemoveFigure(int index);
        double GetTotalAreaManually();
        double GetTotalAreaLinq();
    }
}