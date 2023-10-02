// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;

namespace AI.Agents
{
    public struct AgentHandleBuffer : IBufferElementData
    {
        public Entity Entity;
    }
}
