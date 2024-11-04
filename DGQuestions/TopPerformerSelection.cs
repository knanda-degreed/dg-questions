namespace DGQuestions;

/*
Top Performer Selection
    Problem Description:
You are running a series of tests and need to select the score of the k-th highest performer. If multiple performers have the same score, they tie at that position.
    Input:
scores[]: An array of integers representing the scores of the performers.
    k: An integer representing the rank to select.
    Output:
Return the k-th highest score.
    Example:
Input:
scores = [100, 95, 80, 95, 70, 85, 75], k = 2
Output:
95
Explanation: The 2nd highest score is 95.
*/

public class TopPerformerSelection : IDegreedSolution
{
    public void Run()
    {
        var input = new[] { 100, 95, 80, 95, 70, 85, 75};
        const int whichHighest = 2;
        var kthHighestTopPerformer = KthHighestTopPerformer(input, whichHighest);
        Console.Write("Kth highest performer is: [" + kthHighestTopPerformer + ", where k is " + whichHighest + "]");
    }

    private int KthHighestTopPerformer(int[] inputs, int whichHighest)
    {
        if (inputs.Length == 0)
        {
            throw new ArgumentException("Invalid Input: input cannot be empty");
        }

        var minHeap = new SortedSet<int>();

        foreach (var input in inputs)
        {
            if (!minHeap.Contains(input))
            {
                minHeap.Add(input);
                if (minHeap.Count > whichHighest)
                {
                    minHeap.Remove(minHeap.Min);
                }
            }
        }

        if (minHeap.Count == whichHighest)
        {
            return minHeap.Min;
        }

        throw new ArgumentException("Not enough unique scores to calculate the " + whichHighest + " highest");
    }
}