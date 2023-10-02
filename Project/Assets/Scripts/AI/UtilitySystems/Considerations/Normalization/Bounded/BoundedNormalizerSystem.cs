// Copyright (c) 2023 Morgan Wall. All rights reserved.

using AI.UtilitySystems.Considerations.Groups;
using Unity.Entities;
using Unity.Burst;
using Unity.Mathematics;

namespace AI.UtilitySystems.Considerations.Normalization.Bounded
{
    [BurstCompile]
    [UpdateInGroup(typeof(ConsiderationNormalizationSystemGroup))]
    public partial struct BoundedNormalizerSystem : ISystem
    {
        public void OnCreate(ref SystemState state) {}
    
        public void OnDestroy(ref SystemState state) {}

        public void OnUpdate(ref SystemState state)
        {
            new BoundedNormalizerJob().ScheduleParallel();
        }
    }
    
    [BurstCompile]
    public partial struct BoundedNormalizerJob : IJobEntity
    {
        private void Execute(in BoundedNormalizer normalizer, ref Consideration consideration)
        {
            float boundedInput = math.clamp(consideration.RawInput, normalizer.MinValue, normalizer.MaxValue);
            consideration.NormalizedInput = (boundedInput - normalizer.MinValue) / (normalizer.MaxValue - normalizer.MinValue);
        }
    }
}
