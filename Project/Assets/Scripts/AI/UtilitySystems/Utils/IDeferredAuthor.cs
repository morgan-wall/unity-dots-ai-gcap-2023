// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;

namespace AI.UtilitySystems.Utils
{
    public interface IDeferredAuthor
    {
        void Bake(IBaker baker, Entity entity);
    }
}
