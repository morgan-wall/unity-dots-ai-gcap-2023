// Copyright (c) 2023 Morgan Wall. All rights reserved.

using AI.UtilitySystems.Decisions.Groups;
using AI.UtilitySystems.Options;
using Unity.Entities;
using Unity.Burst;
using Unity.Collections;

namespace AI.UtilitySystems.Decisions.Selectors
{
    [BurstCompile]
    [UpdateInGroup(typeof(DecisionSelectorSystemGroup))]
    public partial struct HighestUtilitySelectorSystem : ISystem
    {
        public void OnCreate(ref SystemState state) {}
    
        public void OnDestroy(ref SystemState state) {}

        public void OnUpdate(ref SystemState state)
        {
            var job = new HighestUtilitySelectorJob();
            job.OptionEvaluatorLookup = SystemAPI.GetComponentLookup<OptionEvaluator>();
            job.ScheduleParallel();
        }
    }
    
    [BurstCompile]
    public partial struct HighestUtilitySelectorJob : IJobEntity
    {
        [ReadOnly]
        public ComponentLookup<OptionEvaluator> OptionEvaluatorLookup;
        
        private void Execute(in HighestUtilitySelector selector,
            in DynamicBuffer<OptionEvaluatorHandleElement> optionEvaluatorHandleBuffer, ref Decision decision)
        {
            bool isFirstOptionEvaluator = true;
            foreach (OptionEvaluatorHandleElement optionEvaluatorHandleElement in optionEvaluatorHandleBuffer)
            {
                if (!OptionEvaluatorLookup.HasComponent(optionEvaluatorHandleElement.Entity))
                {
                    continue;
                }

                RefRO<OptionEvaluator> optionEvaluator = OptionEvaluatorLookup.GetRefRO(optionEvaluatorHandleElement.Entity);
                if (isFirstOptionEvaluator
                    || decision.UtilityOfSelection < optionEvaluator.ValueRO.Utility)
                {
                    decision.SelectedOptionKey = optionEvaluator.ValueRO.OptionKey;
                    decision.UtilityOfSelection = optionEvaluator.ValueRO.Utility;
                }
                
                isFirstOptionEvaluator = false;
            }
        }
    }
}
