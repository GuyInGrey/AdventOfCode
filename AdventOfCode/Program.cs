using AdventOfCodeSupport;

namespace AdventOfCode;

internal class Program
{
    static void Main(/*string[] args*/)
    {
        Console.WriteLine("Hello, World!");

        var solutions = new AdventSolutions();
        solutions.GetDay(2024, 8).Benchmark();
    }
}
