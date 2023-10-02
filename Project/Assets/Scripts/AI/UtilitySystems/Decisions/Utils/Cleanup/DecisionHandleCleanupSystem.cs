// Copyright (c) 2023 Morgan Wall. All rights reserved.

using AI.UtilitySystems.Decisions.Groups;
using Unity.Entities;
using Unity.Burst;

namespace AI.UtilitySystems.Decisions.Utils.Cleanup
{
    [BurstCompile]
    [RequireMatchingQueriesForUpdate]
    [UpdateInGroup(typeof(DecisionDeinitSystemGroup))]
    public partial struct DecisionHandleCleanupSystem : ISystem
    {
        public void OnCreate(ref SystemState state) {}
    
        public void OnDestroy(ref SystemState state) {}

        public void OnUpdate(ref SystemState state)
        {
            EntityCommandBuffer.ParallelWriter parallelWriter = GetEntityCommandBuffer(ref state);
            new DecisionHandleCleanupJob
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
    [WithNone(typeof(DecisionHandle))]
    public partial struct DecisionHandleCleanupJob : IJobEntity
    {
        public EntityCommandBuffer.ParallelWriter ParallelWriter;
        
        private void Execute(Entity entity, [ChunkIndexInQuery] int sortKey, in DecisionHandleCleanup decisionHandleCleanup)
        {
            ParallelWriter.DestroyEntity(sortKey, decisionHandleCleanup.Entity);
            ParallelWriter.RemoveComponent<DecisionHandleCleanup>(sortKey, entity);
        }
    }
}
