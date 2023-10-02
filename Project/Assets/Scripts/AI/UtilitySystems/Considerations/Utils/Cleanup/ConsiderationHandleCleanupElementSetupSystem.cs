// Copyright (c) 2023 Morgan Wall. All rights reserved.

using AI.UtilitySystems.Considerations.Groups;
using Unity.Entities;
using Unity.Burst;

namespace AI.UtilitySystems.Considerations.Utils.Cleanup
{
    [BurstCompile]
    [RequireMatchingQueriesForUpdate]
    [UpdateInGroup(typeof(ConsiderationInitSystemGroup))]
    public partial struct ConsiderationHandleCleanupElementSetupSystem : ISystem
    {
        public void OnCreate(ref SystemState state) {}
    
        public void OnDestroy(ref SystemState state) {}

        public void OnUpdate(ref SystemState state)
        {
            EntityCommandBuffer.ParallelWriter parallelWriter = GetEntityCommandBuffer(ref state);
            new ConsiderationHandleCleanupElementSetupJob
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
    [WithNone(typeof(ConsiderationHandleCleanupElement))]
    public partial struct ConsiderationHandleCleanupElementSetupJob : IJobEntity
    {
        public EntityCommandBuffer.ParallelWriter ParallelWriter;
        
        private void Execute(Entity entity, [ChunkIndexInQuery] int sortKey,
            in DynamicBuffer<ConsiderationHandleElement> considerationHandleBuffer)
        {
            ParallelWriter.AddBuffer<ConsiderationHandleCleanupElement>(sortKey, entity);
            foreach (ConsiderationHandleElement considerationHandleElement in considerationHandleBuffer)
            {
                ParallelWriter.AppendToBuffer(sortKey, entity, new ConsiderationHandleCleanupElement
                {
                    Entity = considerationHandleElement.Entity,
                });
            }
        }
    }
}
