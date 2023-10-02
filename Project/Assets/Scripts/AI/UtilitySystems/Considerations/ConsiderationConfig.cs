// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using AI.Agents;
using AI.UtilitySystems.Considerations.Inputs;
using AI.UtilitySystems.Considerations.Normalization;
using AI.UtilitySystems.Considerations.ResponseCurves;
using AI.UtilitySystems.Utils;
using Unity.Entities;

namespace AI.UtilitySystems.Considerations
{
    [Serializable]
    public struct ConsiderationConfig : IDeferredAuthor
    {
        public InputConfigBase InputConfig;
        public NormalizerConfig NormalizerConfig;
        public ResponseCurveConfig ResponseCurveConfig;

        #region IDeferredAuthor

        public void Bake(IBaker baker, Entity entity)
        {
            if (InputConfig == null)
            {
                throw new NullReferenceException($"ConsiderationConfig.Bake: input config is null.");
            }
            
            baker.AddComponent(entity, new AgentHandle
            {
                Entity = baker.GetEntity(TransformUsageFlags.None),
            });
            
            baker.AddComponent(entity, new Consideration
            {
                RawInput = 0.0f,
                NormalizedInput = 0.0f,
                ResponseCurveOutput = 0.0f,
            });
            
            InputConfig.Bake(baker, entity);
            NormalizerConfig.Bake(baker, entity);
            ResponseCurveConfig.Bake(baker, entity);
        }

        #endregion // IDeferredAuthor
    }
}
