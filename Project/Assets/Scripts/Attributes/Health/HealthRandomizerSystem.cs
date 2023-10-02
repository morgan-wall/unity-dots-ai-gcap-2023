// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;
using Unity.Burst;
using Unity.Mathematics;

namespace Attributes.Health
{
    [BurstCompile]
    public partial struct HealthRandomizerSystem : ISystem
    {
        public void OnCreate(ref SystemState state) {}
    
        public void OnDestroy(ref SystemState state) {}

        public void OnUpdate(ref SystemState state)
        {
            new HealthRandomizerJob
            {
                ElapsedTime = SystemAPI.Time.ElapsedTime,
            }.ScheduleParallel();
        }
    }
    
    [BurstCompile]
    public partial struct HealthRandomizerJob : IJobEntity
    {
        public double ElapsedTime;
        
        private void Execute([EntityIndexInQuery] int sortKey, ref Health health, ref HealthRandomizer healthRandomizer)
        {
            if (healthRandomizer.NextRandomizationTime > ElapsedTime)
            {
                return;
            }
            healthRandomizer.NextRandomizationTime = ElapsedTime + healthRandomizer.TimeBetweenRandomizations;
            
            Random randomGenerator = Random.CreateFromIndex((uint)sortKey);
            randomGenerator.InitState(healthRandomizer.RandomSeed);
            healthRandomizer.RandomSeed = randomGenerator.NextUInt();
            
            health.CurrentValue = randomGenerator.NextFloat(0.0f, health.MaxValue);
        }
    }
}
