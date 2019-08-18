using System;
using System.IO;
using Common;
using Microsoft.ML;

namespace MLNETUniv08_OnnxExport
{
    class Program
    {
        private static PredictionEngine<SentimentIssue, SentimentPrediction> predEngine;

        static void Main(string[] args)
        {
            var mlContext = new MLContext(1);

            var data = mlContext.Data.LoadFromTextFile<SentimentIssue>("Data\\wikiDetoxAnnotated40kRows.tsv", hasHeader: true);

            // Split data 80 / 20
            var trainTestSplit = mlContext.Data.TrainTestSplit(data, testFraction: 0.2);
            var trainingData = trainTestSplit.TrainSet;
            var testData = trainTestSplit.TestSet;

            var dataProcessPipeline = mlContext.Transforms.Text.FeaturizeText("Features", "Text");
            var trainer = mlContext.BinaryClassification.Trainers.SdcaLogisticRegression("Label", "Features");
            var trainingPipeline = dataProcessPipeline.Append(trainer);

            // Train using training data
            var trainedModel = trainingPipeline.Fit(trainingData);

            // Eval
            var predictions = trainedModel.Transform(testData);
            var metrics = mlContext.BinaryClassification.Evaluate(data: predictions, labelColumnName: "Label", scoreColumnName: "Score");

            ConsoleHelper.PrintBinaryClassificationMetrics(trainer.ToString(), metrics);

            var modelPath = GetAbsolutePath("Data\\sentimentAnalysis.onnx");
            using (var file = File.Create(modelPath))
                mlContext.Model.ConvertToOnnx(trainedModel, trainingData, file);
            var onnxEstimator = mlContext.Transforms.ApplyOnnxModel(modelPath)
                .Append(mlContext.Transforms.CopyColumns("Score", "Score0"));
            var onnxModel = onnxEstimator.Fit(trainingData);

            var originalPredictionEngine = mlContext.Model.CreatePredictionEngine<SentimentIssue, SentimentPrediction>(trainedModel);
            var onnxPredictionEngine = mlContext.Model.CreatePredictionEngine<SentimentIssue, SentimentPrediction>(onnxModel);

            predEngine = originalPredictionEngine;
            Predict("This is not a good movie");
            Predict("I hate this movie");

            predEngine = onnxPredictionEngine;
            Predict("This is not a good movie");
            Predict("I hate this movie");

            Console.ReadLine();
        }

        private static void Predict(string text)
        {
            var testSentiment = new SentimentIssue { Text = text };
            var resultPrediction = predEngine.Predict(testSentiment);
            Console.WriteLine($"Text: {testSentiment.Text}");
            Console.WriteLine($"  -- Prediction: {(Convert.ToBoolean(resultPrediction.Prediction) ? "Toxic" : "Good")}");
            Console.WriteLine($"  -- Probability of being toxic: {resultPrediction.Probability} ");
            Console.WriteLine();
        }

        private static string GetAbsolutePath(string relativePath)
        {
            var dataRoot = new FileInfo(typeof(Program).Assembly.Location);
            string assemblyFolderPath = dataRoot.Directory.FullName;
            string fullPath = Path.Combine(assemblyFolderPath, relativePath);
            return fullPath;
        }
    }
}
