using System;
using Microsoft.ML;
using Microsoft.ML.Runtime.Api;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
using Microsoft.ML.Data;


namespace machineApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建管道
            var pipeline = new LearningPipeline();
            //载入样本
            String dataPath = "iris-data.txt";
            pipeline.Add(new TextLoader(dataPath).CreateFrom<IrisData>(separator: ','));
            //转换数据
            pipeline.Add(new Dictionarizer("Label"));
            //加入特征向量
            pipeline.Add(new ColumnConcatenator("Features", "SepalLength", "SepalWidth", "PetalLength", "PetalWidth"));
            //添加分类器算法
            pipeline.Add(new StochasticDualCoordinateAscentClassifier());
            pipeline.Add(new PredictedLabelColumnOriginalValueConverter() { PredictedLabelColumn = "PredictedLabel" });
            //训练模型
            var model = pipeline.Train<IrisData, IrisPrediction>();
            //使用训练好的模型来预测结果
            var prediction = model.Predict(new IrisData()
            {
                SepalLength = 3.3f,
                SepalWidth = 2.6f,
                PetalLength = 1.2f,
                PetalWidth = 5.1f,
            });


            Console.WriteLine($"Predicted flower type is: {prediction.PredictedLabels}");
        }
    }
}
