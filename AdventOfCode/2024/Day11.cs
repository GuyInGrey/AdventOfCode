using AdventOfCodeSupport;

namespace AdventOfCode._2024;
public class Day11 : AdventBase
{
    protected override object InternalPart1()
    {
        var nums = Input.Text.Split(' ').Select(long.Parse).ToList();

        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < nums.Count; j++)
            {
                if (nums[j] == 0)
                {
                    nums[j] = 1;
                }
                else if (Math.Floor(Math.Log10(nums[j]) + 1) % 2 == 0)
                {
                    var s = nums[j].ToString();
                    var left = s.Substring(0, s.Length / 2);
                    var right = s.Substring(s.Length / 2, s.Length / 2);

                    nums[j] = long.Parse(left);
                    nums.Insert(j + 1, long.Parse(right));
                    j++;
                }
                else
                {
                    nums[j] *= 2024;
                }
            }
            Console.WriteLine(i + " - " + nums.Count);
        }

        return nums.Count;
    }

    protected override object InternalPart2()
    {
        const int blinks = 75;

        var cache = new Dictionary<(long value, long iteration), long>();

        long count = 0;
        var bag = new List<(long value, long iteration)>();
        foreach (var num in Input.Text.Split(' ').Select(long.Parse))
        {
            bag.Add((num, 0));
        }

        var stack = new Stack<Step>();

        while (bag.Count > 0)
        {
            stack.Push(new Step()
            {
                Value = bag[bag.Count - 1].value,
                Iteration = 0,
            });
            bag.RemoveAt(bag.Count - 1);
            while (stack.Count > 0)
            {
                var top = stack.Peek();

                if (top.Iteration == blinks)
                {
                    top.TotalLineageCount = 1;
                    top.Substeps.Clear();
                }

                if (top.Substeps.Count == 0 && top.TotalLineageCount > 0)
                {
                    stack.Pop();

                    if (stack.Count == 0)
                    {
                        count += top.TotalLineageCount;
                        break;
                    }

                    var next = stack.Peek();
                    next.Substeps.Remove(top);
                    next.TotalLineageCount += top.TotalLineageCount;
                    cache.TryAdd((top.Value, top.Iteration), top.TotalLineageCount);
                }
                else if (top.TotalLineageCount == 0 && top.Substeps.Count == 0)
                {
                    if (cache.TryGetValue((top.Value, top.Iteration), out var totalLineageCount))
                    {
                        top.TotalLineageCount = totalLineageCount;
                        continue;
                    }

                    if (top.Value == 0)
                    {
                        var a = new Step()
                        {
                            Value = 1,
                            Iteration = top.Iteration + 1,
                        };
                        top.Substeps.Add(a);
                        stack.Push(a);
                    }
                    else if (top.Value.ToString().Length % 2 == 0)
                    {
                        var s = top.Value.ToString();
                        var a = new Step()
                        {
                            Value = long.Parse(s.Substring(0, s.Length / 2)),
                            Iteration = top.Iteration + 1,
                        };
                        top.Substeps.Add(a);
                        stack.Push(a);
                        top.Substeps.Add(new()
                        {
                            Value = long.Parse(s.Substring(s.Length / 2, s.Length / 2)),
                            Iteration = top.Iteration + 1,
                        });
                    }
                    else
                    {
                        var a = new Step()
                        {
                            Value = top.Value * 2024,
                            Iteration = top.Iteration + 1,
                        };
                        top.Substeps.Add(a);
                        stack.Push(a);
                    }
                }
                else
                {
                    stack.Push(top.Substeps[0]);
                }
            }
        }

        return count;
    }

    class Step
    {
        public required long Value { get; set; }
        public required long Iteration { get; set; }
        public long TotalLineageCount { get; set; }
        public List<Step> Substeps { get; set; } = [];
    }
}
