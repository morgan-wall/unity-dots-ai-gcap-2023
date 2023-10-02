// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace Attributes.Health
{
    [Serializable]
    public class HealthAuthoring : MonoBehaviour
    {
        [SerializeField]
        private float _initialHealth = 100.0f;
        
        [SerializeField]
        private float _maxHealth = 100.0f;

        public float InitialHealth
        {
            get { return _initialHealth; }
        }

        public float MaxHealth
        {
            get { return _maxHealth; }
        }
    }
    
    public class HealthBaker : Baker<HealthAuthoring>
    {
        public override void Bake(HealthAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new Health
            {
                CurrentValue = math.min(authoring.InitialHealth, authoring.MaxHealth),
                MaxValue = authoring.MaxHealth,
            });
        }
    }
}
