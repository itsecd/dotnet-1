using Lab1.Mode;
using Lab1.Repositories;
using Spectre.Console.Cli;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1.Commands
{
    public class OutputCommand : Command<OutputCommand.OutputSettings>
    {
        public class OutputSettings : CommandSettings
        { }

        private readonly IXmlFigureRepository _figuresRepository;

        public OutputCommand(IXmlFigureRepository figureRepository)
        {
            _figuresRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] OutputSettings settings)
        {
            var figures = _figuresRepository.GetList();
            foreach (Figure f in figures)
            {
                Console.WriteLine(f.ToString());
            }
            return 0;
        }
    }
}
