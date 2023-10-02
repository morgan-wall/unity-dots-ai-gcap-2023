// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using AI.UtilitySystems.Utils;
using Unity.Entities;

namespace AI.UtilitySystems.Considerations.ResponseCurves.Cosine
{
    [Serializable]
    public struct CosineResponseCurveConfig : IDeferredAuthor
    {
        // Function: y = k * cos(m * (x - c)) + b
        public float K;
        public float M;
        public float B;
        public float C;
        
        #region IDeferredAuthor

        public void Bake(IBaker baker, Entity entity)
        {
            baker.AddComponent<CosineResponseCurve>(entity, new CosineResponseCurve
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
