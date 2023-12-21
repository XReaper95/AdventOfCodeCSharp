namespace AdventOfCode2021;

using System.Text;

public sealed class Day03 : BaseDay
{
    private readonly string[] _input;

    private delegate char DigitCriteria(IReadOnlyCollection<string> input, int index);

    public Day03()
    {
        var textInput = File.ReadAllLines(InputFilePath);
        _input = textInput;
    }

    private static char MostCommonDigit(IReadOnlyCollection<string> input, int index)
    {
        var oneCount = input.Count(str => str[index] == '1');
        return input.Count - oneCount <= input.Count / 2 ? '1' : '0';
    }

    private static char LeastCommonDigit(IReadOnlyCollection<string> input, int index)
    {
        return MostCommonDigit(input, index) == '1' ? '0' : '1';
    }

    private static int CommonDigitsByPosition(IReadOnlyList<string> input, DigitCriteria criteria)
    {
        var individualInputSize = input[0].Length;

        var commonDigits = new StringBuilder(individualInputSize);
        for (var idx = 0; idx < individualInputSize; idx++)
        {
            commonDigits.Append(criteria(input, idx));
        }

        return Convert.ToInt32(commonDigits.ToString(), 2);
    }

    private static int FilterByCommonDigit(IReadOnlyList<string> input, DigitCriteria criteria, int startIndex = 0)
    {
        switch (input.Count)
        {
            case 1:
                return Convert.ToInt32(input[0], 2);
            case 0:
                return 0;
            default:
                var commonDigit = criteria(input, startIndex);
                var remainingInput = input.Where(it => it[startIndex] == commonDigit).ToArray();
                return FilterByCommonDigit(remainingInput, criteria, startIndex + 1);
        }
    }

    private int GammaRate() => CommonDigitsByPosition(_input, MostCommonDigit);
    private int EpsilonRate() => CommonDigitsByPosition(_input, LeastCommonDigit);
    private int OxygenGeneratorRate() => FilterByCommonDigit(_input, MostCommonDigit);
    private int Co2ScrubberRate() => FilterByCommonDigit(_input, LeastCommonDigit);

    public override ValueTask<string> Solve_1() => new((GammaRate() * EpsilonRate()).ToString());

    public override ValueTask<string> Solve_2() => new((OxygenGeneratorRate() * Co2ScrubberRate()).ToString());
}
