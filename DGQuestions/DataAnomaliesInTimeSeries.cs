namespace DGQuestions;

/*
Detect Anomalies in Time Series Data
Problem Description:
You are given a series of real-time sensor readings from a machine. Your goal is to detect anomalies based on whether a sensor reading deviates by more than a fixed percentage (e.g., 20%) from the average of the previous n readings.
Input:
readings[]: A list of floating-point numbers representing the sensor readings over time.
    n: The size of the sliding window to compute the average.
    threshold: A percentage value that defines the anomaly threshold.
    Output:
Return a list of boolean values of the same length as readings[], where True indicates that the reading is an anomaly, and False indicates that it is normal.
    Example:
Input:
readings = [10, 12, 12, 11, 14, 50, 10, 11, 15, 25, 12, 10], n = 5, threshold = 20
Output:
[False, False, False, False, False, True, False, False, False, True, False, False]
*/

public class DataAnomaliesInTimeSeries : IDegreedSolution
{
    public void Run()
    {
        DetectAnomalies(new double[] { 10, 12, 12, 11, 14, 50, 10, 11, 15, 25, 12, 10 }, 5, 20);
    }

    private void DetectAnomalies(double[] inputArr, int windowSize, int threshold)
    {
        if (inputArr.Length == 0)
        {
            return;
        }

        var result = new bool[inputArr.Length];
        var windowSum = 0.0;

        for (int i = 0; i < inputArr.Length; i++)
        {
            // calculate windowsum as we iterate through the array
            windowSum += inputArr[i];
            if (i >= windowSize)
            {
                windowSum -= inputArr[i - windowSize];   
            }
            var average = windowSum / Math.Min(i + 1, windowSize);
            if (average != 0 && Math.Abs(inputArr[i] - average) / average * 100 > threshold)
            {
                result[i] = true;
            }
        }
        
        Console.WriteLine("Output:");
        Console.WriteLine("[" + string.Join(", ", result) + "]");
    }
}