using Spectre.Console;
using Spectre.Console.Cli;
using System;
using System.Diagnostics.CodeAnalysis;
using VolumetricFigures.Controller;

namespace VolumetricFigures.View.Commands
{
    public class SumSquareCommand : Command<SumSquareCommand.SumSquareCommandSettings>
    {
        public class SumSquareCommandSettings : CommandSettings
        {
        }

        private readonly IConsoleController _controller;

        public SumSquareCommand(IConsoleController controller)
        {
            _controller = controller;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] SumSquareCommandSettings settings)
        {
            AnsiConsole.Write("Sum manual mode:\n");
            AnsiConsole.Write(_controller.SumManual());
            AnsiConsole.Write("\nSum System.Linq mode:\n");
            AnsiConsole.Write(_controller.SumSystemLinq());
            Console.ReadLine();
            return 0;
        }
    }
}
