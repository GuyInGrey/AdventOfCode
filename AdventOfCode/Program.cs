using AdventOfCodeSupport;

namespace AdventOfCode;

internal class Program
{
    static void Main()
    {
        while (true)
        {
            var days = new AdventSolutions();

            var i = 0;
            Console.WriteLine("Select a day, 'all' to benchmark all, empty for latest, or Control+C to exit:");
            foreach (var day in days)
            {
                Console.ForegroundColor = i % 2 == 0 ? ConsoleColor.Red : ConsoleColor.Green;
                Console.WriteLine($"{day.Year}-{day.Day}");
                Console.ForegroundColor = ConsoleColor.White;
                i++;
            }

            Console.Write("> ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            var input = Console.ReadLine()!.ToLower().Trim();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();

            

            if (input == "all")
            {
                days.BenchmarkAll();
                continue;
            }

            AdventBase? selected;
            if (input == "")
            {
                selected = days.GetMostRecentDay();
            }
            else
            {
                selected = days.FirstOrDefault(d => input == $"{d.Year}-{d.Day}");
            }

            if (selected is null)
            {
                Console.WriteLine("Your argument is invalid.");
                continue;
            }

            ProcessMethod(selected);
        }
    }

    static void ProcessMethod(AdventBase ab)
    {
        Console.WriteLine($"Day {ab.Year}-{ab.Day} selected.");

        ab.Part1().Part2();

        Console.WriteLine("Benchmark? (y/n)");
        Console.Write("> ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        var option = Console.ReadKey();
        Console.WriteLine("\n");
        Console.ForegroundColor = ConsoleColor.White;
        if (option.Key != ConsoleKey.Y)
        {
            return;
        }

        ab.Benchmark();
    }
}
