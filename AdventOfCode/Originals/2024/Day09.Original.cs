using AdventOfCodeSupport;

namespace AdventOfCode2024.Originals._2024;
public class Day09 : AdventBase
{
    protected override object InternalPart1()
    {
        var data = new List<int>();

        var mode = 0;
        var id = 0;
        foreach (var b in Input.Bytes)
        {
            var count = b - '0';
            for (var i = 0; i < count; i++)
            {
                data.Add(mode == 0 ? id : -1);
            }

            mode = (mode + 1) % 2;
            if (mode % 2 == 1)
            {
                id++;
            }
        }

        for (var i = data.Count - 1; i >= 0; i--)
        {
            if (data[i] != -1)
            {
                for (var j = 0; j < data.Count && j < i; j++)
                {
                    if (data[j] == -1)
                    {
                        data[j] = data[i];
                        data[i] = -1;
                        break;
                    }
                }
            }
        }

        data.RemoveAll(d => d == -1);

        long cs = 0;
        for (var i = 0; i < data.Count; i++)
        {
            cs += data[i] * i;
        }
        return cs;
    }

    protected override object InternalPart2()
    {
        //var files = new Dictionary<int, (int start, int size)>();
        var drive = new Dictionary<int, (int fileId, int size)>();

        var driveIndex = 0;
        var maxFileId = 0;
        for (var i = 0; i < Input.Bytes.Length; i++)
        {
            var blockSize = Input.Bytes[i] - '0';

            if (i % 2 == 0)
            {
                drive.Add(driveIndex, (i / 2, blockSize));
                maxFileId = i / 2;
            }

            driveIndex += blockSize;
        }

        var fullIndex = new Dictionary<int, int>();
        for (var i = maxFileId; i >= 0; i--)
        {
            var file = drive.Single(f => f.Value.fileId == i);
            var fileIndex = file.Key;
            var fileSize = file.Value.size;

            if (!fullIndex.ContainsKey(fileSize))
            {
                fullIndex.Add(fileSize, 0);
            }

            var maxJ = 0;
            for (var j = fullIndex[fileSize]; j < fileIndex; j++)
            {
                maxJ = j;
                if (!drive.Any(k => k.Key <= j + fileSize - 1 && k.Key + k.Value.size - 1 >= j))
                {
                    drive.Remove(fileIndex);
                    drive.Add(j, (i, fileSize));
                    break;
                }
            }
            fullIndex[fileSize] = Math.Max(maxJ, fullIndex[fileSize]);
        }

        var debugString = "";
        for (var i = 0; i < driveIndex + 1; i++)
        {
            var file = drive.FirstOrDefault(k => k.Key <= i && k.Key + k.Value.size - 1 >= i);
            if (!file.Equals(default(KeyValuePair<int, (int, int)>)))
            {
                debugString += file.Value.fileId;
            }
            else
            {
                debugString += ".";
            }
        }

        long cs = 0;
        for (var i = 0; i < driveIndex + 1; i++)
        {
            var file = drive.FirstOrDefault(k => k.Key <= i && k.Key + k.Value.size - 1 >= i);
            if (!file.Equals(default(KeyValuePair<int, (int, int)>)))
            {
                cs += file.Value.fileId * i;
            }
        }

        return cs;
    }
}
