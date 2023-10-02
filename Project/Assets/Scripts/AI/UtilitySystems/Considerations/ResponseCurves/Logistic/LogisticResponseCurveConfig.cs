// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using AI.UtilitySystems.Utils;
using Unity.Entities;

namespace AI.UtilitySystems.Considerations.ResponseCurves.Logistic
{
    [Serializable]
    public struct LogisticResponseCurveConfig : IDeferredAuthor
    {
        // Function: y = k / (1 + (1000 * e * m)^(-x + c)) + b
        public float K;
        public float M;
        public float B;
        public float C;
        
        #region IDeferredAuthor

        public void Bake(IBaker baker, Entity entity)
        {
            baker.AddComponent<LogisticResponseCurve>(entity, new LogisticResponseCurve
            {
                K = K,
                M = M,
                B = B,
                C = C,
            });
        }

        #endregion // IDeferredAuthor
    }
}
