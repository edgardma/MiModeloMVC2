using System;
using Common;

using Microsoft.ML;
using Microsoft.ML.Data;

namespace MLNETUniv07_ModelEval
{
    class Program
    {
        private static PredictionEngine<SentimentIssue, SentimentPrediction> predEngine;

        private Program() {}

        static void Main(string[] args)
        {
            var mlContext = new MLContext(1);

            var data = mlContext.Data.LoadFromTextFile<SentimentIssue>("Data\\wikiDetoxAnnotated40kRows.tsv", hasHeader: true);

            var trainTestSplit = mlContext.Data.TrainTestSplit(data, testFraction: 0.2);
            var trainingData = trainTestSplit.TrainSet;
            var testData = trainTestSplit.TestSet;

            var dataProcessPipeline = mlContext.Transforms.Text.FeaturizeText("Features", "Text");
            var trainer = mlContext.BinaryClassification.Trainers.SdcaLogisticRegression("Label", "Features");
            var trainingPipeline = dataProcessPipeline.Append(trainer);

            var trainedModel = trainingPipeline.Fit(trainingData);

            var predictions = trainedModel.Transform(testData);
            var metrics = mlContext.BinaryClassification.Evaluate(data: predictions, labelColumnName: "Label", scoreColumnName: "Score");

            ConsoleHelper.PrintBinaryClassificationMetrics(trainer.ToString(), metrics);

            predEngine = mlContext.Model.CreatePredictionEngine<SentimentIssue, SentimentPrediction>(trainedModel);
            Predict("This is not a good movie");
            Predict("I hate this move");

            Console.ReadLine();
        }

        private static void Predict(string text)
        {
            var testSentiment = new SentimentIssue { Text = text };
            var resultPrediction = predEngine.Predict(testSentiment);
            Console.WriteLine($"Text: {testSentiment.Text}");
            Console.WriteLine($"  -- Prediction: {(Convert.ToBoolean(resultPrediction.Prediction) ? "Toxic" : "Good")}");
            Console.WriteLine($"  -- Probability of being toxic: {resultPrediction.Probability}");
            Console.WriteLine();
        }
    }
}
