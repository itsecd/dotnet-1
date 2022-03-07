using Lab1.Model;

namespace Lab1.Repositories
{
    public interface IFiguresRepository
    {
        void AddFigure(Figure figure);
        void RemoveFigure(int index);
        void DeleteAllFigure();
        void PrintScreen();
        bool CompareFigure(int x, int y);
        public double Sum();
        public double SumSystemLinq();
    }
}