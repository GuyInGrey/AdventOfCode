using AdventOfCodeSupport;

namespace AdventOfCode2024._2024;
public class Day01 : AdventBase
{
    protected override object InternalPart1()
    {
        var list1 = new List<int>();
        var list2 = new List<int>();

        foreach (var line in Input.Text.Split('\n'))
        {
            if (line.Trim() == string.Empty)
            {
                continue;
            }
            var parts = line.Split(' ');

            list1.Add(int.Parse(parts[0]));
            list2.Add(int.Parse(parts[3]));
        }

        list1.Sort();
        list2.Sort();

        var totalDistance = 0;
        for (var i = 0; i < list1.Count; i++)
        {
            totalDistance += Math.Abs(list1[i] - list2[i]);
        }
        return totalDistance;
    }

    protected override object InternalPart2()
    {
        var list1 = new List<int>();
        var list2 = new List<int>();

        foreach (var line in Input.Text.Split('\n'))
        {
            if (line.Trim() == string.Empty)
            {
                continue;
            }
            var parts = line.Split(' ');

            list1.Add(int.Parse(parts[0]));
            list2.Add(int.Parse(parts[3]));
        }

        var counts = list2.GroupBy(l => l).Select(l => (l.Key, l.Count())).ToDictionary(l => l.Key, l => l.Item2);

        return list1.Select(num => num * (counts.TryGetValue(num, out var value) ? value : 0)).Sum();
    }
}
