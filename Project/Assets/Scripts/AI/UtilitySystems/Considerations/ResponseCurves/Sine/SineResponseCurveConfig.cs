// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using AI.UtilitySystems.Utils;
using Unity.Entities;

namespace AI.UtilitySystems.Considerations.ResponseCurves.Sine
{
    [Serializable]
    public struct SineResponseCurveConfig : IDeferredAuthor
    {
        // Function: y = k * sin(m * (x - c)) + b
        public float K;
        public float M;
        public float B;
        public float C;
        
        #region IDeferredAuthor

        public void Bake(IBaker baker, Entity entity)
        {
            baker.AddComponent<SineResponseCurve>(entity, new SineResponseCurve
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
