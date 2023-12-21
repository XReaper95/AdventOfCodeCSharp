namespace AdventOfCode2021;

public sealed class Day01 : BaseDay
{
    private readonly int[] _input;

    public Day01()
    {
        var textInput = File.ReadAllLines(InputFilePath);
        _input = textInput.Select(int.Parse).ToArray();
    }

    private static int DepthCheck(IReadOnlyList<int> input)
    {
        var resultSize = input.Count - 1;
        var count = 0;
        for (var idx = 0; idx < resultSize; idx++)
        {
            var item = input[idx];
            var nextItem = input[idx + 1];
            if (item < nextItem) count += 1;
        }

        return count;
    }

    private static int DepthCheckWindowed(IReadOnlyList<int> input)
    {
        var resultSize = input.Count - 3;
        var count = 0;
        for (var idx = 0; idx < resultSize; idx++)
        {
            var windowSum = input[idx] + input[idx + 1] + input[idx + 2];
            var nextWindowSum = input[idx + 1] + input[idx + 2] + input[idx + 3];
            if (windowSum < nextWindowSum) count += 1;
        }

        return count;
    }

    public override ValueTask<string> Solve_1() => new(
        DepthCheck(_input).ToString()
    );

    public override ValueTask<string> Solve_2() => new(
        DepthCheckWindowed(_input).ToString()
    );
}
