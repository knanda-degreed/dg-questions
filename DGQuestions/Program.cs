namespace DGQuestions;

public class Program
{
    private static void Main(string[] args)
    {
        List<IDegreedSolution> solutions = [new LongestConsecutiveSequence()];

        foreach (var solution in solutions)
        {
            solution.Run();
        }
    }
}

