// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;

namespace AI.UtilitySystems.Options
{
    public struct OptionEvaluator : IComponentData
    {
        public int OptionKey;
        public float Utility;
    }
}
