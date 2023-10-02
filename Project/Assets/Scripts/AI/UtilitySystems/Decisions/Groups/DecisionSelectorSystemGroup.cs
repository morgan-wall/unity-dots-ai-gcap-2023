// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;

namespace AI.UtilitySystems.Decisions.Groups
{
    [UpdateInGroup(typeof(DecisionSystemGroup))]
    [UpdateAfter(typeof(DecisionInitSystemGroup))]
    [UpdateBefore(typeof(DecisionDeinitSystemGroup))]
    public partial class DecisionSelectorSystemGroup : ComponentSystemGroup
    {
    }
}
