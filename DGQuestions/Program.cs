namespace DGQuestions;

public class Program
{
    private static void Main(string[] args)
    {
        List<IDegreedSolution> solutions = [new OptimizingRealTimeAnomalyDetection()];

        foreach (var solution in solutions)
        {
            solution.Run();
        }
    }
}

