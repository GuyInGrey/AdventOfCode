using AdventOfCodeSupport;

namespace AdventOfCode2024._2024;
public class Day08 : AdventBase
{
    protected override object InternalPart1()
    {
        var positions = new List<int>[255];
        var flagged = new bool[2500];
        for (var i = 0; i < Input.Text.Length; i++)
        {
            if (i % 51 == 50 || Input.Text[i] == '.')
            {
                continue;
            }

            (positions[Input.Text[i]] ?? (positions[Input.Text[i]] = [])).Add((i / 51 * 50) + (i % 51));
        }

        foreach (var ele in positions)
        {
            if (ele is null)
            {
                continue;
            }
            foreach (var position in ele)
            {
                foreach (var position2 in ele)
                {
                    if (position == position2)
                    {
                        continue;
                    }

                    var antX = (position % 50) + (position % 50) - (position2 % 50);
                    var antY = (position / 50) + (position / 50) - (position2 / 50);

                    if (antX > -1 && antY > -1 && antX < 50 && antY < 50)
                    {
                        flagged[(antY * 50) + antX] = true;
                    }
                }
            }
        }

        var count = 0;
        for (var i = 0; i < flagged.Length; i++)
        {
            if (flagged[i])
            {
                count++;
            }
        }
        return count;
    }

    protected override object InternalPart2()
    {
        var dataWidth = 0;
        for (var i = 0; i < Input.Bytes.Length; i++)
        {
            if (Input.Bytes[i] == 10)
            {
                dataWidth = i + 1;
                break;
            }
        }

        var antennaPositions = new List<int>[255];
        var flagged = new bool[Input.Bytes.Length];
        for (var i = 0; i < Input.Bytes.Length; i++)
        {
            var c = Input.Bytes[i];
            if (i % dataWidth == dataWidth - 1 || c == 46)
            {
                continue;
            }

            flagged[i] = true;
            (antennaPositions[c] ?? (antennaPositions[c] = new(8))).Add(i);
        }

        foreach (var antennaTypes in antennaPositions)
        {
            if (antennaTypes is null)
            {
                continue;
            }
            foreach (var position in antennaTypes)
            {
                foreach (var position2 in antennaTypes)
                {
                    if (position == position2)
                    {
                        continue;
                    }

                    var x1 = position % dataWidth;
                    var y1 = position / dataWidth;

                    var xDiff = (position2 % dataWidth) - x1;
                    var yDiff = (position2 / dataWidth) - y1;

                    var antX = x1 - xDiff;
                    var antY = y1 - yDiff;

                    while (!(antX < 0 || antY < 0 || antX > 49 || antY > 49))
                    {
                        flagged[(antY * dataWidth) + antX] = true;
                        antX -= xDiff;
                        antY -= yDiff;
                    }
                }
            }
        }

        var count = 0;
        for (var i = 0; i < flagged.Length; i++)
        {
            if (i % dataWidth < dataWidth - 1 && flagged[i])
            {
                count++;
            }
        }
        return count;
    }
}
