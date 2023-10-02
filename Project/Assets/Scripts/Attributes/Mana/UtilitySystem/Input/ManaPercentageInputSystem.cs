// Copyright (c) 2023 Morgan Wall. All rights reserved.

using AI.Agents;
using AI.UtilitySystems.Considerations;
using AI.UtilitySystems.Considerations.Groups;
using Unity.Entities;
using Unity.Burst;
using Unity.Collections;

namespace Attributes.Mana.UtilitySystem.Input
{
    [BurstCompile]
    [UpdateInGroup(typeof(ConsiderationInputSystemGroup))]
    public partial struct PercentageManaInputSystem : ISystem
    {
        public void OnCreate(ref SystemState state) {}
    
        public void OnDestroy(ref SystemState state) {}

        public void OnUpdate(ref SystemState state)
        {
            var job = new PercentageManaInputJob();
            job.ManaLookup = SystemAPI.GetComponentLookup<Mana>();
            job.ScheduleParallel();
        }
    }
    
    [BurstCompile]
    public partial struct PercentageManaInputJob : IJobEntity
    {
        [ReadOnly]
        public ComponentLookup<Mana> ManaLookup;
        
        private void Execute(in AgentHandle agentHandle, in ManaPercentageInput input, ref Consideration consideration)
        {
            if (!ManaLookup.HasComponent(agentHandle.Entity))
            {
                return;
            }

            RefRO<Mana> mana = ManaLookup.GetRefRO(agentHandle.Entity);
            consideration.RawInput = mana.ValueRO.CurrentValue / mana.ValueRO.MaxValue;
        }
    }
}
