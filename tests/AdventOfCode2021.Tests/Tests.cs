using AoCHelper;

namespace AdventOfCode2021;

using NUnit.Framework;

public class Tests
{
    [TestCase(typeof(Day01), "7", "5")]
    [TestCase(typeof(Day02), "150", "900")]
    [TestCase(typeof(Day03), "198", "230")]
    public async Task TestPart1(Type type, string solution1, string solution2)
    {
        if (Activator.CreateInstance(type) is BaseDay instance)
        {
            Assert.That(solution1, Is.EqualTo(await instance.Solve_1()));
            Assert.That(solution2, Is.EqualTo(await instance.Solve_2()));
        }
        else
        {
            Assert.Fail($"{type} is not a {nameof(BaseDay)} instance");
        }
    }
}
