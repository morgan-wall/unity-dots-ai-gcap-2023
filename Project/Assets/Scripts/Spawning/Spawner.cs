// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;

namespace Spawning
{
    public struct Spawner : IComponentData
    {
        public Entity Spawnable;
        public int SpawnsPerTick;
        public int TicksRemaining;
    }
}
