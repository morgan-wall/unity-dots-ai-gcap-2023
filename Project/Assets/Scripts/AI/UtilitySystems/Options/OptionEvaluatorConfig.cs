// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using AI.UtilitySystems.Considerations;
using AI.UtilitySystems.Options.Aggregators;
using AI.UtilitySystems.Utils;
using Unity.Entities;

namespace AI.UtilitySystems.Options
{
    [Serializable]
    public struct OptionEvaluatorConfig : IDeferredAuthor
    {
        public OptionConfigBase OptionConfig;
        public Aggregator Aggregator;
        public ConsiderationConfig[] ConsiderationConfigs;

        #region IDeferredAuthor

        public void Bake(IBaker baker, Entity entity)
        {
            if (OptionConfig == null)
            {
                throw new NullReferenceException($"OptionEvaluatorConfig.Bake: option config is null.");
            }
            
            baker.AddComponent(entity, new OptionEvaluator
            {
                OptionKey = OptionConfig.GetKey(),
                Utility = float.MinValue,
            });
            
            switch (Aggregator)
            {
                case Aggregator.Multiplication:
                    baker.AddComponent<MultiplicationAggregator>(entity);
                    break;
                case Aggregator.Min:
                    baker.AddComponent<MinAggregator>(entity);
                    break;
                case Aggregator.Max:
                    baker.AddComponent<MaxAggregator>(entity);
                    break;
                
                default:
                    throw new NotImplementedException($"OptionEvaluatorConfig.Bake: haven't implemented the {Aggregator} aggregator.");
            }

            DynamicBuffer<ConsiderationHandleElement> considerationHandleBuffer = baker.AddBuffer<ConsiderationHandleElement>(entity);
            DynamicBuffer<ConsiderationHandleCleanupElement> considerationHandleCleanupBuffer = baker.AddBuffer<ConsiderationHandleCleanupElement>(entity);
            foreach (ConsiderationConfig considerationConfig in ConsiderationConfigs)
            {
                Entity considerationEntity = baker.CreateAdditionalEntity(TransformUsageFlags.None);
                considerationConfig.Bake(baker, considerationEntity);
                considerationHandleBuffer.Add(new ConsiderationHandleElement
                {
                    Entity = considerationEntity,
                });
            }
        }

        #endregion // IDeferredAuthor
    }
}
