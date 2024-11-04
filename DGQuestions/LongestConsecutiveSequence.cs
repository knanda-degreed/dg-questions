namespace DGQuestions;

/*
Longest Consecutive Sequence
    Problem Description:
Given an unsorted array of integers, find the length of the longest consecutive sequence of elements.
    Input:
An unsorted array of integers.
    Output:
A single integer representing the length of the longest consecutive sequence.
    Example:
Input:
nums = [100, 4, 200, 1, 3, 2]
Output:
4
Explanation: The longest consecutive sequence is [1, 2, 3, 4].
*/

public class LongestConsecutiveSequence : IDegreedSolution
{
    public void Run()
    {
        int[] nums = { 100, 4, 200, 1, 3, 2, 101, 10, 102, 11, 103, 115, 104 };
        Console.WriteLine("Input: [" + string.Join(",", nums) + "]");
        Console.WriteLine(LongestConsecutive(nums));
    }

    private int LongestConsecutive(int[] nums)
    {
        if (nums.Length == 0)
        {
            throw new ArgumentException("Input array is empty");
        }

        HashSet<int> numSet = new HashSet<int>();
        foreach (int num in nums)
        {
            numSet.Add(num);
        }

        int longestStreak = 0;
        int currentStreak = 0;
        foreach (int num in nums)
        {
            if (!numSet.Contains(num - 1))
            {
                // this is the start of a new sequence
                var currentNum = num;
                currentStreak = 1;

                // keep going until there are no more consecutive numbers
                while (numSet.Contains(currentNum + 1))
                {
                    currentNum++;
                    currentStreak++;
                }
            }

            longestStreak = Math.Max(longestStreak, currentStreak);
        }

        return longestStreak;
    }
}