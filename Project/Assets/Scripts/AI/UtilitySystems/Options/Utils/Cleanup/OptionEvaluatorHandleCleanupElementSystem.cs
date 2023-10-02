// Copyright (c) 2023 Morgan Wall. All rights reserved.

using AI.UtilitySystems.Options.Groups;
using Unity.Entities;
using Unity.Burst;

namespace AI.UtilitySystems.Options.Utils.Cleanup
{
    [BurstCompile]
    [RequireMatchingQueriesForUpdate]
    [UpdateInGroup(typeof(OptionDeinitSystemGroup))]
    public partial struct OptionEvaluatorHandleCleanupElementSystem : ISystem
    {
        public void OnCreate(ref SystemState state) {}
    
        public void OnDestroy(ref SystemState state) {}

        public void OnUpdate(ref SystemState state)
        {
            EntityCommandBuffer.ParallelWriter parallelWriter = GetEntityCommandBuffer(ref state);
            new OptionEvaluatorHandleCleanupElementJob
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
    [WithNone(typeof(OptionEvaluatorHandleElement))]
    public partial struct OptionEvaluatorHandleCleanupElementJob : IJobEntity
    {
        public EntityCommandBuffer.ParallelWriter ParallelWriter;
        
        private void Execute(Entity entity, [ChunkIndexInQuery] int sortKey,
            in DynamicBuffer<OptionEvaluatorHandleCleanupElement> OptionEvaluatorHandleCleanupBuffer)
        {
            foreach (OptionEvaluatorHandleCleanupElement optionEvaluatorHandleCleanupElement in OptionEvaluatorHandleCleanupBuffer)
            {
                ParallelWriter.DestroyEntity(sortKey, optionEvaluatorHandleCleanupElement.Entity);
            }
            
            ParallelWriter.RemoveComponent<OptionEvaluatorHandleCleanupElement>(sortKey, entity);
        }
    }
}
