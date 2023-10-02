// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;

namespace Attributes.Health
{
    public struct HealthRandomizer : IComponentData
    {
        public double NextRandomizationTime;
        public double TimeBetweenRandomizations;
        public uint RandomSeed;
    }
}
