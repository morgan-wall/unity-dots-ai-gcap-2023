// Copyright (c) 2023 Morgan Wall. All rights reserved.

using System;
using UnityEngine;
using Unity.Entities;

namespace Spawning
{
    [Serializable]
    public class SpawnerAuthoring : MonoBehaviour
    {
        [SerializeField]
        private GameObject _spawnable = null;
        
        [SerializeField]
        private int _spawnsPerTick = 1;
        
        [SerializeField]
        private int _totalTickCount = 1;

        public GameObject Spawnable
        {
            get { return _spawnable; }
        }
        
        public int SpawnsPerTick
        {
            get { return _spawnsPerTick; }
        }
        
        public int TotalTickCount
        {
            get { return _totalTickCount; }
        }
    }

    public class SpawnerBaker : Baker<SpawnerAuthoring>
    {
        public override void Bake(SpawnerAuthoring authoring)
        {
            Entity spawner = GetEntity(TransformUsageFlags.None);
            AddComponent(spawner, new Spawner
            {
                Spawnable = GetEntity(authoring.Spawnable, TransformUsageFlags.None),
                SpawnsPerTick = authoring.SpawnsPerTick,
                TicksRemaining = authoring.TotalTickCount,
            });
        }
    }
}
