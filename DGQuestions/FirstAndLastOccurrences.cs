namespace DGQuestions;

/*
First and Last Occurrences

Given a sorted array arr with possibly some duplicates, the task is to find the first and last occurrences of an element x in the given array.
    Note: If the number x is not found in the array then return both the indices as -1.
    Examples:
Input: arr[] = [1, 3, 5, 5, 5, 5, 67, 123, 125], x = 5
Output:  2, 5
Explanation: First occurrence of 5 is at index 2 and last occurrence of 5 is at index 5.
    Input: arr[] = [1, 3, 5, 5, 5, 5, 7, 123, 125], x = 7
Output:  6, 6
Explanation: First and last occurrence of 7 is at index 6.
*/
public class FirstAndLastOccurrences : IDegreedSolution
{
    public void Run()
    {
        var input = new[] { 1, 3, 5, 5, 5, 5, 7, 123, 125 };
        var target = 5;
        Console.WriteLine($"Input: arr = [{string.Join(",", input)}], x = {target}");
        Console.WriteLine(FindFirstAndLastOccurrences(input, target));
    }

    private (int first, int last) FindFirstAndLastOccurrences(int[] input, int target)
    {
        int firstOccurrence = FindFirstOccurrence(input, target, true);
        int lastOccurrence = FindFirstOccurrence(input, target, false);
        return (firstOccurrence, lastOccurrence);
    }

    private int FindFirstOccurrence(int[] input, int target, bool findFirst)
    {
        var left = 0;
        var right = input.Length - 1;
        var result = -1;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (input[mid] == target)
            {
                result = mid;
                if (findFirst)
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }

            }
            else if (input[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return result;
    }
}