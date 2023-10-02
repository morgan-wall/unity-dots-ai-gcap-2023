// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using AI.UtilitySystems.Considerations.ResponseCurves.Cosine;
using AI.UtilitySystems.Considerations.ResponseCurves.Exponential;
using AI.UtilitySystems.Considerations.ResponseCurves.Linear;
using AI.UtilitySystems.Considerations.ResponseCurves.Logistic;
using AI.UtilitySystems.Considerations.ResponseCurves.Quadratic;
using AI.UtilitySystems.Considerations.ResponseCurves.Sine;
using AI.UtilitySystems.Utils;
using Unity.Entities;

namespace AI.UtilitySystems.Considerations.ResponseCurves
{
    [Serializable]
    public struct ResponseCurveConfig : IDeferredAuthor
    {
        public ResponseCurve ResponseCurve;
        public LinearResponseCurveConfig LinearResponseCurveConfig;
        public QuadraticResponseCurveConfig QuadraticResponseCurveConfig;
        public ExponentialResponseCurveConfig ExponentialResponseCurveConfig;
        public LogisticResponseCurveConfig LogisticResponseCurveConfig;
        public SineResponseCurveConfig SineResponseCurveConfig;
        public CosineResponseCurveConfig CosineResponseCurveConfig;
        
        #region IDeferredAuthor

        public void Bake(IBaker baker, Entity entity)
        {
            switch (ResponseCurve)
            {
                case ResponseCurve.Linear:
                    LinearResponseCurveConfig.Bake(baker, entity);
                    break;
                case ResponseCurve.Quadratic:
                    QuadraticResponseCurveConfig.Bake(baker, entity);
                    break;
                case ResponseCurve.Exponential:
                    ExponentialResponseCurveConfig.Bake(baker, entity);
                    break;
                case ResponseCurve.Logistic:
                    LogisticResponseCurveConfig.Bake(baker, entity);
                    break;
                case ResponseCurve.Sine:
                    SineResponseCurveConfig.Bake(baker, entity);
                    break;
                case ResponseCurve.Cosine:
                    CosineResponseCurveConfig.Bake(baker, entity);
                    break;
                
                
                default:
                    throw new NotImplementedException($"ResponseCurveConfig.Bake: haven't implemented the {ResponseCurve} response curve.");
            }
        }

        #endregion // IDeferredAuthor
    }
}
