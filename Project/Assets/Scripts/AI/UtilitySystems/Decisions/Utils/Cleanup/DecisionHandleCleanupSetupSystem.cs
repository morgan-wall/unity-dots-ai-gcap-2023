// Copyright (c) 2023 Morgan Wall. All rights reserved.

using AI.UtilitySystems.Decisions.Groups;
using Unity.Entities;
using Unity.Burst;

namespace AI.UtilitySystems.Decisions.Utils.Cleanup
{
    [BurstCompile]
    [RequireMatchingQueriesForUpdate]
    [UpdateInGroup(typeof(DecisionInitSystemGroup))]
    public partial struct DecisionHandleCleanupSetupSystem : ISystem
    {
        public void OnCreate(ref SystemState state) {}
    
        public void OnDestroy(ref SystemState state) {}

        public void OnUpdate(ref SystemState state)
        {
            EntityCommandBuffer.ParallelWriter parallelWriter = GetEntityCommandBuffer(ref state);
            new DecisionHandleCleanupSetupJob
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
    [WithNone(typeof(DecisionHandleCleanup))]
    public partial struct DecisionHandleCleanupSetupJob : IJobEntity
    {
        public EntityCommandBuffer.ParallelWriter ParallelWriter;
        
        private void Execute(Entity entity, [ChunkIndexInQuery] int sortKey, in DecisionHandle decisionHandle)
        {
            ParallelWriter.AddComponent(sortKey, entity, new DecisionHandleCleanup
            {
                Entity = decisionHandle.Entity,
            });
        }
    }
}
