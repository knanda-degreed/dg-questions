namespace DGQuestions;

/*
Top-K Frequent Words
Problem Description:
You are given a large dataset of words. Your goal is to find the top K most frequent words efficiently.
    Input:
words[]: List of words (e.g., ["machine", "learning", "data", "machine", "ai", "data"]).
    k: An integer representing the number of top frequent words to return.
Output:
Return a list of the top K frequent words.
    Example:
Input:
words = ["machine", "learning", "data", "machine", "ai", "data"], k = 2
Output:
["data", "machine"]
*/

// if there is a tie in frequency, the word with the lower alphabetical order comes first
// e.g. apples is in the list twice, but work is in the list twice as well. apples should come first and thus not be in the output
public class TopKFrequentWords : IDegreedSolution
{
    public void Run()
    {
        var result = TopKFrequent(new string[] { "i", "love", "leetcode", "i", "love", "coding", "apples", "apples", "work","work" }, 2);
        Console.WriteLine("Output: [" + string.Join(", ", result) + "]");
    }

    private IEnumerable<string?> TopKFrequent(string[] strings, int i)
    {
        Console.WriteLine("Input: [" + string.Join(", ", strings) + "]");

        if (strings.Length == 0)
        {
            return Array.Empty<string>();
        }

        Dictionary<string, int> frequencyMap = new();
        foreach (var word in strings)
        {
            frequencyMap[word] = frequencyMap.GetValueOrDefault(word, 0) + 1;
        }

        var minHeap = new SortedSet<(int frequency, string word, int tiebreaker)>(Comparer<(int frequency, string word, int tiebreaker)>.Create(
            (a, b) =>
            {
                if (a.frequency != b.frequency) return a.frequency - b.frequency;
                int compareWords =  string.Compare(a.word, b.word, StringComparison.CurrentCultureIgnoreCase);
                return compareWords != 0 ? compareWords : a.tiebreaker.CompareTo(b.tiebreaker);

            }));
        
        if (minHeap == null) throw new ArgumentNullException(nameof(minHeap));

        int tieBreaker = 0;
        foreach (var wordsAndFrequencies in frequencyMap)
        {
            minHeap.Add((wordsAndFrequencies.Value, wordsAndFrequencies.Key, tieBreaker++));

            if (minHeap.Count > i)
            {
                minHeap.Remove(minHeap.Min);
            }
        }

        return minHeap.OrderByDescending(x => x.frequency).ThenBy(x => x.word).Select(x => x.word).ToList();
    }
}