namespace DGQuestions;

/*
Top K Frequent Elements
Problem Description:
Given an array of integers nums, return the k most frequent elements. You can assume that the array is non-empty and k is always valid.
Input:
nums[]: An array of integers.
    k: An integer representing how many frequent elements to return.
Output:
Return an array of the k most frequent elements.
    Example:
Input:
nums = [1, 1, 1, 2, 2, 3], k = 2
Output:
[1, 2]
*/

public class TopKFrequentElements : IDegreedSolution
{
    public void Run()
    {
        TopKFrequent([1, 1, 1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 4], 2);
    }

    private void TopKFrequent(int[] input, int topKFrequent)
    {
        Console.WriteLine("Input to question: " + GetType());
        Console.WriteLine("[" + string.Join(", ", input) + "]");

        if (input.Length == 0)
        {
            return;
        }

        var result = new List<int>();
        var frequencyMap = new Dictionary<int, int>();

        foreach (var num in input)
        {
            if (!frequencyMap.TryAdd(num, 1))
            {
                frequencyMap[num]++;
            }
        }

        var sortedFrequencyMap = frequencyMap.OrderByDescending(x => x.Value).Take(topKFrequent)
            .Select(x => x.Key)
            .ToArray();

        Console.WriteLine("Output to question: " + GetType());
        Console.WriteLine("[" + string.Join(", ", sortedFrequencyMap) + "]");
    }
}