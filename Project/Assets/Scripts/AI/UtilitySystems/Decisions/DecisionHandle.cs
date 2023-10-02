// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;

namespace AI.UtilitySystems.Decisions
{
    public struct DecisionHandle : IComponentData
    {
        public Entity Entity;
    }
}
