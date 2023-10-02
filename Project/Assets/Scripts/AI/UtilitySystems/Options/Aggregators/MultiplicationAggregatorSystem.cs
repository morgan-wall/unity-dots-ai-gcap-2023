// Copyright (c) 2023 Morgan Wall. All rights reserved.

using AI.UtilitySystems.Options.Groups;
using AI.UtilitySystems.Considerations;
using Unity.Entities;
using Unity.Burst;
using Unity.Collections;

namespace AI.UtilitySystems.Options.Aggregators
{
    [BurstCompile]
    [UpdateInGroup(typeof(OptionConsiderationAggregationSystemGroup))]
    public partial struct MultiplicationAggregatorSystem : ISystem
    {
        public void OnCreate(ref SystemState state) {}
    
        public void OnDestroy(ref SystemState state) {}

        public void OnUpdate(ref SystemState state)
        {
            var job = new MultiplicationAggregatorJob();
            job.ConsiderationLookup = SystemAPI.GetComponentLookup<Consideration>();
            job.ScheduleParallel();
        }
    }
    
    [BurstCompile]
    public partial struct MultiplicationAggregatorJob : IJobEntity
    {
        private const float MinUtility = 0.0f;
        private const float MaxUtility = 1.0f;
        
        [ReadOnly]
        public ComponentLookup<Consideration> ConsiderationLookup;
        
        private void Execute(in MultiplicationAggregator aggregator,
            in DynamicBuffer<ConsiderationHandleElement> considerationHandleBuffer, ref OptionEvaluator optionEvaluator)
        {
            optionEvaluator.Utility = MinUtility;
            if (considerationHandleBuffer.IsEmpty)
            {
                return;
            }
            
            optionEvaluator.Utility = MaxUtility;
            foreach (ConsiderationHandleElement considerationHandleElement in considerationHandleBuffer)
            {
                if (!ConsiderationLookup.HasComponent(considerationHandleElement.Entity))
                {
                    continue;
                }

                RefRO<Consideration> consideration = ConsiderationLookup.GetRefRO(considerationHandleElement.Entity);
                optionEvaluator.Utility *= consideration.ValueRO.ResponseCurveOutput;
            }
        }
    }
}
