using Spectre.Console.Cli;
using System.Diagnostics.CodeAnalysis;

namespace PromProg1
{
    public class DeleteAllCommand : Command<DeleteAllCommand.DeleteAllCommandSettings>
    {
        public class DeleteAllCommandSettings : CommandSettings
        {
        }

        private readonly IFigureRepository figureRepository;

        public DeleteAllCommand(IFigureRepository _figureRepository)
        {
            figureRepository = _figureRepository;
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] DeleteAllCommandSettings settings)
        {
            figureRepository.OpenFile(figureRepository.StorageFileName);
            figureRepository.DeleteAll();              
            figureRepository.SaveFile(figureRepository.StorageFileName);
            return 0;
        }
    }
}