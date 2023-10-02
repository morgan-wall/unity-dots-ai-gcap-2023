// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;
using AI.UtilitySystems.Options.Groups;
using AI.UtilitySystems.Groups;

namespace AI.UtilitySystems.Considerations.Groups
{
    [UpdateInGroup(typeof(UtilitySystemSystemGroup))]
    [UpdateBefore(typeof(OptionSystemGroup))]
    public partial class ConsiderationSystemGroup : ComponentSystemGroup
    {
    }
}
