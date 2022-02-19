using VolumetricFigures.view;

namespace VolumetricFigures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleView view = new ConsoleView(args);
            view.Start();
        }
    }
}
