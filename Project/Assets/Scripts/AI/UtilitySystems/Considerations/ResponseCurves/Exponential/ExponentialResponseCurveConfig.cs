// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using AI.UtilitySystems.Utils;
using Unity.Entities;

namespace AI.UtilitySystems.Considerations.ResponseCurves.Exponential
{
    [Serializable]
    public struct ExponentialResponseCurveConfig : IDeferredAuthor
    {
        // Function: y = m^(k * (x - c)) + b
        public float K;
        public float M;
        public float B;
        public float C;
        
        #region IDeferredAuthor

        public void Bake(IBaker baker, Entity entity)
        {
            baker.AddComponent<ExponentialResponseCurve>(entity, new ExponentialResponseCurve
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
