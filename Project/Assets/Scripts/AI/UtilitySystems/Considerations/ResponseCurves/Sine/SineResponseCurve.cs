// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;

namespace AI.UtilitySystems.Considerations.ResponseCurves.Sine
{
    public struct SineResponseCurve : IComponentData
    {
        // Function: y = k * sin(m * (x - c)) + b
        public float K;
        public float M;
        public float B;
        public float C;
    }
}
