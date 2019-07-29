using System;
using System.IO;
using Microsoft.ML;
using Microsoft.ML.Data;

using MLNetDemo011.Shared;

namespace MLNETNetUnitv03
{
    class Program
    {
        static readonly string TrainDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "AgeRangeData03.csv");

        static void Main(string[] args)
        {
            var ml = new MLContext(1);

            // 1er Paso: Obtener los datos
            var data = ml.Data.LoadFromTextFile<AgeRange>(TrainDataPath, hasHeader: true, separatorChar: ',');

            // 2do Paso: Entrenamiento (Edad y genero)
            var pipeline = ml.Transforms.Conversion.MapValueToKey("Label")
                .Append(ml.Transforms.Text.FeaturizeText("GenderFeat", "Gender"))
                .Append(ml.Transforms.Concatenate("Features", "Age", "GenderFeat"))
                .AppendCacheCheckpoint(ml)
                .Append(ml.MulticlassClassification.Trainers.SdcaMaximumEntropy("Label", "Features"))
                .Append(ml.Transforms.Conversion.MapKeyToValue("PredictedLabel"));

            var model = pipeline.Fit(data);
            Console.WriteLine("Entrenando modelo");

            // 3er Paso: Utilizar el modelo
            var engine = ml.Model.CreatePredictionEngine<AgeRange, AgeRangePrediction>(model);

            PredictSimple("Jeff", 2, "M", engine);
            PredictSimple("Shelley", 9, "F", engine);
            PredictSimple("Jackie", 3, "F", engine);
            PredictSimple("Jim", 5, "M", engine);
            PredictSimple("T1", 8, "F", engine);
            PredictSimple("T2", 1, "F", engine);
            PredictSimple("T3", 13, "M", engine);
            PredictSimple("T4", 15, "F", engine);
            PredictSimple("T5", 48, "F", engine);
            PredictSimple("T6", 35, "F", engine);
            PredictSimple("T7", 22, "M", engine);
            PredictSimple("T8", 19, "F", engine);

            Console.ReadLine();
        }

        private static void PredictSimple(string name, float age, string gender, 
            PredictionEngine<AgeRange, AgeRangePrediction> predictionFunction)
        {
            var example = new AgeRange()
            {
                Age = age,
                Name = name,
                Gender = gender
            };
            var prediction = predictionFunction.Predict(example);
            Console.WriteLine($"Name: {example.Name}\t Age: {example.Age:00}\t " +
                $"Gender: {example.Gender}\t >> " + 
                $"Predicted Label: {prediction.Label}");
        }

        private Program()
        {

        }
    }
}
