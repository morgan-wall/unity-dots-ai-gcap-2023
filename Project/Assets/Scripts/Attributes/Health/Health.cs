// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;

namespace Attributes.Health
{
    public struct Health : IComponentData
    {
        public float CurrentValue;
        public float MaxValue;
    }
}
