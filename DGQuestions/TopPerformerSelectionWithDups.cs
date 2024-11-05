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
scores = [100, 95, 80, 95, 70, 85, 75], k = 3
Output:
95
Explanation: The 3rd highest score is 95 i.e. duplicates are counted as individual ranks.
*/

public class TopPerformerSelectionWithDups : IDegreedSolution
{
    public void Run()
    {
        var input = new[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
        const int whichHighest = 4;
        var kthHighestTopPerformer = KthHighestTopPerformer(input, whichHighest);
        Console.Write("Kth highest performer is: [" + kthHighestTopPerformer + ", where k is " + whichHighest + "]");
    }

    private int KthHighestTopPerformer(int[] nums, int k)
    {
        if (nums.Length == 0)
        {
            throw new ArgumentException("Invalid Input: input cannot be empty");
        }

        var minHeap = new PriorityQueue<int, int>();

        foreach (var input in nums)
        {
            minHeap.Enqueue(input, input);
            if (minHeap.Count > k)
            {
                minHeap.Dequeue();
            }
        }

        return minHeap.Peek();
    }
}