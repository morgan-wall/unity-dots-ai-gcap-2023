// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;

namespace AI.UtilitySystems.Decisions.Groups
{
    [UpdateInGroup(typeof(DecisionSystemGroup))]
    [UpdateBefore(typeof(DecisionSelectorSystemGroup))]
    public partial class DecisionInitSystemGroup : ComponentSystemGroup
    {
    }
}
