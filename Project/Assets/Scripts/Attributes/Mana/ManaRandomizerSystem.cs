// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;
using Unity.Burst;
using Unity.Mathematics;

namespace Attributes.Mana
{
    [BurstCompile]
    public partial struct ManaRandomizerSystem : ISystem
    {
        public void OnCreate(ref SystemState state) {}
    
        public void OnDestroy(ref SystemState state) {}

        public void OnUpdate(ref SystemState state)
        {
            new ManaRandomizerJob()
            {
                ElapsedTime = SystemAPI.Time.ElapsedTime,
            }.ScheduleParallel();
        }
    }
    
    [BurstCompile]
    public partial struct ManaRandomizerJob : IJobEntity
    {
        public double ElapsedTime;
        
        private void Execute([EntityIndexInQuery] int sortKey, ref Mana mana, ref ManaRandomizer manaRandomizer)
        {
            if (manaRandomizer.NextRandomizationTime > ElapsedTime)
            {
                return;
            }
            manaRandomizer.NextRandomizationTime = ElapsedTime + manaRandomizer.TimeBetweenRandomizations;
            
            Random randomGenerator = Random.CreateFromIndex((uint)sortKey);
            randomGenerator.InitState(manaRandomizer.RandomSeed);
            manaRandomizer.RandomSeed = randomGenerator.NextUInt();
            
            mana.CurrentValue = randomGenerator.NextFloat(0.0f, mana.MaxValue);
        }
    }
}
