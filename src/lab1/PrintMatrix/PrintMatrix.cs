using lab1.Model;
using Spectre.Console;
using System.Text;

namespace lab1.PrintMatrix
{
    public class PrintMatrix
    {
        static public void Print(IMatrix matrix)
        {
            for (var i = 0; i < matrix.Height; ++i)
            {
                for (var j = 0; j < matrix.Width; ++j)
                {
                    var val = matrix.GetValue(i, j);
                    var sb = new StringBuilder();
                    if (val < 0)
                        sb.Append($"[red]");
                    if (val == 0)
                        sb.Append($"[white]");
                    if (val > 0)
                        sb.Append($"[green]");

                    sb.Append($"{val:f1}[/]  ");
                    AnsiConsole.Write(new Markup(sb.ToString()));
                }
                AnsiConsole.WriteLine();
            }
        }
    }
}
