// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;

namespace AI.UtilitySystems.Options.Groups
{
    [UpdateInGroup(typeof(OptionSystemGroup))]
    [UpdateBefore(typeof(OptionConsiderationAggregationSystemGroup))]
    public partial class OptionInitSystemGroup : ComponentSystemGroup
    {
    }
}
