// Copyright (c) 2023 Morgan Wall. All rights reserved.

using AI.UtilitySystems.Considerations.Groups;
using Unity.Entities;
using Unity.Burst;

namespace AI.UtilitySystems.Considerations.Utils.Cleanup
{
    [BurstCompile]
    [RequireMatchingQueriesForUpdate]
    [UpdateInGroup(typeof(ConsiderationInitSystemGroup))]
    public partial struct ConsiderationHandleCleanupElementSystem : ISystem
    {
        public void OnCreate(ref SystemState state) {}
    
        public void OnDestroy(ref SystemState state) {}

        public void OnUpdate(ref SystemState state)
        {
            EntityCommandBuffer.ParallelWriter parallelWriter = GetEntityCommandBuffer(ref state);
            new ConsiderationHandleCleanupElementJob
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
    [WithNone(typeof(ConsiderationHandleElement))]
    public partial struct ConsiderationHandleCleanupElementJob : IJobEntity
    {
        public EntityCommandBuffer.ParallelWriter ParallelWriter;
        
        private void Execute(Entity entity, [ChunkIndexInQuery] int sortKey,
            in DynamicBuffer<ConsiderationHandleCleanupElement> considerationHandleCleanupBuffer)
        {
            foreach (ConsiderationHandleCleanupElement considerationHandleCleanupElement in considerationHandleCleanupBuffer)
            {
                ParallelWriter.DestroyEntity(sortKey, considerationHandleCleanupElement.Entity);
            }
            
            ParallelWriter.RemoveComponent<ConsiderationHandleCleanupElement>(sortKey, entity);
        }
    }
}
