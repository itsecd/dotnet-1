using Lab1.Model;
using System.Collections.Generic;

namespace Lab1.Repositories
{
    public interface IFiguresRepository
    {
        void ReadFile();
        void WriteFile();
        void AddFigure(Figure figure);
        void RemoveFigure(int index);
        void DeleteAllFigure();
        bool CompareFigure(int x, int y);
        public double Sum();
        public double SumSystemLinq();
        List<Figure> _figuresList { get; set; }

    }
}