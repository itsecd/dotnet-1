using System;
using Lab1;
using Xunit;
using Spectre.Console;

namespace Lab1Tests
{
    public class UnitTest1
    {
        [Fact]
        public void MatrixEqualityTest()
        {
            BufferedMatrix A = new BufferedMatrix(2, 2);
            BufferedMatrix B = new BufferedMatrix(2, 2);

            AnsiConsole.Write(new Markup("[bold]MatrixEquality[/] [yellow]==[/]\n"));
            Assert.True(A == B);
            AnsiConsole.Write(new Markup("[bold]MatrixEquality[/] [yellow]Equals()[/]\n"));
            Assert.True(A.Equals(B));
            A.Set(0, 0, 1.23);
            Assert.True(A != B);
        }

        [Fact]
        public void MatrixNormTest()
        {
            BufferedMatrix A = new BufferedMatrix(2, 2);
            A.Set(0, 0, 1);
            A.Set(0, 1, -2);
            AnsiConsole.Write(new Markup("[bold]MatrixNorm[/]\n"));
            Assert.Equal(2, A.Norm);
        }
    }
}
