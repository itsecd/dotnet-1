using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace PromProg1
{
    public class DeleteAllCommand : Command<DeleteAllCommand.DeleteAllCommandSettings>
    {
        public class DeleteAllCommandSettings : CommandSettings
        {
        }

        private readonly IFigureRepository _figureRepository;

        public DeleteAllCommand(IFigureRepository figureRepository)
        {
            _figureRepository = figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] DeleteAllCommandSettings settings)
        {
            _figureRepository.OpenFile(_figureRepository.StorageFileName);
            _figureRepository.DeleteAll();
            _figureRepository.SaveFile(_figureRepository.StorageFileName);
            return 0;
        }
    }
}