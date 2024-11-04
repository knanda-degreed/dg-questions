namespace DGQuestions;

/*
Coin Change
Problem Description:
You are given an integer array of coins representing different denominations of coins, and an integer amount. The task is to return the fewest number of coins needed to make up that amount. If it's impossible to make the amount, return -1.
    Input:
coins[]: An array of integers representing the coin denominations.
    amount: An integer representing the target amount.
    Output:
Return the fewest number of coins needed, or -1 if it's impossible.
    Example:
Input:
coins = [1, 2, 5], amount = 11
Output:
3
Explanation: 11 can be made with three coins: 5 + 5 + 1.
    Input:
coins = [2], amount = 3
Output:
-1
Explanation: There's no way to sum to 3 with just coin denominations of 2.
*/

public class CoinChange : IDegreedSolution
{
    public void Run()
    {
        var input = new[] { 1, 2, 5 };
        var amount = 11;
        Console.WriteLine($"Input: coins = [{string.Join(",", input)}], amount = {amount}");
        Console.WriteLine(GetMinCoins(input, amount));
    }

    private int GetMinCoins(int[] coins, int amount)
    {
        // Step 1: Initialize dp array with a large value (amount + 1) to represent "infinity"
        int[] dp = new int[amount + 1];
        Array.Fill(dp, amount + 1);
        dp[0] = 0; // Base case: zero coins are needed to make amount 0

        // Step 2: Fill the dp array
        foreach (var coin in coins)
        {
            for (int i = coin; i <= amount; i++)
            {
                dp[i] = Math.Min(dp[i], dp[i - coin] + 1);
            }
        }

        // Step 3: Check the result
        return dp[amount] > amount ? -1 : dp[amount];
    }
}