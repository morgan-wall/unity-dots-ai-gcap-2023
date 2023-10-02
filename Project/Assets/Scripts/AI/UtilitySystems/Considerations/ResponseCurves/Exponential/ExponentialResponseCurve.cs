// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;

namespace AI.UtilitySystems.Considerations.ResponseCurves.Exponential
{
    public struct ExponentialResponseCurve : IComponentData
    {
        // Function: y = m^(k * (x - c)) + b
        public float K;
        public float M;
        public float B;
        public float C;
    }
}
