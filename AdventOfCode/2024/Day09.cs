using AdventOfCodeSupport;

namespace AdventOfCode2024._2024;
public class Day09 : AdventBase
{
    protected override object InternalPart1()
    {
        //var data = new List<int>();

        //var mode = 0;
        //var id = 0;
        //foreach (var b in Input.Bytes)
        //{
        //    var count = b - '0';
        //    for (var i = 0; i < count; i++)
        //    {
        //        data.Add(mode == 0 ? id : -1);
        //    }

        //    mode = (mode + 1) % 2;
        //    if (mode % 2 == 1)
        //    {
        //        id++;
        //    }
        //}

        //for (var i = data.Count - 1; i >= 0; i--)
        //{
        //    if (data[i] != -1)
        //    {
        //        for (var j = 0; j < data.Count && j < i; j++)
        //        {
        //            if (data[j] == -1)
        //            {
        //                data[j] = data[i];
        //                data[i] = -1;
        //                break;
        //            }
        //        }
        //    }
        //}

        //data.RemoveAll(d => d == -1);

        long cs = 0;
        //for (var i = 0; i < data.Count; i++)
        //{
        //    cs += data[i] * i;
        //}
        return cs;
    }

    protected override object InternalPart2()
    {
        var drive = new int[Input.Text.Length * 10];

        var fileId = 0;
        for (var i = 0; i < Input.Bytes.Length; i++)
        {
            var num = Input.Bytes[i] - '0';
            for (var j = 0; j < num; j++)
            {
                drive.Add(i % 2 == 0 ? fileId : -1);
            }
            if (i % 2 == 0)
            {
                fileSizes.Add(fileId, num);
                fileId++;
            }
        }

        return 0;
    }
}
