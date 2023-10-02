// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using AI.UtilitySystems.Considerations.Inputs;
using Unity.Entities;
using UnityEngine;

namespace Attributes.Mana.UtilitySystem.Input
{
    [Serializable]
    [CreateAssetMenu(fileName = "ManaPercentageInput", menuName = "AI/Utility Systems/Inputs/Mana/Mana Percentage")]
    public sealed class ManaPercentageInputConfig : InputConfigBase
    {
        public override void Bake(IBaker baker, Entity entity)
        {
            baker.AddComponent<ManaPercentageInput>(entity);
        }
    }
}
