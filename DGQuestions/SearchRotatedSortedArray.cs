namespace DGQuestions;

/*
Search in Rotated Sorted Array
Problem Description:
You are given a rotated sorted array and a target value. The task is to search for the target in this array and return its index. If the target is not found, return -1. The array is initially sorted in ascending order but has been rotated at some unknown pivot.
Input:
nums[]: A rotated sorted array.
    target: An integer representing the target value to search.
    Output:
Return the index of the target or -1 if not found.
    Example:
Input:
nums = [4,5,6,7,0,1,2], target = 0
Output:
4
Input:
nums = [4,5,6,7,0,1,2], target = 3
Output:
-1
Explanation: Target 3 is not present in the array.
*/
public class SearchRotatedSortedArray: IDegreedSolution
{
    public void Run()
    {
        var input = new[] { 4, 5, 6, 7, 0, 1, 2 };
        var target = 0;
        Console.WriteLine($"Input: nums = [{string.Join(",", input)}], target = {target}");
        Console.WriteLine(Search(input, target));
    }

    private int Search(int[] input, int target)
    {
        var left = 0;
        var right = input.Length - 1;
        while (left <= right)
        {
            var mid = left + (right - left) / 2;
            if (input[mid] == target)
            {
                return mid;
            }

            // left half sorted
            if (input[left] <= input[mid])
            {
                if (input[left] <= target && target < input[mid])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            // right half sorted
            else
            {
                if (input[mid] < target && target <= input[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
        }

        return -1;
    }
}