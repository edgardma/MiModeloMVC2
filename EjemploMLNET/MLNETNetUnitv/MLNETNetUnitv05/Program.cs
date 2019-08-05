using System;

using Microsoft.ML;

namespace MLNETNetUnitv05
{
    class Program
    {
        static void Main(string[] args)
        {
            var mlContext = new MLContext(1);

            // Entrenar un modelo
            var data = mlContext.Data.LoadFromTextFile<SentimentIssue>("Data\\wikiDetoxAnnotated40kRows.tsv", hasHeader: true);
            var dataProcessPipeline = mlContext.Transforms.Text.FeaturizeText("Features", "Text");
            var trainer = mlContext.BinaryClassification.Trainers.SdcaLogisticRegression("Label", "Features");
            var trainingPipeline = dataProcessPipeline.Append(trainer);
            var trainedModel = trainingPipeline.Fit(data);

            // Grabar un modelo entrenado 
            // mlContext.Model.Save(trainedModel, data.Schema, "Data\\sentimentAnalysis.zip");
            
            // Si ya un modelo entrenado, la siguiente linea se usaría
            // var trainedModel = mlContext.Model.Load("Data\\sentimentAnalysis.zip", out var modelInputSchema);

            var predEngine = mlContext.Model.CreatePredictionEngine<SentimentIssue, SentimentPrediction>(trainedModel);
            Predict("This is not a good movie.", predEngine);
            Predict("I hate this movie.", predEngine);
            Predict("This vaccum is amazing.", predEngine);
            Predict("This vacuum sucks a lot.", predEngine);

            Console.ReadLine();
        }

        public static void Predict(string text, PredictionEngine<SentimentIssue, SentimentPrediction> predEngine)
        {
            var testSentiment = new SentimentIssue { Text = text };

            var resultPrediction = predEngine.Predict(testSentiment);
            Console.WriteLine($"Text: {testSentiment.Text} | Prediction: {(Convert.ToBoolean(resultPrediction.Prediction) ? "Toxic sentiment" : "Good sentiment")} | Probability of being toxic: {resultPrediction.Probability}");
        }
    }
}
