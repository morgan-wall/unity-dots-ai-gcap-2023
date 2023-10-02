// Copyright (c) 2023 Morgan Wall. All rights reserved.

using AI.UtilitySystems.Options.Groups;
using Unity.Entities;
using Unity.Burst;

namespace AI.UtilitySystems.Options.Utils
{
    [BurstCompile]
    [UpdateInGroup(typeof(OptionInitSystemGroup))]
    public partial struct ResetOptionEvaluatorSystem : ISystem
    {
        public void OnCreate(ref SystemState state) {}
    
        public void OnDestroy(ref SystemState state) {}

        public void OnUpdate(ref SystemState state)
        {
            new ResetOptionEvaluatorJob().ScheduleParallel();
        }
    }
    
    [BurstCompile]
    public partial struct ResetOptionEvaluatorJob : IJobEntity
    {
        private void Execute(ref OptionEvaluator optionEvaluator)
        {
            optionEvaluator.Utility = 0.0f;
        }
    }
}
