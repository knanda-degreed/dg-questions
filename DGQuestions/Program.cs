namespace DGQuestions;

public class Program
{
    private static void Main(string[] args)
    {
        List<IDegreedSolution> solutions = [new CoinChange()];

        foreach (var solution in solutions)
        {
            solution.Run();
        }
    }
}

