using AdventOfCodeSupport;

using MathNet.Numerics.LinearAlgebra;

namespace AdventOfCode._2024;
public class Day13 : AdventBase
{
    protected override object InternalPart1()
    {
        long cost = 0;
        foreach (var machineText in Input.Blocks)
        {
            var aX = long.Parse(machineText.Lines[0].Split('X')[1].Split(',')[0].Substring(1));
            var aY = long.Parse(machineText.Lines[0].Split('Y')[1].Substring(1));
            var bX = long.Parse(machineText.Lines[1].Split('X')[1].Split(',')[0].Substring(1));
            var bY = long.Parse(machineText.Lines[1].Split('Y')[1].Substring(1));
            var pX = long.Parse(machineText.Lines[2].Split('X')[1].Split(',')[0].Substring(1));
            var pY = long.Parse(machineText.Lines[2].Split('Y')[1].Substring(1));

            for (var aP = 0; aP * aX <= pX && aP <= 100; aP++)
            {
                var bP = ((pX - (aP * aX)) / bX);
                if ((pX - (aP * aX) - (bP * bX)) == 0 && (pY - (aP * aY) - (bP * bY)) == 0 && bP <= 100)
                {
                    cost += (aP * 3) + ((pX - (aP * aX)) / bX);
                }
            }
        }
        return cost;
    }

    protected override object InternalPart2()
    {
        const long add = 0;

        long cost = 0;
        foreach (var machineText in Input.Blocks)
        {
            var aX = double.Parse(machineText.Lines[0].Split('X')[1].Split(',')[0].Substring(1));
            var aY = double.Parse(machineText.Lines[0].Split('Y')[1].Substring(1));
            var bX = double.Parse(machineText.Lines[1].Split('X')[1].Split(',')[0].Substring(1));
            var bY = double.Parse(machineText.Lines[1].Split('Y')[1].Substring(1));
            var pX = double.Parse(machineText.Lines[2].Split('X')[1].Split(',')[0].Substring(1)) + add;
            var pY = double.Parse(machineText.Lines[2].Split('Y')[1].Substring(1)) + add;

            var A = Matrix<double>.Build.Dense(2, 2, [ aX, aY, bX, bY ]);
            var B = Matrix<double>.Build.Dense(2, 1, [ pX, pY ]);

            var aInverse = A.Inverse();
            var X = aInverse * B;

            var aP = Math.Round(X[0, 0]);
            var bP = Math.Round(X[1, 0]);

            if ((aP * aX) + (bP * bX) == pX && (aP * aY) + (bP * bY) == pY)
            {
                cost += ((long)aP * 3) + (long)bP;
            }
        };
        return cost;
    }
}
