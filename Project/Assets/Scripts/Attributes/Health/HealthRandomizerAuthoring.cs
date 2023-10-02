// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using UnityEngine;
using Unity.Entities;
using Random = UnityEngine.Random;

namespace Attributes.Health
{
    [Serializable]
    public class HealthRandomizerAuthoring : MonoBehaviour
    {
        [SerializeField]
        private float _timeBetweenRandomizations = 1.0f;

        public float TimeBetweenRandomizations
        {
            get { return _timeBetweenRandomizations; }
        }
    }
    
    public class HealthRandomizerBaker : Baker<HealthRandomizerAuthoring>
    {
        public override void Bake(HealthRandomizerAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new HealthRandomizer
            {
                NextRandomizationTime = 0.0f,
                TimeBetweenRandomizations = authoring.TimeBetweenRandomizations,
                RandomSeed = (uint)Random.Range(0, int.MaxValue),
            });
        }
    }
}
