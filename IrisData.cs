using System;
using Microsoft.ML.Runtime.Api;

/// <summary>
/// 花样本
/// </summary>
public class IrisData
        {
            /// <summary>
            /// 萼片长度
            /// </summary>
            [Column("0")]
            public float SepalLength;
            [Column("1")]
            /// <summary>
            /// 萼片宽度
            /// </summary>
            public float SepalWidth;
            /// <summary>
            /// 花瓣长度
            /// </summary>
            [Column("2")]
            public float PetalLength;
            /// <summary>
            /// 花瓣宽度
            /// </summary>
            [Column("3")]
            public float PetalWidth;
            /// <summary>
            /// 品种
            /// </summary>
            [Column("4")]
            [ColumnName("Label")]
            public String Label;
        }
