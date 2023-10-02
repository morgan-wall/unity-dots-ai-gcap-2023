// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using AI.UtilitySystems.Considerations.Inputs;
using Unity.Entities;
using UnityEngine;

namespace Attributes.Health.UtilitySystem.Input
{
    [Serializable]
    [CreateAssetMenu(fileName = "HealthPercentageInput", menuName = "AI/Utility Systems/Inputs/Health/Health Percentage")]
    public sealed class HealthPercentageInputConfig : InputConfigBase
    {
        public override void Bake(IBaker baker, Entity entity)
        {
            baker.AddComponent<HealthPercentageInput>(entity);
        }
    }
}
