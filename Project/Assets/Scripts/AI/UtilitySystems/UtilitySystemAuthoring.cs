// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using AI.UtilitySystems.Decisions;
using AI.UtilitySystems.Decisions.Selectors;
using AI.UtilitySystems.Options;
using UnityEngine;
using Unity.Entities;
using Random = UnityEngine.Random;

namespace AI.UtilitySystems
{
    [Serializable]
    public class UtilitySystemAuthoring : MonoBehaviour
    {
        [SerializeField]
        private UtilitySystemConfig _utilitySystemConfig = null;

        public UtilitySystemConfig UtilitySystemConfig
        {
            get { return _utilitySystemConfig; }
        }
    }
    
    public class UtilitySystemBaker : Baker<UtilitySystemAuthoring>
    {
        public override void Bake(UtilitySystemAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None);
            Entity decisionEntity = CreateAdditionalEntity(TransformUsageFlags.None);
            AddComponent(entity, new DecisionHandle
            {
                Entity = decisionEntity,
            });
            
            AddComponent<Decision>(decisionEntity);
            switch (authoring.UtilitySystemConfig.Selector)
            {
                case Selector.HighestUtility:
                    AddComponent<HighestUtilitySelector>(decisionEntity);
                    break;
                case Selector.LowestUtility:
                    AddComponent<LowestUtilitySelector>(decisionEntity);
                    break;
                case Selector.Random:
                    AddComponent(decisionEntity, new RandomSelector
                    {
                        RandomSeed = (uint)Random.Range(0, int.MaxValue),
                    });
                    break;
                
                default:
                    throw new NotImplementedException($"UtilitySystemBaker.Bake: haven't implemented the {authoring.UtilitySystemConfig.Selector} selector.");
            }
            
            DynamicBuffer<OptionEvaluatorHandleElement> optionEvaluatorHandleBuffer = AddBuffer<OptionEvaluatorHandleElement>(decisionEntity);
            DynamicBuffer<OptionEvaluatorHandleCleanupElement> optionEvaluatorHandleCleanupBuffer = AddBuffer<OptionEvaluatorHandleCleanupElement>(decisionEntity);
            foreach (OptionEvaluatorConfig optionEvaluatorConfig in authoring.UtilitySystemConfig.OptionEvaluatorConfigs)
            {
                Entity optionEvaluatorEntity = CreateAdditionalEntity(TransformUsageFlags.None);
                optionEvaluatorConfig.Bake(this, optionEvaluatorEntity);
                optionEvaluatorHandleBuffer.Add(new OptionEvaluatorHandleElement
                {
                    Entity = optionEvaluatorEntity,
                });
            }
        }
    }
}
