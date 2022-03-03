using System;
using System.Collections.Generic;
using Lab1.Mode;
using System.Linq;
using Spectre.Console;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Lab1.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Lab1.Infrastructure;
using Spectre.Console.Cli;
using Lab1.Commands;

namespace Lab1
{
    class Program
    {
        static double SumSquare(List<Figure> ls)
        {
            double Sum = 0;
            foreach (var p in ls)
            {
                Sum = Sum + p.Square();
            }
            return Sum;
        }
        static void Main(string[] args)
        {
            /*var Figure1 = new Tritangle(new Point(1,1), new Point(2,3), new Point(4,2));
            var Figure2 = new Rectangle(new Point(0, 0), new Point(2, 0), new Point(2, 2), new Point(0, 2));
            var Figure3 = new Circle(new Point(3, 3), 2);

            var xmlDocument = new XmlDocument();
            var rectangleElement = xmlDocument.CreateElement("Rectangle");
            var nameAttribute = xmlDocument.CreateAttribute("Name");
            nameAttribute.Value = "AAA";
            rectangleElement.Attributes.Append(nameAttribute);
            xmlDocument.AppendChild(rectangleElement);

            var x1Element = xmlDocument.CreateElement("X1");
            x1Element.InnerText = "1.1";
            rectangleElement.AppendChild(x1Element);

            xmlDocument.Save("1.xml");

            var xDoc = new XDocument();
            xDoc.Add(
                    new XElement("Rectangle",
                    new XAttribute("Name", "AAA"),
                    new XElement("X1", "1.1"))
                   );

            var name =
                    from elem in xDoc.Element("Rectangle").Elements("X1")
                    where elem.Value == "1.1"
                    select elem.Element("Rectangle").Attribute("Name");
            xDoc.Save("2.xml");

            var rect = new Rectangle
            {
                A = new Point(1,1),
                B = new Point(1,2),
                C = new Point(2,2),
                D = new Point(2,1),
            };
            var xmlSelization = new XmlSerializer(typeof(Figure));
            using (var fileStream = new FileStream("3.xml", FileMode.Create))
            {
                xmlSelization.Serialize(fileStream, Figure1);
            }
            using var readStream = new FileStream("3.xml", FileMode.Open);
            var figureFromXml = xmlSelization.Deserialize(readStream);*/
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IXmlFigureRepository, XmlFigureRepository>();

            var registrar = new TypeRegistrar(serviceCollection);
            var app = new CommandApp(registrar);

            app.Configure(config =>
            {
                config.AddCommand<AddFigureCommand>("add");
                config.AddCommand<OutputCommand>("output");
                config.AddCommand<RemoveFigureCommand>("remove_one");
                config.AddCommand<RemoveAllCommand>("remove_all");
                config.AddCommand<CompareCommand>("compare");
            });
            app.Run(args);
            //IXmlFigureRepository figureRepository = new XmlFigureRepository();

            //List < Figure > ls = new() { Figure1, Figure2, Figure3 };



            /*Console.WriteLine("Menu:");
            Console.WriteLine("\t1. Создание объекта.");
            Console.WriteLine("\t2. Удаление объекта по индексу.");
            Console.WriteLine("\t3. Удаление всех объектов.");
            Console.WriteLine("\t4. Сравнение двух объектов по индексам.");
            Console.WriteLine("\t5. Вывод контейнера на экран.");
            Console.WriteLine("ВВедите выбранное число от 1 до 5:");
            int Choice = int.Parse(Console.ReadLine());
            switch (Choice)
            {
                case 1:
                    var FigureType = AnsiConsole.Prompt(new SelectionPrompt<string>().Title("Выберите тип фигуры: ").AddChoices("Прямоугольник", "Треугольник", "Круг"));
                    Figure Creat = FigureType switch
                    {
                        "Прямоугольник" => new Rectangle(new Point(AnsiConsole.Prompt(new TextPrompt<double>("[red]Первая точка X = [/]")), 
                                                                AnsiConsole.Prompt(new TextPrompt<double>("[red]Первая точка Y = [/]"))),
                                                            new Point(AnsiConsole.Prompt(new TextPrompt<double>("[red]Вторая точка X = [/]")),
                                                                AnsiConsole.Prompt(new TextPrompt<double>("[red]Вторая точка Y = [/]"))),
                                                            new Point(AnsiConsole.Prompt(new TextPrompt<double>("[red]Третья точка X = [/]")),
                                                                AnsiConsole.Prompt(new TextPrompt<double>("[red]Третья точка Y = [/]"))),
                                                            new Point(AnsiConsole.Prompt(new TextPrompt<double>("[red]Четвертая точка X = [/]")),
                                                                AnsiConsole.Prompt(new TextPrompt<double>("[red]Четвертая точка Y = [/]")))),
                        "Треугольник" => new Tritangle(
                                                            new Point(AnsiConsole.Prompt(new TextPrompt<double>("[red]Первая точка X = [/]")),
                                                                AnsiConsole.Prompt(new TextPrompt<double>("[red]Первая точка Y = [/]"))),
                                                            new Point(AnsiConsole.Prompt(new TextPrompt<double>("[red]Вторая точка X = [/]")),
                                                                AnsiConsole.Prompt(new TextPrompt<double>("[red]Вторая точка Y = [/]"))),
                                                            new Point(AnsiConsole.Prompt(new TextPrompt<double>("[red]Третья точка X = [/]")),
                                                                AnsiConsole.Prompt(new TextPrompt<double>("[red]Третья точка Y = [/]")))),
                        "Круг" => new Circle(   new Point(AnsiConsole.Prompt(new TextPrompt<double>("[red]Центр X = [/]")),
                                                        AnsiConsole.Prompt(new TextPrompt<double>("[red]Центр Y = [/]"))),
                                                AnsiConsole.Prompt(new TextPrompt<double>("[red]Радиус = [/]"))),
                        _ => null
                    };
                    if(Creat == null)
                    {
                        AnsiConsole.MarkupLine($"[red]Неизвестный тип фигуры: {FigureType}[/]");
                    }
                    else
                    {
                        figureRepository.AddFigure(Creat);
                    }

                    /*var xmlSelization = new XmlSerializer(typeof(List<Figure>));
                    using (var fileStream = new FileStream("3.xml", FileMode.Create))
                    {
                        xmlSelization.Serialize(fileStream, ls);
                    }
                    break;
                case 2:
                    int index = AnsiConsole.Prompt(new TextPrompt<int>($"[blue]Вводите индекс фигура для удаления: [/]"));
                    figureRepository.RemoveFigure(index);
                    break;
                case 3:
                    AnsiConsole.Write("[orange]Контейнер удален.");
                    figureRepository.RemoveAllFigure();
                    break;
                case 4:
                    int id1 = AnsiConsole.Prompt(new TextPrompt<int>($"[blue]Выбирайте индекс первого фигура :[/]"));
                    int id2 = AnsiConsole.Prompt(new TextPrompt<int>($"[blue]Выбирайте индекс второго фигура (различен от {id1}):[/]"));
                    AnsiConsole.WriteLine($"Результат сравнения: {figureRepository.CompareFigures(id1, id2)}");
                    break;
                case 5:
                    figureRepository.OuputList();
                    break;
            }*/
        }
    }
}
