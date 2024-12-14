using AdventOfCodeSupport;

using System.Text.RegularExpressions;

namespace AdventOfCode._2024;
public class Day03 : AdventBase
{
    //[Executable(3, "3.1.1")]
    //public static object Part1_1(string input)
    //{
    //    var matches = Regex.Matches(input, "mul\\((\\d+),(\\d+)\\)");

    //    var sum = 0;
    //    foreach (var m in matches.ToList())
    //    {
    //        sum += int.Parse(m.Groups[1].Value) * int.Parse(m.Groups[2].Value);
    //    }
    //    return sum;
    //}

    protected override object InternalPart1()
    {
        const string initText = "mul(";

        byte state = 0; // 0: init, 1: num1, 2: num2
        byte initIndex = 0;

        var num1 = 0;
        var num2 = 0;

        var sum = 0;

        var chars = Input.Bytes;
        foreach (var c in chars)
        {
            if (state == 0)
            {
                if (initText[initIndex] == c)
                {
                    initIndex++;
                    if (initIndex == 4)
                    {
                        state = 1;
                        continue;
                    }
                }
                else
                {
                    initIndex = 0;
                    continue;
                }
            }
            else if (state == 1)
            {
                if (c == ',')
                {
                    state = 2;
                }
                else if (c >= '0' && c <= '9')
                {
                    num1 = (num1 * 10) + (c - '0');
                }
                else
                {
                    state = 0;
                    initIndex = 0;
                    num1 = 0;
                    continue;
                }
            }
            else if (state == 2)
            {
                if (c == ')')
                {
                    sum += num1 * num2;
                    state = 0;
                    initIndex = 0;
                    num1 = 0;
                    num2 = 0;
                    continue;
                }
                else if (c >= '0' && c <= '9')
                {
                    num2 = (num2 * 10) + (c - '0');
                }
                else
                {
                    state = 0;
                    initIndex = 0;
                    num1 = 0;
                    num2 = 0;
                    continue;
                }
            }
        }

        return sum;
    }

    protected override object InternalPart2()
    {
        var matches = Regex.Matches(Input.Text, "mul\\((\\d+),(\\d+)\\)");
        var dos = Regex.Matches(Input.Text, "do\\(\\)");
        var donts = Regex.Matches(Input.Text, "don\\'t\\(\\)");

        var sum = 0;
        foreach (var m in matches.ToList())
        {
            var last = dos.Where(m2 => m2.Index < m.Index).Union(donts.Where(m2 => m2.Index < m.Index)).OrderByDescending(m => m.Index).FirstOrDefault();
            sum += last is not null && last.Value == "don't()" ? 0 : int.Parse(m.Groups[1].Value) * int.Parse(m.Groups[2].Value);
        }
        return sum;
    }
}
