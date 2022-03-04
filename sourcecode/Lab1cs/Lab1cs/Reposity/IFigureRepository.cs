using Lab1cs.Model;

namespace Lab1cs.Reposity
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