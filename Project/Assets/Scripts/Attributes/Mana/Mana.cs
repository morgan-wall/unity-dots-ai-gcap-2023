// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;

namespace Attributes.Mana
{
    public struct Mana : IComponentData
    {
        public float CurrentValue;
        public float MaxValue;
    }
}
