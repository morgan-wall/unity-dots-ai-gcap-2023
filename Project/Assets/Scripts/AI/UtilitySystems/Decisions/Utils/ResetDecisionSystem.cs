// Copyright (c) 2023 Morgan Wall. All rights reserved.

using AI.UtilitySystems.Decisions.Groups;
using Unity.Entities;
using Unity.Burst;

namespace AI.UtilitySystems.Decisions.Utils
{
    [BurstCompile]
    [UpdateInGroup(typeof(DecisionInitSystemGroup))]
    public partial struct ResetDecisionSystem : ISystem
    {
        public void OnCreate(ref SystemState state) {}
    
        public void OnDestroy(ref SystemState state) {}

        public void OnUpdate(ref SystemState state)
        {
            new ResetDecisionJob().ScheduleParallel();
        }
    }
    
    [BurstCompile]
    public partial struct ResetDecisionJob : IJobEntity
    {
        private void Execute(ref Decision decision)
        {
            decision.SelectedOptionKey = -1;
            decision.UtilityOfSelection = float.MinValue;
        }
    }
}
