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
    public partial struct MaxAggregatorSystem : ISystem
    {
        public void OnCreate(ref SystemState state) {}
    
        public void OnDestroy(ref SystemState state) {}

        public void OnUpdate(ref SystemState state)
        {
            var job = new MaxAggregatorJob();
            job.ConsiderationLookup = SystemAPI.GetComponentLookup<Consideration>();
            job.ScheduleParallel();
        }
    }
    
    [BurstCompile]
    public partial struct MaxAggregatorJob : IJobEntity
    {
        [ReadOnly]
        public ComponentLookup<Consideration> ConsiderationLookup;
        
        private void Execute(in MaxAggregator aggregator,
            in DynamicBuffer<ConsiderationHandleElement> considerationHandleBuffer, ref OptionEvaluator optionEvaluator)
        {
            bool isFirstOptionEvaluator = true;
            foreach (ConsiderationHandleElement considerationHandleElement in considerationHandleBuffer)
            {
                if (!ConsiderationLookup.HasComponent(considerationHandleElement.Entity))
                {
                    continue;
                }

                RefRO<Consideration> consideration = ConsiderationLookup.GetRefRO(considerationHandleElement.Entity);
                if (isFirstOptionEvaluator
                    || optionEvaluator.Utility < consideration.ValueRO.ResponseCurveOutput)
                {
                    optionEvaluator.Utility = consideration.ValueRO.ResponseCurveOutput;
                }

                isFirstOptionEvaluator = false;
            }
        }
    }
}
