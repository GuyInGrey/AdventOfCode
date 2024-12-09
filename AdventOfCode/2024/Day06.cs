using AdventOfCodeSupport;

namespace AdventOfCode2024._2024;
public class Day06 : AdventBase
{
    protected override object InternalPart1()
    {
        var direction = 0;

        var map = Input.Text.Split('\n').Select(row => row.ToCharArray()).ToArray();

        var gY = 0;
        var gX = 0;

        for (var y = 0; y < map.Length; y++)
        {
            for (var x = 0; x < map[y].Length; x++)
            {
                if (map[y][x] == '^')
                {
                    gX = x;
                    gY = y;
                }
            }
        }

        var visited = new bool[map.Length][];
        for (var i = 0; i < map.Length; i++)
        {
            visited[i] = new bool[map[0].Length];
        }

        while (true)
        {
            var xChange = direction == 0 ? 0 : direction == 1 ? 1 : direction == 2 ? 0 : direction == 3 ? -1 : throw new Exception();
            var yChange = direction == 0 ? -1 : direction == 1 ? 0 : direction == 2 ? 1 : direction == 3 ? 0 : throw new Exception();

            var nX = gX + xChange;
            var nY = gY + yChange;

            if (nX < 0 || nX >= map[0].Length || nY < 0 || nY >= map.Length)
            {
                break;
            }

            var c = map[nY][nX];
            if (c == '#')
            {
                direction = (direction + 1) % 4;
                continue;
            }

            gX = nX;
            gY = nY;
            visited[gY][gX] = true;
        }

        var visitedCount = 0;
        for (var y = 0; y < map.Length; y++)
        {
            for (var x = 0; x < map[y].Length; x++)
            {
                if (visited[y][x])
                {
                    visitedCount++;
                }
            }
        }
        return visitedCount;
    }

    protected override object InternalPart2()
    {
        var map = Input.Text.Trim().Split('\n').Select(row => row.ToCharArray()).ToArray();

        var loopObs = 0;

        for (var y = 0; y < map.Length; y++)
        {
            for (var x = 0; x < map[0].Length; x++)
            {
                if (map[y][x] == '^' || map[y][x] == '#')
                {
                    continue;
                }

                map[y][x] = '#';
                if (DoesLoop(map))
                {
                    loopObs++;
                }
                map[y][x] = '.';
            }
        }

        return loopObs;
    }

    private static bool DoesLoop(char[][] map)
    {
        var loops = false;
        var direction = 0;

        var gY = 0;
        var gX = 0;

        for (var y = 0; y < map.Length; y++)
        {
            for (var x = 0; x < map[y].Length; x++)
            {
                if (map[y][x] == '^')
                {
                    gX = x;
                    gY = y;
                }
            }
        }

        var visited = new int[map.Length][];
        for (var i = 0; i < map.Length; i++)
        {
            visited[i] = new int[map[0].Length];
            for (var j = 0; j < visited[i].Length; j++)
            {
                visited[i][j] = -1;
            }
        }

        while (true)
        {
            var xChange = direction == 0 ? 0 : direction == 1 ? 1 : direction == 2 ? 0 : direction == 3 ? -1 : throw new Exception();
            var yChange = direction == 0 ? -1 : direction == 1 ? 0 : direction == 2 ? 1 : direction == 3 ? 0 : throw new Exception();

            var nX = gX + xChange;
            var nY = gY + yChange;

            if (nX < 0 || nX >= map[0].Length || nY < 0 || nY >= map.Length)
            {
                break;
            }

            var c = map[nY][nX];
            if (c == '#')
            {
                direction = (direction + 1) % 4;
                continue;
            }

            gX = nX;
            gY = nY;
            if (direction == visited[gY][gX])
            {
                loops = true;
                break;
            }

            visited[gY][gX] = direction;
        }

        return loops;
    }
}
