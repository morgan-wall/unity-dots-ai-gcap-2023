// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using AI.UtilitySystems.Decisions.Selectors;
using AI.UtilitySystems.Options;
using UnityEngine;

namespace AI.UtilitySystems
{
    [Serializable]
    [CreateAssetMenu(fileName = "UtilitySystem", menuName = "AI/Utility Systems/Utilty System Config")]
    public class UtilitySystemConfig : ScriptableObject
    {
        public Selector Selector = Selector.HighestUtility;
        public OptionEvaluatorConfig[] OptionEvaluatorConfigs = new OptionEvaluatorConfig[]{};
    }
}
