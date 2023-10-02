// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;

namespace AI.UtilitySystems.Groups
{
    [UpdateInGroup(typeof(SimulationSystemGroup))]
    public partial class UtilitySystemSystemGroup : ComponentSystemGroup
    {
    }
}
