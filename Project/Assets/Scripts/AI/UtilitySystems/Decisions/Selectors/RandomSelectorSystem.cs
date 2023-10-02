// Copyright (c) 2023 Morgan Wall. All rights reserved.

using AI.UtilitySystems.Decisions.Groups;
using AI.UtilitySystems.Options;
using Unity.Entities;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;

namespace AI.UtilitySystems.Decisions.Selectors
{
    [BurstCompile]
    [UpdateInGroup(typeof(DecisionSelectorSystemGroup))]
    public partial struct RandomSelectorSystem : ISystem
    {
        public void OnCreate(ref SystemState state) {}
    
        public void OnDestroy(ref SystemState state) {}

        public void OnUpdate(ref SystemState state)
        {
            var job = new RandomSelectorJob();
            job.OptionEvaluatorLookup = SystemAPI.GetComponentLookup<OptionEvaluator>();
            job.ScheduleParallel();
        }
    }
    
    [BurstCompile]
    public partial struct RandomSelectorJob : IJobEntity
    {
        [ReadOnly]
        public ComponentLookup<OptionEvaluator> OptionEvaluatorLookup;
        
        private void Execute([EntityIndexInQuery] int sortKey,
            in DynamicBuffer<OptionEvaluatorHandleElement> optionEvaluatorHandleBuffer, ref Decision decision, ref RandomSelector selector)
        {
            if (optionEvaluatorHandleBuffer.IsEmpty)
            {
                return;
            }
            
            Random randomGenerator = Random.CreateFromIndex((uint)sortKey);
            randomGenerator.InitState(selector.RandomSeed);
            selector.RandomSeed = randomGenerator.NextUInt();
            
            int startingIndex = randomGenerator.NextInt(0, optionEvaluatorHandleBuffer.Length);
            int currentIndex = startingIndex;
            do
            {
                OptionEvaluatorHandleElement optionEvaluatorHandleElement = optionEvaluatorHandleBuffer[currentIndex];
                if (OptionEvaluatorLookup.HasComponent(optionEvaluatorHandleElement.Entity))
                {
                    RefRO<OptionEvaluator> optionEvaluator = OptionEvaluatorLookup.GetRefRO(optionEvaluatorHandleElement.Entity);
                    decision.SelectedOptionKey = optionEvaluator.ValueRO.OptionKey;
                    decision.UtilityOfSelection = optionEvaluator.ValueRO.Utility;
                    break;
                }
                
                ++currentIndex;
                currentIndex %= optionEvaluatorHandleBuffer.Length;
            } while (currentIndex != startingIndex);
        }
    }
}
