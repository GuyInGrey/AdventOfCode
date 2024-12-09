using AdventOfCodeSupport;

namespace AdventOfCode2024._2024;
public class Day02 : AdventBase
{
    //[Executable(2, "2.1.1")]
    //public static object Part1_1(string input)
    //{
    //    var safe = 0;
    //    foreach (var line in input.Split('\n'))
    //    {
    //        if (line.Trim() == string.Empty)
    //        {
    //            continue;
    //        }
    //        var nums = line.Split(' ').Select(int.Parse).ToList();

    //        var asc = nums[1] > nums[0];
    //        var us = false;
    //        for (var i = 1; i < nums.Count; i++)
    //        {
    //            var a = nums[i - 1];
    //            var b = nums[i];

    //            if (a == b || (b < a && asc) || (a < b && !asc) || Math.Abs(a - b) > 3)
    //            {
    //                us = true;
    //            }
    //        }

    //        if (!us)
    //        {
    //            safe++;
    //        }
    //    }

    //    return safe;
    //}

    protected override object InternalPart1()
    {
        var chars = Input.Bytes;

        var safe = 0;
        byte a = 0;
        byte b = 0;
        byte state = 0; // 0: New line, 1: asc, 2: desc
        var isUnsafe = false;
        foreach (var c in chars)
        {
            var isEndOfNum = c == ' ' || c == '\n';

            if (isEndOfNum && state == 0 && a != 0 && b != 0)
            {
                state = b > a ? (byte)1 : (byte)2;
            }

            if (isEndOfNum && state != 0)
            {
                if (a == b || (b < a && state == 1) || (a < b && state == 2) || Math.Abs(a - b) > 3)
                {
                    isUnsafe = true;
                }

                a = b;
                b = 0;
                if (c != '\n')
                {
                    continue;
                }
            }
            else if (isEndOfNum)
            {
                a = b;
                b = 0;
                if (c != '\n')
                {
                    continue;
                }
            }

            if (isUnsafe && c != '\n')
            {
                if (c != '\n')
                {
                    continue;
                }
            }

            if (c == '\n')
            {
                if (!isUnsafe)
                {
                    safe++;
                }

                a = 0;
                b = 0;
                state = 0;
                isUnsafe = false;
                continue;
            }

            b = (byte)((b * 10) + (c - '0'));
        }

        return safe;
    }

    //[Executable(2, "2.2.1")]
    //public static object Part2_1(string input)
    //{
    //    var safe = 0;
    //    foreach (var line in input.Split('\n'))
    //    {
    //        if (line.Trim() == string.Empty)
    //        {
    //            continue;
    //        }
    //        var nums2 = line.Split(' ').Select(int.Parse).ToList();

    //        for (var toRemove = 0; toRemove < nums2.Count; toRemove++)
    //        {
    //            var nums = new List<int>(nums2);
    //            nums.RemoveAt(toRemove);

    //            var asc = nums[1] > nums[0];
    //            var us = false;
    //            for (var i = 1; i < nums.Count; i++)
    //            {
    //                var a = nums[i - 1];
    //                var b = nums[i];

    //                if (a == b || (b < a && asc) || (a < b && !asc) || Math.Abs(a - b) > 3)
    //                {
    //                    us = true;
    //                }
    //            }

    //            if (!us)
    //            {
    //                safe++;
    //                break;
    //            }
    //        }
    //    }

    //    return safe;
    //}

    protected override object InternalPart2()
    {
        var chars = Input.Bytes;

        var safe = 0;
        byte a = 0;
        byte b = 0;
        byte state = 0; // 0: New line, 1: asc, 2: desc
        var isUnsafe = false;
        var unsafeThresholdMet = false;
        foreach (var c in chars)
        {
            var isEndOfNum = c == ' ' || c == '\n';

            if (isEndOfNum && state == 0 && a != 0 && b != 0)
            {
                state = b > a ? (byte)1 : (byte)2;
            }

            if (isEndOfNum && state != 0)
            {
                var triggeredThreshold = false;
                if (a == b || (b < a && state == 1) || (a < b && state == 2) || (Math.Abs(a - b) > 3 && !(!isUnsafe && c == '\n')))
                {
                    if (unsafeThresholdMet)
                    {
                        isUnsafe = true;
                    }
                    else
                    {
                        triggeredThreshold = true;
                        unsafeThresholdMet = true;
                    }
                }

                if (!triggeredThreshold || isUnsafe)
                {
                    a = b;
                    b = 0;
                }
                else
                {
                    b = 0;
                }
                if (c != '\n')
                {
                    continue;
                }
            }
            else if (isEndOfNum)
            {
                a = b;
                b = 0;
                if (c != '\n')
                {
                    continue;
                }
            }

            if (isUnsafe && c != '\n')
            {
                if (c != '\n')
                {
                    continue;
                }
            }

            if (c == '\n')
            {
                if (!isUnsafe)
                {
                    safe++;
                }

                a = 0;
                b = 0;
                state = 0;
                isUnsafe = false;
                continue;
            }

            b = (byte)((b * 10) + (c - '0'));
        }

        return safe;
    }
}
