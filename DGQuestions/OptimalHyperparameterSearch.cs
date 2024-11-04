namespace DGQuestions;

/*
Optimal Hyperparameter Search
    Problem Description:
You are tuning the hyperparameters for a machine learning model and need to find the best hyperparameter value that maximizes accuracy. Given a sorted list of hyperparameter values and their respective accuracies, find the hyperparameter value that gives the highest accuracy.
    Input:
    params[]: A sorted list of hyperparameter values (e.g., [1, 2, 3, 4, 5]).
    accuracies[]: Corresponding accuracies for each hyperparameter (e.g., [80, 85, 90, 88, 70]).
    Output:
Return the hyperparameter value with the highest accuracy.
    Example:
Input:
    params = [1, 2, 3, 4, 5], accuracies = [80, 85, 90, 88, 70]
Output:
3
*/

public class OptimalHyperparameterSearch: IDegreedSolution
{
    public void Run()
    {
        var result = FindOptimalHyperparameter(new int[] { 1, 2, 3, 4, 5 }, new int[] { 80, 85, 90, 88, 70 });
        Console.WriteLine("Output: " + result);
    }

    private int FindOptimalHyperparameter(int[] parameters, int[] accuracies)
    {
        Console.WriteLine("Input: [" + string.Join(", ", parameters) + "]");
        Console.WriteLine("[" + string.Join(", ", accuracies) + "]");

        if (parameters.Length == 0 || accuracies.Length == 0)
        {
            return -1;
        }

        int maxAccuracy = accuracies[0];
        int maxAccuracyIndex = 0;

        for (int i = 1; i < accuracies.Length; i++)
        {
            if (accuracies[i] > maxAccuracy)
            {
                maxAccuracy = accuracies[i];
                maxAccuracyIndex = i;
            }
        }
        
        return parameters[maxAccuracyIndex];
    }
}