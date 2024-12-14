using AdventOfCodeSupport;

namespace AdventOfCode._2024;
public class Day04 : AdventBase
{
    protected override object InternalPart1()
    {
        var arr = Input.Text.Trim().Split('\n').Select(line => line.ToCharArray()).ToArray();

        var count = 0;
        for (var y = 0; y < arr.Length; y++)
        {
            for (var x = 0; x < arr[y].Length; x++)
            {
                if (arr[y][x] != 'X')
                {
                    continue;
                }

                // North
                if (y >= 3 && arr[y - 1][x] == 'M' && arr[y - 2][x] == 'A' && arr[y - 3][x] == 'S')
                { count++; }
                // Northeast
                if (y >= 3 && x <= arr[y].Length - 4 && arr[y - 1][x + 1] == 'M' && arr[y - 2][x + 2] == 'A' && arr[y - 3][x + 3] == 'S') { count++; }
                // East
                if (x <= arr[y].Length - 4 && arr[y][x + 1] == 'M' && arr[y][x + 2] == 'A' && arr[y][x + 3] == 'S')
                { count++; }
                // Southeast
                if (x <= arr[y].Length - 4 && y <= arr.Length - 4 && arr[y + 1][x + 1] == 'M' && arr[y + 2][x + 2] == 'A' && arr[y + 3][x + 3] == 'S')
                { count++; }
                // South
                if (y <= arr.Length - 4 && arr[y + 1][x] == 'M' && arr[y + 2][x] == 'A' && arr[y + 3][x] == 'S')
                { count++; }
                // Southwest
                if (x >= 3 && y <= arr.Length - 4 && arr[y + 1][x - 1] == 'M' && arr[y + 2][x - 2] == 'A' && arr[y + 3][x - 3] == 'S')
                { count++; }
                // West
                if (x >= 3 && arr[y][x - 1] == 'M' && arr[y][x - 2] == 'A' && arr[y][x - 3] == 'S')
                { count++; }
                // Northwest
                if (y >= 3 && x >= 3 && arr[y - 1][x - 1] == 'M' && arr[y - 2][x - 2] == 'A' && arr[y - 3][x - 3] == 'S')
                { count++; }
            }
        }

        return count;
    }

    protected override object InternalPart2()
    {
        var chars = Input.Bytes;
        var lineWidth = 0;
        for (var i = 0; i < chars.Length; i++)
        {
            if (chars[i] == '\n')
            {
                lineWidth = i + 1;
                break;
            }
        }
        var height = (chars.Length / lineWidth);

        var count = 0;
        for (var y = 1; y < height - 1; y++)
        {
            for (var x = 1; x < lineWidth - 2; x++)
            {
                if (chars[y * lineWidth + x] == 'A' &&
                    ((chars[(y - 1) * lineWidth + x - 1] == 'M' && chars[(y + 1) * lineWidth + x + 1] == 'S') || (chars[(y - 1) * lineWidth + x - 1] == 'S' && chars[(y + 1) * lineWidth + x + 1] == 'M')) &&
                    ((chars[(y - 1) * lineWidth + x + 1] == 'M' && chars[(y + 1) * lineWidth + x - 1] == 'S') || (chars[(y - 1) * lineWidth + x + 1] == 'S' && chars[(y + 1) * lineWidth + x - 1] == 'M')))
                {
                    count++;
                }
            }
        }

        return count;
    }
}
