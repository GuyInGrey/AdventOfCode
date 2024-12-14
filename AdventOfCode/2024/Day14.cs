using AdventOfCodeSupport;

using System.Text;

namespace AdventOfCode._2024;
public class Day14 : AdventBase
{
    class Bot
    {
        public long X { get; set; }
        public long Y { get; set; }
        public long VX { get; set; }
        public long VY { get; set; }

        public int Quadrant(int roomWidth, int roomHeight)
        {
            var w = (roomWidth % 2 == 1 ? roomWidth - 1 : roomWidth) / 2;
            var h = (roomHeight % 2 == 1 ? roomHeight - 1 : roomHeight) / 2;

            return Y == h || X == w ? -1 :
                   X < w && Y < h ? 1 :
                   X < w ? 2 :
                   Y < h ? 3 :
                   4;
        }
    }

    protected override object InternalPart1()
    {
        var bots = Input.Lines.Select(line => new Bot
        {
            X = long.Parse(line.Split(',')[0].Substring(2)),
            Y = long.Parse(line.Split(' ')[0].Split(',')[1]),
            VX = long.Parse(line.Split(' ')[1].Split(',')[0].Substring(2)),
            VY = long.Parse(line.Split(' ')[1].Split(',')[1]),
        }).ToList();

        const int roomWidth = 101;
        const int roomHeight = 103;
        const int seconds = 100;

        foreach (var bot in bots)
        {
            bot.VX = bot.VX < 0 ? roomWidth + bot.VX : bot.VX;
            bot.VY = bot.VY < 0 ? roomHeight + bot.VY : bot.VY;

            bot.X = (bot.X + (bot.VX * seconds)) % roomWidth;
            bot.Y = (bot.Y + (bot.VY * seconds)) % roomHeight;
        }

        var s = new char[roomHeight * (roomWidth + 1)];
        for (var i = 0;  i < s.Length;  i++)
        {
            s[i] = '.';
            if (i % (roomWidth + 1) == roomWidth)
            {
                s[i] = '\n';
            }
        }
        foreach (var b in bots)
        {
            s[(b.Y * (roomWidth + 1)) + b.X] = 'X';
        }
        Console.WriteLine(new string(s));

        var counts = bots.GroupBy(b => b.Quadrant(roomWidth, roomHeight)).Where(r => r.Key != -1).Select(x => x.Count()).ToList();
        var safety = counts.First();
        foreach (var item in counts.Skip(1))
        {
            safety *= item;
        }
        return safety;
    }

    protected override object InternalPart2()
    {
        const int roomWidth = 101;
        const int roomHeight = 103;

        var occupancy = new int[roomWidth * roomHeight];

        var bots = Input.Lines.Select(line => new Bot
        {
            X = long.Parse(line.Split(',')[0].Substring(2)),
            Y = long.Parse(line.Split(' ')[0].Split(',')[1]),
            VX = long.Parse(line.Split(' ')[1].Split(',')[0].Substring(2)),
            VY = long.Parse(line.Split(' ')[1].Split(',')[1]),
        }).Select(bot =>
        {
            bot.VX = bot.VX < 0 ? roomWidth + bot.VX : bot.VX;
            bot.VY = bot.VY < 0 ? roomHeight + bot.VY : bot.VY;

            occupancy[(bot.Y * roomWidth) + bot.X]++;
            return bot;
        }).ToList();

        var seconds = 0;
        while (true)
        {
            foreach (var bot in bots)
            {
                occupancy[(bot.Y * roomWidth) + bot.X]--;
                bot.X = (bot.X + bot.VX) % roomWidth;
                bot.Y = (bot.Y + bot.VY) % roomHeight;
                occupancy[(bot.Y * roomWidth) + bot.X]++;
            }
            seconds++;

            for (var y = 0; y < roomHeight; y++)
            {
                var length = 0;
                for (var x = 0; x < roomWidth; x++)
                {
                    if (occupancy[(y * roomWidth) + x] == 0)
                    {
                        length = 0;
                    }
                    else
                    {
                        length++;
                    }

                    if (length > 10)
                    {
                        
                        var s = new char[roomHeight * (roomWidth + 1)];
                        for (var i = 0; i < s.Length; i++)
                        {
                            s[i] = '.';
                            if (i % (roomWidth + 1) == roomWidth)
                            {
                                s[i] = '\n';
                            }
                        }
                        foreach (var b in bots)
                        {
                            s[(b.Y * (roomWidth + 1)) + b.X] = 'X';
                        }
                        Console.WriteLine(new string(s));
                        return seconds;
                    }
                }
            }
        }
    }
}
