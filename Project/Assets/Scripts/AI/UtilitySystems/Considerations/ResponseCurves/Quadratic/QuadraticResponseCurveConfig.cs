// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using AI.UtilitySystems.Utils;
using Unity.Entities;

namespace AI.UtilitySystems.Considerations.ResponseCurves.Quadratic
{
    [Serializable]
    public struct QuadraticResponseCurveConfig : IDeferredAuthor
    {
        // Function: y = m * (x - c)^k + b
        public float K;
        public float M;
        public float B;
        public float C;
        
        #region IDeferredAuthor

        public void Bake(IBaker baker, Entity entity)
        {
            baker.AddComponent<QuadraticResponseCurve>(entity, new QuadraticResponseCurve
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
