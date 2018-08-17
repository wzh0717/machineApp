using System;
using Microsoft.ML.Runtime.Api;
/// <summary>
/// 花预测结果
/// </summary>
public class IrisPrediction
        {
            [ColumnName("PredictedLabel")]
            public String PredictedLabels;
        }