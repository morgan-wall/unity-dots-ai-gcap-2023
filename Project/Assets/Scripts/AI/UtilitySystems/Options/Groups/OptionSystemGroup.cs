// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;
using AI.UtilitySystems.Considerations.Groups;
using AI.UtilitySystems.Decisions.Groups;
using AI.UtilitySystems.Groups;

namespace AI.UtilitySystems.Options.Groups
{
    [UpdateInGroup(typeof(UtilitySystemSystemGroup))]
    [UpdateAfter(typeof(ConsiderationSystemGroup))]
    [UpdateBefore(typeof(DecisionSystemGroup))]
    public partial class OptionSystemGroup : ComponentSystemGroup
    {
    }
}
