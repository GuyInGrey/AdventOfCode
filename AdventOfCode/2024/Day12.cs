using AdventOfCodeSupport;

using System.Runtime.ConstrainedExecution;

namespace AdventOfCode._2024;
public class Day12 : AdventBase
{
    protected override object InternalPart1()
    {
        var regions = new int[Input.Span2D.Height][];
        for (var y = 0; y < regions.Length; y++)
        {
            regions[y] = new int[Input.Span2D.Width];
        }
        var toSearch = new Stack<(int y, int x)>();

        var regionId = 0;
        for (var y = 0; y < regions.Length; y++)
        {
            for (var x = 0; x < regions[0].Length; x++)
            {
                if (regions[y][x] != 0)
                {
                    continue;
                }

                regionId++;
                toSearch.Clear();
                toSearch.Push((y, x));
                var c = Input.Span2D[y, x];
                regions[y][x] = regionId;

                while (toSearch.Count > 0)
                {
                    var top = toSearch.Pop();

                    if (top.x + 1 < regions[0].Length && Input.Span2D[top.y, top.x + 1] == c && regions[top.y][top.x + 1] == 0)
                    {
                        regions[top.y][top.x + 1] = regionId;
                        toSearch.Push((top.y, top.x + 1));
                    }
                    if (top.x - 1 >= 0 && Input.Span2D[top.y, top.x - 1] == c && regions[top.y][top.x - 1] == 0)
                    {
                        regions[top.y][top.x - 1] = regionId;
                        toSearch.Push((top.y, top.x - 1));
                    }
                    if (top.y + 1 < regions.Length && Input.Span2D[top.y + 1, top.x] == c && regions[top.y + 1][top.x] == 0)
                    {
                        regions[top.y + 1][top.x] = regionId;
                        toSearch.Push((top.y + 1, top.x));
                    }
                    if (top.y - 1 >= 0 && Input.Span2D[top.y - 1, top.x] == c && regions[top.y - 1][top.x] == 0)
                    {
                        regions[top.y - 1][top.x] = regionId;
                        toSearch.Push((top.y - 1, top.x));
                    }
                }
            }
        }

        long price = 0;
        for (var r = 1; r <= regionId; r++)
        {
            var per = 0;
            var area = 0;

            for (var y = 0; y < regions.Length; y++)
            {
                for (var x = 0; x < regions[y].Length; x++)
                {
                    if (regions[y][x] != r)
                    {
                        continue;
                    }

                    area++;
                    if (x == 0 || regions[y][x - 1] != r)
                    {
                        per++;
                    }
                    if (x == regions[y].Length - 1 || regions[y][x + 1] != r)
                    {
                        per++;
                    }
                    if (y == 0 || regions[y - 1][x] != r)
                    {
                        per++;
                    }
                    if (y == regions.Length - 1 || regions[y + 1][x] != r)
                    {
                        per++;
                    }
                }
            }
            Console.WriteLine($"Region {r} has a({area}) per({per}) -> {area * per}");
            price += per * area;
        }

        return price;
    }

