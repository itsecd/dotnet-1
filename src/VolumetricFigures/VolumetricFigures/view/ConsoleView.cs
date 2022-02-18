using Spectre.Console;
using System;
using System.Linq;
using VolumetricFigures.Controller;
using VolumetricFigures.Model;
using VolumetricFigures.Model.Figures;

namespace VolumetricFigures.view
{
    public class ConsoleView
    {
        private ConsoleController _controller;

        public ConsoleView(ConsoleController controller)
        {
            _controller = controller;
        }

        public void Run()
        {
            while (true)
            {
                var action = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("What to do?")
                    .AddChoices("Add", "Compare", "Delete","Sort", "Sum All Square", "Save/Open", "View Table"));
                switch(action)
                {
                    case "Add":
                        var add = AnsiConsole.Prompt(new SelectionPrompt<string>()
                            .Title("What to add?")
                            .AddChoices("Rectangular Cuboid", "Sphere", "Cylinder"));
                        int indexAdd = AnsiConsole.Prompt(new TextPrompt<int>(" Index :"));
                        if (_controller.CheckIndex(indexAdd) || indexAdd == _controller.Figures.Count)
                        {
                            switch (add)
                            {
                                case "Rectangular Cuboid":
                                    _controller.AddRectangularCuboid(
                                        indexAdd,
                                        InputPointCoordinate(),
                                        InputPointCoordinate());
                                    break;
                                case "Sphere":
                                    _controller.AddSphere(
                                        indexAdd,
                                        InputPointCoordinate(),
                                        AnsiConsole.Prompt(new TextPrompt<double>("Radius :")));
                                    break;
                                case "Cylinder":
                                    _controller.AddCylinder(
                                        indexAdd,
                                        InputPointCoordinate(),
                                        AnsiConsole.Prompt(new TextPrompt<double>("Radius :")),
                                        AnsiConsole.Prompt(new TextPrompt<double>("Height :")));
                                    break;
                            };
                        }
                        else
                        {
                            AnsiConsole.Write("Index Error");
                            Console.ReadLine();
                        }
                        break;
                    case "Compare":
                        int index1 = AnsiConsole.Prompt(new TextPrompt<int>(" Index 1:"));
                        int index2 = AnsiConsole.Prompt(new TextPrompt<int>(" Index 2:"));
                        if (_controller.CheckIndex(index1) && _controller.CheckIndex(index2))
                        {
                            Table tableEquals = new Table();
                            tableEquals.AddColumns("Index", "Type", "Info", "Square", "Perimeter", "Min.Cuboid");
                            tableEquals = AddRowToTable(tableEquals, index1, _controller.Figures[index1]);
                            tableEquals = AddRowToTable(tableEquals, index2, _controller.Figures[index2]);
                            AnsiConsole.Write(tableEquals);
                            AnsiConsole.Write("\nSquare biggest in element by index " + _controller.CompareSquare(index1, index2));
                            AnsiConsole.Write("\nPerimeter biggest in element by index " + _controller.ComparePerimeter(index1, index2));
                            Console.ReadLine();
                        }
                        else
                        {
                            AnsiConsole.Write("Index Error");
                            Console.ReadLine();
                        }
                        break;
                    case "Delete":
                        var delete = AnsiConsole.Prompt(new SelectionPrompt<string>()
                            .Title("What to delete?")
                            .AddChoices("Delete Item", "Delete All"));
                        switch (delete)
                        {
                            case "Delete Item":
                                _controller.DeleteFigure(AnsiConsole.Prompt(new TextPrompt<int>("Delete Index :")));
                                break;
                            case "Delete All":
                                _controller.DeleteAll();
                                break;
                        };
                        break;
                    case "Sort":
                        var sort = AnsiConsole.Prompt(new SelectionPrompt<string>()
                            .Title("What to sort?")
                            .AddChoices("Square", "Perimeter"));
                        switch (sort)
                        {
                            case "Square":
                                _controller.Figures.Sort((figure1, figure2) =>
                                    figure1.GetSquare().CompareTo(figure2.GetSquare()));
                                break;
                            case "Perimeter":
                                _controller.Figures.Sort((figure1, figure2) =>
                                    figure1.GetPerimeter().CompareTo(figure2.GetPerimeter()));
                                break;
                        };
                        break;
                    case "Sum All Square":
                        AnsiConsole.Write("Sum manual mode:\n");
                        AnsiConsole.Write(_controller.SumManual());
                        AnsiConsole.Write("\nSum System.Linq mode:\n");
                        AnsiConsole.Write(_controller.SumSystemLinq());
                        Console.ReadLine();
                        break;
                    case "Save/Open":
                        var saveOpen = AnsiConsole.Prompt(new SelectionPrompt<string>()
                            .Title("What to do?")
                            .AddChoices("Save", "Open"));
                        switch (saveOpen)
                        {
                            case "Save":
                                AnsiConsole.Write("Path to Save file:\n");
                                string pathSave = Console.ReadLine();
                                _controller.SaveFile(pathSave);
                                break;
                            case "Open":
                                AnsiConsole.Write("Path to Open file:\n");
                                string pathOpen = Console.ReadLine();
                                _controller.OpenFile(pathOpen);
                                break;
                        };
                        break;
                    case "View Table":
                        Table table = new Table();
                        table.AddColumns("Index", "Type", "Info", "Square", "Perimeter", "Min.Cuboid");
                        for(int indexTable = 0; indexTable < _controller.Figures.Count; indexTable++)
                        {
                            if (indexTable > 10)
                            {
                                table.AddRow("...", "...", "...", "...", "...", "...");
                                break;
                            }
                            table = AddRowToTable(table, indexTable, _controller.Figures[indexTable]);
                            AnsiConsole.WriteLine();
                        }
                        AnsiConsole.Write(table);
                        Console.ReadLine();
                        break;
                    };
                AnsiConsole.Clear();
            }
        }

        private Table AddRowToTable(Table table, int index, Figure figure)
        {
            table.AddRow(new Markup(index.ToString()),
                new Markup(figure.GetType().Name),
                new Markup("[red]" + figure + "[/]"),
                new Markup("[blue]" + figure.GetSquare() + "[/]"),
                new Markup("[blue]" + figure.GetPerimeter() + "[/]"),
                new Panel("[green]Сuboid: [/]\n" + figure.GetMinCuboid()));
            return table;
        }

        private Point InputPointCoordinate()
        {
            return new Point(
                AnsiConsole.Prompt(new TextPrompt<double>("Coordinate X:")),
                AnsiConsole.Prompt(new TextPrompt<double>("Coordinate Y:")),
                AnsiConsole.Prompt(new TextPrompt<double>("Coordinate Z:")));
        }
    }
}
