namespace DGQuestions;

public class Program
{
    private static void Main(string[] args)
    {
        List<IDegreedSolution> solutions = [new TopKFrequentWords()];

        foreach (var solution in solutions)
        {
            solution.Run();
        }
    }
}

