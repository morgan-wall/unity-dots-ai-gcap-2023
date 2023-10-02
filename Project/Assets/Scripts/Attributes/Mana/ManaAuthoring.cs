// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

namespace Attributes.Mana
{
    [Serializable]
    public class ManaAuthoring : MonoBehaviour
    {
        [SerializeField]
        private float _initialMana = 100.0f;
        
        [SerializeField]
        private float _maxMana = 100.0f;

        public float InitialMana
        {
            get { return _initialMana; }
        }

        public float MaxMana
        {
            get { return _maxMana; }
        }
    }
    
    public class ManaBaker : Baker<ManaAuthoring>
    {
        public override void Bake(ManaAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None);
            AddComponent(entity, new Mana
            {
                CurrentValue = math.min(authoring.InitialMana, authoring.MaxMana),
                MaxValue = authoring.MaxMana,
            });
        }
    }
}
