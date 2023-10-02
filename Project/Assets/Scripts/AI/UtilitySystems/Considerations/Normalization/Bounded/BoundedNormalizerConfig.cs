// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using AI.UtilitySystems.Utils;
using Unity.Entities;

namespace AI.UtilitySystems.Considerations.Normalization.Bounded
{
    [Serializable]
    public struct BoundedNormalizerConfig : IDeferredAuthor
    {
        public float Min;
        public float Max;
        
        #region IDeferredAuthor

        public void Bake(IBaker baker, Entity entity)
        {
            baker.AddComponent<BoundedNormalizer>(entity, new BoundedNormalizer
            {
                MinValue = Min,
                MaxValue = Max,
            });
        }

        #endregion // IDeferredAuthor
    }
}
