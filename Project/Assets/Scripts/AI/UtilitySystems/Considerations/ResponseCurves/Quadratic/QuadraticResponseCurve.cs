// Copyright (c) 2023 Morgan Wall. All rights reserved.

using Unity.Entities;

namespace AI.UtilitySystems.Considerations.ResponseCurves.Quadratic
{
    public struct QuadraticResponseCurve : IComponentData
    {
        // Function: y = m * (x - c)^k + b
        public float K;
        public float M;
        public float B;
        public float C;
    }
}
