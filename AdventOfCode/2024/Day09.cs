using AdventOfCodeSupport;

namespace AdventOfCode._2024;
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
        //var lastFileIndex = Input.Bytes.Length - 1 - ((Input.Bytes.Length + 1) % 2);

        //var drive = new int[Input.Bytes.Length * 10];
        //var driveWriteHead = 0;

        //var fileId = 0;

        //var moved = new bool[(Input.Bytes.Length + (Input.Bytes.Length % 2)) / 2];

        //var requiredFileSize = 1;
        //for (var i = 0; i < Input.Bytes.Length; i++)
        //{
        //    if (i % 2 == 0 && moved[fileId])
        //    {
        //        continue;
        //    }

        //    var num = Input.Bytes[i] - '0';

        //    if (i % 2 == 0)
        //    {
        //        for (var j = 0; j < num; j++)
        //        {
        //            drive[driveWriteHead] = fileId + 1;
        //            driveWriteHead++;
        //        }
        //        fileId++;
        //    }
        //    else
        //    {
        //        if (num < requiredFileSize)
        //        {
        //            driveWriteHead += num;
        //            continue;
        //        }

        //        for (var k = lastFileIndex; k > i && num > 0; k -= 2)
        //        {
        //            var fileSize = Input.Bytes[k] - '0';
        //            var laterFileId = k / 2;

        //            if (moved[laterFileId])
        //            {
        //                continue;
        //            }

        //            if (fileSize <= num)
        //            {
        //                moved[laterFileId] = true;
        //                for (var m = 0; m < fileSize; m++)
        //                {
        //                    drive[driveWriteHead] = laterFileId + 1;
        //                    driveWriteHead++;
        //                }
        //                num -= fileSize;
        //            }
        //        }

        //        if (num > 0)
        //        {
        //            requiredFileSize = num + 1;
        //        }

        //        driveWriteHead += num;
        //    }
        //}



        return 0;
    }
}
