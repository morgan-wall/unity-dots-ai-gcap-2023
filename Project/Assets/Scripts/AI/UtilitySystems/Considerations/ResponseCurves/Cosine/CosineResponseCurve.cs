// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;

namespace AI.UtilitySystems.Considerations.ResponseCurves.Cosine
{
    public struct CosineResponseCurve : IComponentData
    {
        // Function: y = k * cos(m * (x - c)) + b
        public float K;
        public float M;
        public float B;
        public float C;
    }
}