    protected override object InternalPart2()
    {
        Console.Clear();
        var regions = new int[Input.Span2D.Height][];
        for (var y = 0; y < regions.Length; y++)
        {
            regions[y] = new int[Input.Span2D.Width];
        }
        var toSearch = new Stack<(int y, int x)>();

        var regionId = 0;
        for (var y = 0; y < regions.Length; y++)
        {
            for (var x = 0; x < regions[0].Length; x++)
            {
                if (regions[y][x] != 0)
                {
                    continue;
                }

                regionId++;
                toSearch.Clear();
                toSearch.Push((y, x));
                var c = Input.Span2D[y, x];
                regions[y][x] = regionId;

                while (toSearch.Count > 0)
                {
                    var top = toSearch.Pop();

                    if (top.x + 1 < regions[0].Length && Input.Span2D[top.y, top.x + 1] == c && regions[top.y][top.x + 1] == 0)
                    {
                        regions[top.y][top.x + 1] = regionId;
                        toSearch.Push((top.y, top.x + 1));
                    }
                    if (top.x - 1 >= 0 && Input.Span2D[top.y, top.x - 1] == c && regions[top.y][top.x - 1] == 0)
                    {
                        regions[top.y][top.x - 1] = regionId;
                        toSearch.Push((top.y, top.x - 1));
                    }
                    if (top.y + 1 < regions.Length && Input.Span2D[top.y + 1, top.x] == c && regions[top.y + 1][top.x] == 0)
                    {
                        regions[top.y + 1][top.x] = regionId;
                        toSearch.Push((top.y + 1, top.x));
                    }
                    if (top.y - 1 >= 0 && Input.Span2D[top.y - 1, top.x] == c && regions[top.y - 1][top.x] == 0)
                    {
                        regions[top.y - 1][top.x] = regionId;
                        toSearch.Push((top.y - 1, top.x));
                    }
                }
            }
        }

        long price = 0;

        var sides = new List<((int y, int x) left, (int y, int x) right, int side, int region)>();
        for (var r = 1; r <= regionId; r++)
        {
            void draw()
            {
                var mult = 3;
                for (var y = 0; y < regions.Length; y++)
                {
                    for (var x = 0; x < regions[y].Length; x++)
                    {
                        if (regions[y][x] == r)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        //for (var i = 0; i < sides.Count; i++)
                        //{
                        //    var s = sides[i];
                        //    if ((s.left.x == x && s.left.y == y) || (s.right.x == x && s.right.y == y))
                        //    {
                        //        Console.SetCursorPosition(s.side == 1 ? x * 4 + 2 : s.side == 3 ? x * 4 : x * 4 + 1, s.side == 2 ? y * 4 + 2 : s.side == 0 ? y * 4 : y * 4 + 1);
                        //        Console.BackgroundColor = (ConsoleColor)((i % 15) + 1);
                        //        Console.Write(" ");
                        //        Console.BackgroundColor = ConsoleColor.Black;
                        //    }
                        //}

                        Console.SetCursorPosition(x * mult + 1, y * mult + 1);
                        Console.Write((char)Input.Span2D[y, x]);
                    }
                }

                for (var i = 0; i < sides.Count; i++)
                {
                    var s = sides[i];
                    var y1 = s.left.y * mult + 1;
                    var y2 = s.right.y * mult + 1;
                    var x1 = s.left.x * mult + 1;
                    var x2 = s.right.x * mult + 1;

                    Console.BackgroundColor = (ConsoleColor)((i % 15) + 1);
                    for (var y = y1 + (s.side == 1 || s.side == 3 ? -1 : 0); y <= y2 + (s.side == 1 || s.side == 3 ? 1 : 0); y++)
                    {
                        for (var x = x1 + (s.side == 0 || s.side == 2 ? -1 : 0); x <= x2 + (s.side == 0 || s.side == 2 ? 1 : 0); x++)
                        {
                            Console.SetCursorPosition(x + (s.side == 1 ? 1 : s.side == 3 ? -1 : 0), y + (s.side == 2 ? 1 : s.side == 0 ? -1 : 0));
                            Console.Write(" ");
                        }
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(0, Input.Span2D.Height * mult + 1);

                Console.WriteLine();
                //Thread.Sleep(20);
            }

            var area = 0;

            for (var y = 0; y < regions.Length; y++)
            {
                for (var x = 0; x < regions[y].Length; x++)
                {
                    if (regions[y][x] != r)
                    {
                        continue;
                    }

                    area++;

                    if (x == 0 || regions[y][x - 1] != r)
                    {
                        sides.Add(((y, x), (y, x), 3, r));
                    }
                    if (x == regions[y].Length - 1 || regions[y][x + 1] != r)
                    {
                        sides.Add(((y, x), (y, x), 1, r));
                    }
                    if (y == 0 || regions[y - 1][x] != r)
                    {
                        sides.Add(((y, x), (y, x), 0, r));
                    }
                    if (y == regions.Length - 1 || regions[y + 1][x] != r)
                    {
                        sides.Add(((y, x), (y, x), 2, r));
                    }
                    draw();
                }
            }

            start:;


            draw();

            for (var i = 0; i < sides.Count; i++)
            {
                for (var j = 0; j < sides.Count; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }

                    var side = sides[i];
                    var side2 = sides[j];

                    if (side.side != side2.side || side.region != r || side2.region != r)
                    {
                        continue;
                    }
                    var dir = side.side;

                    if ((dir == 0 || dir == 2) && side.left.y != side2.left.y)
                    {
                        continue;
                    }
                    else if ((dir == 1 || dir == 3) && side.left.x != side2.left.x)
                    {
                        continue;
                    }

                    if ((dir == 0 || dir == 2) && (side.left.x == side2.right.x + 1 || side.right.x + 1 == side2.left.x))
                    {
                        sides[i] = ((side.left.y, Math.Min(side.left.x, Math.Min(side.right.x, Math.Min(side2.left.x, side2.right.x)))), (side.left.y, Math.Max(side.left.x, Math.Max(side.right.x, Math.Max(side2.left.x, side2.right.x)))), dir, r);
                        sides.RemoveAt(j);
                        goto start;
                    }
                    else if ((dir == 1 || dir == 3) && (side.left.y == side2.right.y + 1 || side.right.y + 1 == side2.left.y))
                    {
                        sides[i] = ((Math.Min(side.left.y, Math.Min(side.right.y, Math.Min(side2.left.y, side2.right.y))), side.left.x), (Math.Max(side.left.y, Math.Max(side.right.y, Math.Max(side2.left.y, side2.right.y))), side.left.x), dir, r);
                        sides.RemoveAt(j);
                        goto start;
                    }
                }
            }
            //draw();

            //Console.WriteLine($"Region {r} has a({area}) sides({sides.Count}) -> {area * sides.Count}");
            price += sides.Where(s => s.region == r).Count() * area;
        }

        return price;
    }
}
