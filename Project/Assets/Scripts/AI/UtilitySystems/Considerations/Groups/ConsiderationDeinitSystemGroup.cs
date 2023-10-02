// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;

namespace AI.UtilitySystems.Considerations.Groups
{
    [UpdateInGroup(typeof(ConsiderationSystemGroup))]
    [UpdateAfter(typeof(ConsiderationResponseCurveSystemGroup))]
    public partial class ConsiderationDeinitSystemGroup : ComponentSystemGroup
    {
    }
}
