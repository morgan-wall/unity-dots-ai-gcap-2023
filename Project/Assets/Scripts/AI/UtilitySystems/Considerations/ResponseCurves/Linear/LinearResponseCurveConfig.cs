// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using AI.UtilitySystems.Utils;
using Unity.Entities;

namespace AI.UtilitySystems.Considerations.ResponseCurves.Linear
{
    [Serializable]
    public struct LinearResponseCurveConfig : IDeferredAuthor
    {
        // Function: y = m * (x - c) + b
        public float M;
        public float B;
        public float C;
        
        #region IDeferredAuthor

        public void Bake(IBaker baker, Entity entity)
        {
            baker.AddComponent<LinearResponseCurve>(entity, new LinearResponseCurve
            {
                M = M,
                B = B,
                C = C,
            });
        }

        #endregion // IDeferredAuthor
    }
}
