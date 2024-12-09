using AdventOfCodeSupport;

namespace AdventOfCode2024._2024;
public class Day05 : AdventBase
{
    //[Executable(5, "5.1.1")]
    //public static object Part1_1(string input)
    //{
    //    input = input.Trim();
    //    var orders = input.Split("\n\n")[0].Split('\n').Select(l => l.Split('|')).Select(x => x.Select(int.Parse).ToList()).ToList();
    //    var seqs = input.Split("\n\n")[1].Split('\n').Select(l => l.Split(',')).Select(x => x.Select(int.Parse).ToList()).ToList();

    //    var sum = 0;
    //    foreach (var seq in seqs.Select(l => l.Select((v, i) => (v, i)).ToList()))
    //    {
    //        var isBad = false;

    //        for (var i = 0; i < seq.Count; i++)
    //        {
    //            var matches1 = orders.Where(o => o[0] == seq[i].v);
    //            foreach (var match in matches1)
    //            {
    //                if (seq.Any(s => s.i < i && s.v == match[1]))
    //                {
    //                    isBad = true;
    //                }
    //            }


    //            var matches2 = orders.Where(o => o[1] == seq[i].v);
    //            foreach (var match in matches2)
    //            {
    //                if (seq.Any(s => s.i > i && s.v == match[0]))
    //                {
    //                    isBad = true;
    //                }
    //            }
    //        }

    //        if (!isBad)
    //        {
    //            sum += seq[seq.Count / 2].v;
    //        }
    //    }

    //    return sum;
    //}

    protected override object InternalPart1()
    {
        var input = Input.Text.Trim();
        var orders = input.Split("\n\n")[0].Split('\n').Select(l => l.Split('|')).Select(x => x.Select(int.Parse).ToList()).ToList();
        var seqs = input.Split("\n\n")[1].Split('\n').Select(l => l.Split(',')).Select(x => x.Select(int.Parse).ToList()).ToList();

        var sum = 0;
        foreach (var seq in seqs.Select(l => l.Select((v, i) => (v, i)).ToList()))
        {
            var isBad = false;

            for (var i = 0; i < seq.Count; i++)
            {
                var matches1 = orders.Where(o => o[0] == seq[i].v);
                foreach (var match in matches1)
                {
                    if (seq.Any(s => s.i < i && s.v == match[1]))
                    {
                        isBad = true;
                    }
                }


                var matches2 = orders.Where(o => o[1] == seq[i].v);
                foreach (var match in matches2)
                {
                    if (seq.Any(s => s.i > i && s.v == match[0]))
                    {
                        isBad = true;
                    }
                }
            }

            if (!isBad)
            {
                sum += seq[seq.Count / 2].v;
            }
        }

        return sum;
    }

    //[Executable(5, "5.2.1")]
    //public static object Part2_1(string input)
    //{
    //    input = input.Trim();
    //    var orders = input.Split("\n\n")[0].Split('\n').Select(l => l.Split('|')).Select(x => x.Select(int.Parse).ToList()).ToList();
    //    var seqs = input.Split("\n\n")[1].Split('\n').Select(l => l.Split(',')).Select(x => x.Select(int.Parse).ToList()).ToList();

    //    var sum = 0;
    //    foreach (var seq2 in seqs)
    //    {
    //        var neededUpdate = false;
    //        var seq = seq2.ToArray();

    //    checkStart:
    //        ;

    //        for (var i = 0; i < seq.Length; i++)
    //        {
    //            var matches1 = orders.Where(o => o[0] == seq[i]);
    //            foreach (var match in matches1)
    //            {
    //                for (var j = 0; j < seq.Length; j++)
    //                {
    //                    if (seq[j] == match[1] && j < i)
    //                    {
    //                        Swap(ref seq[j], ref seq[i]);
    //                        neededUpdate = true;
    //                        goto checkStart;
    //                    }
    //                }
    //            }


    //            var matches2 = orders.Where(o => o[1] == seq[i]);
    //            foreach (var match in matches2)
    //            {
    //                for (var j = 0; j < seq.Length; j++)
    //                {
    //                    if (seq[j] == match[1] && j > i)
    //                    {
    //                        Swap(ref seq[j], ref seq[i]);
    //                        neededUpdate = true;
    //                        goto checkStart;
    //                    }
    //                }
    //            }
    //        }

    //        if (neededUpdate)
    //        {
    //            sum += seq[seq.Length / 2];
    //        }
    //    }

    //    return sum;
    //}

    protected override object InternalPart2()
    {
        var orders = Input.Text.Split("\n\n")[0].Split('\n').Select(l => l.Split('|')).Select(x => x.Select(int.Parse).ToList()).ToList();
        var seqs = Input.Text.Split("\n\n")[1].Split('\n').Select(l => l.Split(',')).Select(x => x.Select(int.Parse).ToList()).ToList();

        var sum = 0;
        foreach (var seq2 in seqs)
        {
            var neededUpdate = false;
            var seq = seq2.ToArray();

            for (var i = 0; i < seq.Length; i++)
            {
                var matches1 = orders.Where(o => o[0] == seq[i]);
                foreach (var match in matches1)
                {
                    for (var j = 0; j < seq.Length; j++)
                    {
                        if (seq[j] == match[1] && j < i)
                        {
                            Swap(ref seq[j], ref seq[i]);
                            neededUpdate = true;
                            i = j;
                        }
                    }
                }


                var matches2 = orders.Where(o => o[1] == seq[i]);
                foreach (var match in matches2)
                {
                    for (var j = 0; j < seq.Length; j++)
                    {
                        if (seq[j] == match[1] && j > i)
                        {
                            Swap(ref seq[j], ref seq[i]);
                            neededUpdate = true;
                        }
                    }
                }
            }

            if (neededUpdate)
            {
                sum += seq[seq.Length / 2];
            }
        }

        return sum;
    }

    static void Swap(ref int a, ref int b)
    {
        (b, a) = (a, b);
    }
}
