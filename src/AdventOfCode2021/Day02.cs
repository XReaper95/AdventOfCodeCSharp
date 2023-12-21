namespace AdventOfCode2021;

public sealed class Day02 : BaseDay
{
    private readonly Command[] _input;

    public Day02()
    {
        var textInput = File.ReadAllLines(InputFilePath);
        _input = (
            from line in textInput
            let splatLine = line.Split(" ")
            select new Command(splatLine[0], Convert.ToInt32(splatLine[1]))
        ).ToArray();
    }

    private record Command(string Action, int Value);

    private class Submarine
    {
        private int _horizontalPosition;
        private int _depth;
        private int _aim;

        public int ProcessCommands(IEnumerable<Command> commands)
        {
            foreach (var (action, value) in commands)
            {
                switch (action)
                {
                    case "forward":
                        _horizontalPosition += value;
                        break;
                    case "up":
                        _depth -= value;
                        break;
                    case "down":
                        _depth += value;
                        break;
                }
            }

            return _horizontalPosition * _depth;
        }

        public int ProcessCommandsWithAim(IEnumerable<Command> commands)
        {
            foreach (var (action, value) in commands)
            {
                switch (action)
                {
                    case "forward":
                        _horizontalPosition += value;
                        _depth += _aim * value;
                        break;
                    case "up":
                        _aim -= value;
                        break;
                    case "down":
                        _aim += value;
                        break;
                }
            }

            return _horizontalPosition * _depth;
        }
    }

    public override ValueTask<string> Solve_1() => new(new Submarine().ProcessCommands(_input).ToString());

    public override ValueTask<string> Solve_2() => new(
        new Submarine().ProcessCommandsWithAim(_input).ToString()
        );
}
