// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;

namespace AI.UtilitySystems.Options.Groups
{
    [UpdateInGroup(typeof(OptionSystemGroup))]
    [UpdateAfter(typeof(OptionInitSystemGroup))]
    [UpdateBefore(typeof(OptionDeinitSystemGroup))]
    public partial class OptionConsiderationAggregationSystemGroup : ComponentSystemGroup
    {
    }
}
