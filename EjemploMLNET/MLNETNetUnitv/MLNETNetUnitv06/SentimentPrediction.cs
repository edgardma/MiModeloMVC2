using System;

using Microsoft.ML.Data;

namespace MLNETNetUnitv06
{
    public class SentimentPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool Prediction { get; set; }

        public float Probability { get; set; }

        public float Score { get; set; }
    }
}
