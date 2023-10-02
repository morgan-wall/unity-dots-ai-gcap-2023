// Copyright (c) 2023 Morgan Wall. All rights reserved.

using AI.Agents;
using AI.UtilitySystems.Considerations;
using AI.UtilitySystems.Considerations.Groups;
using Unity.Entities;
using Unity.Burst;
using Unity.Collections;

namespace Attributes.Health.UtilitySystem.Input
{
    [BurstCompile]
    [UpdateInGroup(typeof(ConsiderationInputSystemGroup))]
    public partial struct PercentageHealthInputSystem : ISystem
    {
        public void OnCreate(ref SystemState state) {}
    
        public void OnDestroy(ref SystemState state) {}

        public void OnUpdate(ref SystemState state)
        {
            var job = new PercentageHealthInputJob();
            job.HealthLookup = SystemAPI.GetComponentLookup<Health>();
            job.ScheduleParallel();
        }
    }
    
    [BurstCompile]
    public partial struct PercentageHealthInputJob : IJobEntity
    {
        [ReadOnly]
        public ComponentLookup<Health> HealthLookup;
        
        private void Execute(in AgentHandle agentHandle, in HealthPercentageInput input, ref Consideration consideration)
        {
            if (!HealthLookup.HasComponent(agentHandle.Entity))
            {
                return;
            }

            RefRO<Health> health = HealthLookup.GetRefRO(agentHandle.Entity);
            consideration.RawInput = health.ValueRO.CurrentValue / health.ValueRO.MaxValue;
        }
    }
}
