// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;

namespace AI.UtilitySystems.Considerations.Normalization.Bounded
{
    public struct BoundedNormalizer : IComponentData
    {
        public float MinValue;
        public float MaxValue;
    }
}
