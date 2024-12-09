using AdventOfCodeSupport;

namespace AdventOfCode;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var solutions = new AdventSolutions();
        var day = solutions.GetDay(2024, 08);
        day.Benchmark();
    }
}
