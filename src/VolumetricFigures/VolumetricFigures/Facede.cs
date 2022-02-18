using System.Collections.Generic;
using VolumetricFigures.Controller;
using VolumetricFigures.Model;
using VolumetricFigures.view;

namespace VolumetricFigures
{
    public class Faсade
    {
        private ConsoleController _controller;

        public Faсade()
        {
            List<Figure> _figures = new List<Figure>();
            _controller = new ConsoleController(_figures);
        }

        public void Start()
        {
            ConsoleView view = new ConsoleView(_controller);
            view.Run();
        }
    }
}
