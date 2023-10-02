// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;
using Unity.Burst;

namespace Spawning
{
    [BurstCompile]
    [RequireMatchingQueriesForUpdate]
    public partial struct SpawnerSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
        }
        
        public void OnDestroy(ref SystemState state)
        {
        }
    
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            EntityCommandBuffer.ParallelWriter parallelWriter = GetEntityCommandBuffer(ref state);
            new ProcessSpawnerJob
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
    public partial struct ProcessSpawnerJob : IJobEntity
    {
        public EntityCommandBuffer.ParallelWriter ParallelWriter;
    
        private void Execute([ChunkIndexInQuery] int sortKey, ref Spawner spawner)
        {
            if (spawner.TicksRemaining <= 0)
            {
                return;
            }
            --spawner.TicksRemaining;

            for (int i = 0; i < spawner.SpawnsPerTick; ++i)
            {
                ParallelWriter.Instantiate(sortKey, spawner.Spawnable);
            }
        }
    }
}
