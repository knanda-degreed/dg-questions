namespace DGQuestions;

/*Optimizing Real-Time Anomaly Detection in High-Dimensional Data Streams
Problem Description:
You are tasked with designing an efficient algorithm to detect anomalies in high-dimensional sensor data streams in real-time. The system receives data from m sensors every second. Your goal is to flag anomalies based on unusual patterns detected across all sensors simultaneously using statistical measures like Mahalanobis distance.
    Input:
streams[]: A list of real-time readings where each element is a list of m sensor readings.
    n: The size of the sliding window (in seconds).
    threshold: A Mahalanobis distance threshold for anomaly detection.
    Output:
Return a list of boolean values, where each value indicates whether the corresponding second's data is an anomaly or not.
Example:
Input:
streams = [
    [1.0, 2.1, 1.5],
    [1.2, 2.0, 1.7],
    [5.0, 8.0, 3.0],
    [1.1, 2.1, 1.6],
    [1.3, 2.2, 1.8]
], n = 3, threshold = 5.0
Output:
[False, False, True, False, False]
Explanation: The third set of sensor readings (5.0, 8.0, 3.0) deviates significantly from the previous readings, so it is flagged as an anomaly.
*/
public class OptimizingRealTimeAnomalyDetection: IDegreedSolution
{
    public void Run()
    {
        var input = new List<List<double>>()
        {
            new() {1.0, 2.1, 1.5},
            new() {1.2, 2.0, 1.7},
            new() {5.0, 8.0, 3.0},
            new() {1.1, 2.1, 1.6},
            new() {1.3, 2.2, 1.8},
            new() {1.0, 2.1, 1.5}
        };
        
        List<bool> output = DetectAnomalies(input, 2, 3.0);
        Console.WriteLine("Output: [" + string.Join(", ", output) + "]");
    }
    
    // Main method to detect anomalies in real-time data
    public List<bool> DetectAnomalies(List<List<double>> streams, int n, double threshold)
    {
        int m = streams[0].Count; // number of sensors
        List<bool> result = new List<bool>();
        Queue<List<double>> window = new Queue<List<double>>();

        for (int i = 0; i < streams.Count; i++)
        {
            // Add current reading to the sliding window
            window.Enqueue(streams[i]);

            // Maintain window size
            if (window.Count > n)
            {
                window.Dequeue();
            }

            // Initially mark entries as normal until window fills up
            if (i < n - 1)
            {
                result.Add(false);
                continue;
            }

            // Calculate the mean vector and covariance matrix for the current window
            var mean = CalculateMean(window, m);
            var covariance = CalculateCovariance(window, mean, m);

            // Calculate Mahalanobis distance for the current reading
            double distance = CalculateMahalanobisDistance(streams[i], mean, covariance);

            // Flag as anomaly if distance exceeds threshold
            result.Add(distance > threshold);
        }

        return result;
    }

    // Helper function to calculate mean vector
    private List<double> CalculateMean(Queue<List<double>> window, int m)
    {
        List<double> mean = new List<double>(new double[m]);
        foreach (var reading in window)
        {
            for (int j = 0; j < m; j++)
            {
                mean[j] += reading[j];
            }
        }
        for (int j = 0; j < m; j++)
        {
            mean[j] /= window.Count;
        }
        return mean;
    }

    // Helper function to calculate covariance matrix
    private double[,] CalculateCovariance(Queue<List<double>> window, List<double> mean, int m)
    {
        double[,] covariance = new double[m, m];
        foreach (var reading in window)
        {
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    covariance[i, j] += (reading[i] - mean[i]) * (reading[j] - mean[j]);
                }
            }
        }
        int count = window.Count - 1; // Use unbiased estimator
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < m; j++)
            {
                covariance[i, j] /= count;
            }
        }
        return covariance;
    }

    // Helper function to calculate Mahalanobis distance
    private double CalculateMahalanobisDistance(List<double> reading, List<double> mean, double[,] covariance)
    {
        int m = reading.Count;
        double[] diff = new double[m];
        for (int i = 0; i < m; i++)
        {
            diff[i] = reading[i] - mean[i];
        }

        // Invert the covariance matrix (requires a more sophisticated approach in real cases)
        double[,] covarianceInv = InvertMatrix(covariance, m);

        // Calculate Mahalanobis distance
        double sum = 0.0;
        for (int i = 0; i < m; i++)
        {
            double rowSum = 0.0;
            for (int j = 0; j < m; j++)
            {
                rowSum += diff[j] * covarianceInv[j, i];
            }
            sum += rowSum * diff[i];
        }

        return Math.Sqrt(sum);
    }

    // Dummy function for matrix inversion (placeholder, requires actual implementation)
    private double[,] InvertMatrix(double[,] matrix, int m)
    {
        // Inverting a matrix is complex; here you would use a library or implement matrix inversion
        // Placeholder for now, assume identity matrix
        double[,] identity = new double[m, m];
        for (int i = 0; i < m; i++)
        {
            identity[i, i] = 1.0;
        }
        return identity;
    }
}