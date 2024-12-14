using AdventOfCodeSupport;

namespace AdventOfCode._2024;
public class Day13 : AdventBase
{
    protected override object InternalPart1()
    {
        long cost = 0;
        foreach (var machineText in Input.Blocks)
        {
            var aX = long.Parse(machineText.Lines[0].Split('X')[1].Split(',')[0].Substring(1));
            var aY = long.Parse(machineText.Lines[0].Split('Y')[1].Substring(1));
            var bX = long.Parse(machineText.Lines[1].Split('X')[1].Split(',')[0].Substring(1));
            var bY = long.Parse(machineText.Lines[1].Split('Y')[1].Substring(1));
            var pX = long.Parse(machineText.Lines[2].Split('X')[1].Split(',')[0].Substring(1));
            var pY = long.Parse(machineText.Lines[2].Split('Y')[1].Substring(1));

            for (var aP = 0; aP * aX <= pX && aP <= 100; aP++)
            {
                var bP = ((pX - (aP * aX)) / bX);
                if ((pX - (aP * aX) - (bP * bX)) == 0 && (pY - (aP * aY) - (bP * bY)) == 0 && bP <= 100)
                {
                    cost += (aP * 3) + ((pX - (aP * aX)) / bX);
                }
            }
        }
        return cost;
    }

    protected override object InternalPart2()
    {
        const long add = 10000000000000;

        long cost = 0;
        Parallel.ForEach(Input.Blocks, new ParallelOptions()
        {
            MaxDegreeOfParallelism = 320,
        }, machineText =>
        {
            var aX = long.Parse(machineText.Lines[0].Split('X')[1].Split(',')[0].Substring(1));
            var aY = long.Parse(machineText.Lines[0].Split('Y')[1].Substring(1));
            var bX = long.Parse(machineText.Lines[1].Split('X')[1].Split(',')[0].Substring(1));
            var bY = long.Parse(machineText.Lines[1].Split('Y')[1].Substring(1));
            var pX = long.Parse(machineText.Lines[2].Split('X')[1].Split(',')[0].Substring(1)) + add;
            var pY = long.Parse(machineText.Lines[2].Split('Y')[1].Substring(1)) + add;

            for (long aP = 0; aP * aX <= pX; aP++)
            {
                var bP = ((pX - (aP * aX)) / bX);
                if ((pX - (aP * aX) - (bP * bX)) == 0 && (pY - (aP * aY) - (bP * bY)) == 0)
                {
                    var added = (aP * 3) + ((pX - (aP * aX)) / bX);
                    cost += added;
                    Console.WriteLine($"Found solution: {added} -> {cost}");
                    return;
                }
            }

            Console.WriteLine($"No solution: {cost}");
        });
        return cost;
    }
}
