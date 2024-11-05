namespace DGQuestions;

public class Program
{
    private static void Main(string[] args)
    {
        List<IDegreedSolution> solutions = [new SearchRotatedSortedArray()];

        foreach (var solution in solutions)
        {
            solution.Run();
        }
    }
}

