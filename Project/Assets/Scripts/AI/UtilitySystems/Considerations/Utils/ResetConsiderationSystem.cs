// Copyright (c) 2023 Morgan Wall. All rights reserved.

using AI.UtilitySystems.Considerations.Groups;
using Unity.Entities;
using Unity.Burst;

namespace AI.UtilitySystems.Considerations.Utils
{
    [BurstCompile]
    [UpdateInGroup(typeof(ConsiderationInitSystemGroup))]
    public partial struct ResetConsiderationSystem : ISystem
    {
        public void OnCreate(ref SystemState state) {}
    
        public void OnDestroy(ref SystemState state) {}

        public void OnUpdate(ref SystemState state)
        {
            new ResetConsiderationJob().ScheduleParallel();
        }
    }
    
    [BurstCompile]
    public partial struct ResetConsiderationJob : IJobEntity
    {
        private void Execute(ref Consideration consideration)
        {
            consideration.RawInput = 0.0f;
            consideration.NormalizedInput = 0.0f;
            consideration.ResponseCurveOutput = 0.0f;
        }
    }
}
