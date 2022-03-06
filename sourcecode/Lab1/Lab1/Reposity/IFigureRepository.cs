using Lab1.Model;

namespace Lab1.Reposity
{
    public interface IFigureRepository
    {
        void AddFigure(Figure _figure);
        void ClearAllFigure();
        bool CompareFigure(int x, int y);
        void PrintScreen();
        void RemoveFigure(int index);
    }
}