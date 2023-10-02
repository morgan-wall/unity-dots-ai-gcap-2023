// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;
using AI.UtilitySystems.Options.Groups;
using AI.UtilitySystems.Groups;

namespace AI.UtilitySystems.Decisions.Groups
{
    [UpdateInGroup(typeof(UtilitySystemSystemGroup))]
    [UpdateAfter(typeof(OptionSystemGroup))]
    public partial class DecisionSystemGroup : ComponentSystemGroup
    {
    }
}
