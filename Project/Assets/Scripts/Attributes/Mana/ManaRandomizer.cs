// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;

namespace Attributes.Mana
{
    public struct ManaRandomizer : IComponentData
    {
        public double NextRandomizationTime;
        public double TimeBetweenRandomizations;
        public uint RandomSeed;
    }
}
