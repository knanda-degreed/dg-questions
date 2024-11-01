namespace DGQuestions;

using System;
using System.Collections.Generic;
using System.Linq;

public class TopKFrequentElementsMinHeap : IDegreedSolution
{
    public void Run()
    {
        var result = TopKFrequent(new int[] {1, 1, 1, 2, 2, 3, 3, 3, 4, 4, 4, 4, 4}, 2);
        Console.WriteLine("Output: [" + string.Join(", ", result) + "]");
    }

    private int[] TopKFrequent(int[] input, int k)
    {
        Console.WriteLine("Input: [" + string.Join(", ", input) + "]");

        if (input.Length == 0)
        {
            return [];
        }

        // Step 1: Build the frequency map
        var frequencyMap = new Dictionary<int, int>();
        foreach (var num in input)
        {
            if (!frequencyMap.TryAdd(num, 1))
            {
                frequencyMap[num]++;
            }
        }

        // Step 2: Use a min-heap to keep track of the top k elements
        var minHeap = new SortedSet<(int frequency, int number)>();
        
        foreach (var entry in frequencyMap)
        {
            minHeap.Add((entry.Value, entry.Key));

            // If the heap size exceeds k, remove the element with the smallest frequency
            if (minHeap.Count > k)
            {
                minHeap.Remove(minHeap.Min);
            }
        }

        // Step 3: Extract the elements from the heap
        return minHeap.Select(x => x.number).ToArray();
    }
}
