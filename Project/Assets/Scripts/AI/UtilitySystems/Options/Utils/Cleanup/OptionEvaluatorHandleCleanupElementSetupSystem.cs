// Copyright (c) 2023 Morgan Wall. All rights reserved.

using AI.UtilitySystems.Options.Groups;
using Unity.Entities;
using Unity.Burst;

namespace AI.UtilitySystems.Options.Utils.Cleanup
{
    [BurstCompile]
    [RequireMatchingQueriesForUpdate]
    [UpdateInGroup(typeof(OptionInitSystemGroup))]
    public partial struct OptionEvaluatorHandleCleanupElementSetupSystem : ISystem
    {
        public void OnCreate(ref SystemState state) {}
    
        public void OnDestroy(ref SystemState state) {}

        public void OnUpdate(ref SystemState state)
        {
            EntityCommandBuffer.ParallelWriter parallelWriter = GetEntityCommandBuffer(ref state);
            new OptionEvaluatorHandleCleanupElementSetupJob
            {
                ParallelWriter = parallelWriter,
            }.ScheduleParallel();
        }
        
        private EntityCommandBuffer.ParallelWriter GetEntityCommandBuffer(ref SystemState state)
        {
            var singleton = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
            var entityCommandBuffer = singleton.CreateCommandBuffer(state.WorldUnmanaged);
            return entityCommandBuffer.AsParallelWriter();
        }
    }
    
    [BurstCompile]
    [WithNone(typeof(OptionEvaluatorHandleCleanupElement))]
    public partial struct OptionEvaluatorHandleCleanupElementSetupJob : IJobEntity
    {
        public EntityCommandBuffer.ParallelWriter ParallelWriter;
        
        private void Execute(Entity entity, [ChunkIndexInQuery] int sortKey,
            in DynamicBuffer<OptionEvaluatorHandleElement> OptionEvaluatorHandleBuffer)
        {
            ParallelWriter.AddBuffer<OptionEvaluatorHandleCleanupElement>(sortKey, entity);
            foreach (OptionEvaluatorHandleElement optionEvaluatorHandleElement in OptionEvaluatorHandleBuffer)
            {
                ParallelWriter.AppendToBuffer(sortKey, entity, new OptionEvaluatorHandleCleanupElement
                {
                    Entity = optionEvaluatorHandleElement.Entity,
                });
            }
        }
    }
}
