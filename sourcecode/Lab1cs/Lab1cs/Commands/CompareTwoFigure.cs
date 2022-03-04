using Lab1cs.Reposity;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Lab1cs.Commands
{
    public class CompareTwoFigure : Command<CompareTwoFigure.CompareFigureCommand>
    {
        public class CompareFigureCommand : CommandSettings
        {

        }
        private readonly IFigureRepository _figureRepository;
        public CompareTwoFigure(IFigureRepository figureRepo)
        {
            _figureRepository = figureRepo;
        }
        public override int Execute([NotNull] CommandContext context, [NotNull] CompareFigureCommand settings)
        {
            Console.Write("Index 1: ");
            var x = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Index 2: ");
            var y = int.Parse(Console.ReadLine());
            bool z = _figureRepository.CompareFigure(x, y);
            if (z == true) Console.WriteLine("Figure in index 1 = Figure in index 2 ");
            else Console.WriteLine("Figure in index 1 != Figure in index 2");
            return 0;
        }
    }
}
