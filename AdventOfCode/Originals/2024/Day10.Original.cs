//using AdventOfCodeSupport;

//using CommunityToolkit.HighPerformance;

//namespace AdventOfCode2024._2024;
//public class Daya10 : AdventBase
//{
//    protected override object InternalPart1()
//    {
//        var trailHeads = new List<(int y, int x)>();

//        for (var y = 0; y < Input.Span2D.Height; y++)
//        {
//            for (var x = 0; x < Input.Span2D.Width; x++)
//            {
//                if (Input.Span2D[y, x] == '0')
//                {
//                    trailHeads.Add((y, x));
//                }
//            }
//        }

//        var score = 0;
//        foreach (var t in trailHeads)
//        {
//            var reachable = new bool[Input.Span2D.Width, Input.Span2D.Height];
//            GetScore(Input.Span2D, t.y, t.x, ref reachable);
//            for (var y = 0; y < Input.Span2D.Height; y++)
//            {
//                for (var x = 0; x < Input.Span2D.Width; x++)
//                {
//                    if (reachable[x, y])
//                    {
//                        score++;
//                    }
//                }
//            }
//        }

//        return score;
//    }

//    private void GetScore(ReadOnlySpan2D<byte> grid, int y, int x, ref bool[,] reachable)
//    {
//        if (grid[y,x] == '9')
//        {
//            reachable[y, x] = true;
//        }

//        for (var y2 = -1; y2 < 2; y2++)
//        {
//            for (var x2 = -1; x2 < 2; x2++)
//            {
//                if ((x2 == 0 && y2 == 0) || (y2 == -1 && x2 == -1) || (y2 == 1 && x2 == -1) || (y2 == -1 && x2 == 1) || (y2 == 1 && x2 == 1) || x + x2 > grid.Width - 1 || x + x2 < 0 || y + y2 > grid.Height - 1 || y + y2 < 0)
//                {
//                    continue;
//                }

//                if (grid[y + y2, x + x2] - '0' == grid[y, x] - '0' + 1)
//                {
//                    GetScore(grid, y + y2, x + x2, ref reachable);
//                }
//            }
//        }
//    }

//    protected override object InternalPart2()
//    {
//        var trailHeads = new List<(int y, int x)>();

//        for (var y = 0; y < Input.Span2D.Height; y++)
//        {
//            for (var x = 0; x < Input.Span2D.Width; x++)
//            {
//                if (Input.Span2D[y, x] == '0')
//                {
//                    trailHeads.Add((y, x));
//                }
//            }
//        }

//        var score = 0;
//        foreach (var t in trailHeads)
//        {
//            var reachable = new int[Input.Span2D.Width, Input.Span2D.Height];
//            GetScore2(Input.Span2D, t.y, t.x, ref reachable);
//            for (var y = 0; y < Input.Span2D.Height; y++)
//            {
//                for (var x = 0; x < Input.Span2D.Width; x++)
//                {
//                    score += reachable[x, y];
//                }
//            }
//        }

//        return score;
//    }

//    private void GetScore2(ReadOnlySpan2D<byte> grid, int y, int x, ref int[,] reachable)
//    {
//        if (grid[y, x] == '9')
//        {
//            reachable[y, x]++;
//        }

//        for (var y2 = -1; y2 < 2; y2++)
//        {
//            for (var x2 = -1; x2 < 2; x2++)
//            {
//                if ((x2 == 0 && y2 == 0) || (y2 == -1 && x2 == -1) || (y2 == 1 && x2 == -1) || (y2 == -1 && x2 == 1) || (y2 == 1 && x2 == 1) || x + x2 > grid.Width - 1 || x + x2 < 0 || y + y2 > grid.Height - 1 || y + y2 < 0)
//                {
//                    continue;
//                }

//                if (grid[y + y2, x + x2] - '0' == grid[y, x] - '0' + 1)
//                {
//                    GetScore2(grid, y + y2, x + x2, ref reachable);
//                }
//            }
//        }
//    }
//}
