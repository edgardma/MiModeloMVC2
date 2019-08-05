using System;
using System.IO;
using Microsoft.ML;

namespace MLNETNetUnitv06
{
    class Program
    {
        private static ITransformer trainedModel;
        private static PredictionEngine<SentimentIssue, SentimentPrediction> predEngine;
        private static MLContext mlContext;
        private static string modelFileName = @"Models\sentimentAnalysis.zip";

        static void Main(string[] args)
        {
            string dirToWatch = GetAbsolutePath("Models");
            var fsw = new FileSystemWatcher(dirToWatch);
            fsw.Changed += FileSystemWatcher_Changed;
            fsw.EnableRaisingEvents = true;

            mlContext = new MLContext(1);
            LoadModel();

            while (true)
            {
                Console.WriteLine("Enter input for analysis. Type [exit] to exit app.");
                string line = Console.ReadLine();
                if (line == "exit") break;
                Predict(line);
                Console.WriteLine("character(s)");
            }

            Console.WriteLine("Hello World!");
        }

        private static void Predict(string text)
        {
            var testSentiment = new SentimentIssue { Text = text };

            var resulPrediction = predEngine.Predict(testSentiment);
            Console.WriteLine($"Text: {testSentiment.Text}");
            Console.WriteLine($" -- Prediction: {(Convert.ToBoolean(resulPrediction.Prediction) ? "Toxic" : "Good")}");
            Console.WriteLine($" -- Probability of being toxic: {resulPrediction.Probability}");
            Console.WriteLine();
        }

        private static void FileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("New model detected!");
            trainedModel = null;
            LoadModel();
        }

        private static void LoadModel()
        {
            mlContext = new MLContext(1);
            trainedModel = mlContext.Model.Load(modelFileName, out var modelInputSchema);
            predEngine = mlContext.Model.CreatePredictionEngine<SentimentIssue, SentimentPrediction>(trainedModel);
        }

        private static string GetAbsolutePath(string relativePath)
        {
            FileInfo dataRoot = new FileInfo(typeof(Program).Assembly.Location);
            string assemblyFolderPath = dataRoot.Directory.FullName;
            string fullPath = Path.Combine(assemblyFolderPath, relativePath);

            return fullPath;
        }
    }
}
