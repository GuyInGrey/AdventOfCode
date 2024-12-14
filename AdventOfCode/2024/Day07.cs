using AdventOfCodeSupport;

namespace AdventOfCode._2024;
public class Day07 : AdventBase
{
    protected override object InternalPart1()
    {
        var lines = Input.Text.Trim().Split('\n');

        var eqs = new List<(long, List<long>)>();
        foreach (var line in lines)
        {
            eqs.Add((long.Parse(line.Split(':')[0]), line.Split(':')[1].Trim().Split(' ').Select(long.Parse).ToList()));
        }

        long works = 0;

        foreach (var eq in eqs)
        {
            works += SearchRecurse(eq.Item2, eq.Item1, []) ? eq.Item1 : 0;
        }

        return works;
    }

    private static bool SearchRecurse(List<long> vals, long total, List<bool> ops)
    {
        if (ops.Count == vals.Count - 1)
        {
            var res = vals[0];
            for (var i = 1; i < vals.Count; i++)
            {
                res = ops[i - 1] ? res + vals[i] : res * vals[i];
            }
            return res == total;
        }

        var v1 = SearchRecurse(vals, total, [.. ops, false]);
        var v2 = SearchRecurse(vals, total, [.. ops, true]);

        return v1 || v2;
    }
    protected override object InternalPart2()
    {
        var totals = new List<long>(1000);
        var values = new List<long[]>(1000);
        var rowIndex = 0;
        var valIndex = -1;
        foreach (var c in Input.Bytes)
        {
            if (c == '\n')
            {
                rowIndex++;
                valIndex = -1;
                continue;
            }
            else if (c == ' ')
            {
                valIndex++;
                continue;
            }
            else if (c == ':')
            {
                continue;
            }
            else if (valIndex == -1)
            {
                if (totals.Count == rowIndex)
                {
                    totals.Add(0);
                    values.Add(new long[15]);
                }
                totals[rowIndex] = (totals[rowIndex] * 10) + (c - '0');
            }
            else
            {
                var row = values[rowIndex];
                row[valIndex] = (row[valIndex] * 10) + (c - '0');
            }
        }

        long finalTotal = 0;

        var opStack = new int[20];
        var valStack = new long[20];

        for (var i = 0; i < totals.Count; i++)
        {
            var vals = values[i];
            var target = totals[i];

            valStack[0] = vals[0] + vals[1];
            opStack[0] = 0;
            var stackSize = 1;

            var endReached = false;
            while (stackSize > 0)
            {
                var topVal = valStack[stackSize - 1];
                var topOp = opStack[stackSize - 1];

                if (stackSize < vals.Length - 1)
                {
                    var next = vals[stackSize + 1];
                    if (next == 0)
                    {
                        break;
                    }
                    valStack[stackSize] = topVal + next;
                    opStack[stackSize] = 0;
                    stackSize++;
                    continue;
                }

                if (topVal == target)
                {
                    finalTotal += target;
                    break;
                }

                while ((opStack[stackSize - 1] = ++topOp) == 3)
                {
                    if (stackSize == 1)
                    {
                        endReached = true;
                        break;
                    }
                    stackSize--;
                    topOp = opStack[stackSize - 1];
                }
                if (endReached)
                {
                    break;
                }

                var previous = stackSize == 1 ? vals[0] : valStack[stackSize - 2];
                if (topOp == 1)
                {
                    valStack[stackSize - 1] = previous * vals[stackSize];
                }
                else if (topOp == 2)
                {
                    long multiplier = 1;
                    var after = vals[stackSize];
                    while (multiplier <= after)
                    {
                        multiplier *= 10;
                    }
                    valStack[stackSize - 1] = (previous * multiplier) + after;
                }
            }
        }

        return finalTotal;
    }
}
