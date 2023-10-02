// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using AI.UtilitySystems.Considerations.Normalization.Bounded;
using AI.UtilitySystems.Utils;
using Unity.Entities;

namespace AI.UtilitySystems.Considerations.Normalization
{
    [Serializable]
    public struct NormalizerConfig : IDeferredAuthor
    {
        public Normalizer Normalizer;
        public BoundedNormalizerConfig BoundedNormalizerConfig;
        
        #region IDeferredAuthor

        public void Bake(IBaker baker, Entity entity)
        {
            switch (Normalizer)
            {
                case Normalizer.Bounded:
                    BoundedNormalizerConfig.Bake(baker, entity);
                    break;
                
                default:
                    throw new NotImplementedException($"NormalizerConfig.Bake: haven't implemented the {Normalizer} normalizer.");
            }
        }

        #endregion // IDeferredAuthor
    }
}
