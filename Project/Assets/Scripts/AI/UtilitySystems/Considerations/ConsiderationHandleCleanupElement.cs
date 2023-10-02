// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;

namespace AI.UtilitySystems.Considerations
{
    public struct ConsiderationHandleCleanupElement : ICleanupBufferElementData
    {
        public Entity Entity;
    }
}
